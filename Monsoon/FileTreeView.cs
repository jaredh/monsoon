//
// FileTreeView.cs
//
// Author:
//   Jared Hendry (buchan@gmail.com)
//
// Copyright (C) 2007 Jared Hendry
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using Gtk;
using MonoTorrent.Common;
using System.IO;

namespace Monsoon
{
	
	
	public class FileTreeView : TreeView
	{
		private TreeViewColumn priorityColumn;
		private TreeViewColumn filenameColumn;
		private TreeViewColumn progressColumn;
		//private TreeStore treeStore;
		private TorrentController torrentController;
		
		private Gtk.Menu contextMenu;
		private ImageMenuItem highItem;
		private ImageMenuItem highestItem;
		private ImageMenuItem immediateItem;
		private ImageMenuItem lowItem;
		private ImageMenuItem lowestItem;
		private ImageMenuItem normalItem;
		private ImageMenuItem nodownItem;
		
		public FileTreeView(TorrentController torrentController, TreeStore treeStore) : base()
		{
			this.torrentController = torrentController;
			//this.treeStore = treeStore;
			HeadersVisible = true;
			
			BuildColumns ();
			BuildContextMenu ();
		}
		
		public static string GetPriorityIconName(Priority priority)
		{
			switch (priority) {
				case Priority.Immediate:
					return "immediate.png";
				case Priority.Highest:
					return "highest.png";
				case Priority.High:
					return "high.png";
				case Priority.Normal:
					return null;
				case Priority.Low:
					return "low.png";
				case Priority.Lowest:
					return "lowest.png";
				case Priority.DoNotDownload:
					return "donotdownload.png";
			}
			
			return null;
		}
		
		private void BuildColumns ()
		{
			priorityColumn = new TreeViewColumn ();
			filenameColumn = new TreeViewColumn ();
			progressColumn = new TreeViewColumn ();
			
			filenameColumn.Resizable = true;
			
			priorityColumn.Title = "";
			filenameColumn.Title = "Filename";
			progressColumn.Title = "Progress";
			
			Gtk.CellRendererPixbuf priorityCell = new CellRendererPixbuf ();
			Gtk.CellRendererText filenameCell = new CellRendererText ();
			Gtk.CellRendererProgress progressCell = new CellRendererProgress ();
			
			priorityColumn.PackStart (priorityCell, true);
			priorityColumn.SetAttributes (priorityCell, "pixbuf", 2);
			filenameColumn.PackStart (filenameCell, true);
			filenameColumn.SetAttributes (filenameCell, "text", 3);
			progressColumn.PackStart(progressCell, true);
			progressColumn.SetCellDataFunc (progressCell, new Gtk.TreeCellDataFunc (RenderProgress));
			
			AppendColumn (priorityColumn);
			AppendColumn (filenameColumn);
			AppendColumn (progressColumn);
		}
		
		private void BuildContextMenu ()
		{
			contextMenu = new Menu ();
			
			highItem = new ImageMenuItem ("High");
			highestItem = new ImageMenuItem ("Highest");
			immediateItem = new ImageMenuItem ("Immediate");
			lowItem = new ImageMenuItem ("Low");
			lowestItem = new ImageMenuItem ("Lowest");
			normalItem = new ImageMenuItem ("Normal");
			nodownItem = new ImageMenuItem ("Do Not Download");
			highItem.Image = new Image(System.IO.Path.Combine(Defines.IconPath, "high.png"));
			highestItem.Image = new Image(System.IO.Path.Combine(Defines.IconPath, "highest.png"));
			immediateItem.Image = new Image(System.IO.Path.Combine(Defines.IconPath, "immediate.png"));
			lowItem.Image = new Image(System.IO.Path.Combine(Defines.IconPath, "low.png"));
			lowestItem.Image = new Image(System.IO.Path.Combine(Defines.IconPath, "lowest.png"));
			//normalItem.Image = new Image(System.IO.Path.Combine(Defines.IconPath, "normal.png"));
			nodownItem.Image = new Image(System.IO.Path.Combine(Defines.IconPath, "donotdownload.png"));
			
			
			highItem.Activated += OnContextMenuItemClicked;
			highestItem.Activated += OnContextMenuItemClicked;
			immediateItem.Activated += OnContextMenuItemClicked;
			lowItem.Activated += OnContextMenuItemClicked;
			lowestItem.Activated += OnContextMenuItemClicked;
			normalItem.Activated += OnContextMenuItemClicked;
			nodownItem.Activated += OnContextMenuItemClicked;
			
			contextMenu.Append (immediateItem);
			contextMenu.Append (highestItem);
			contextMenu.Append (highItem);
			contextMenu.Append (normalItem);
			contextMenu.Append (lowItem);
			contextMenu.Append (lowestItem);
			contextMenu.Append (nodownItem);
			
		}
		
		private void OnContextMenuItemClicked (object sender, EventArgs args)
		{
			TreeIter iter;
			TorrentFile file;
			Priority priority;
			
			if (!Selection.GetSelected (out iter))
				return;
			
			ImageMenuItem item = (ImageMenuItem) sender;
			
			// Determine priority
			if (item == highItem)
				priority = Priority.High;
			else if (item == highestItem)
				priority = Priority.Highest;
			else if (item == immediateItem)
				priority = Priority.Immediate;
			else if (item == lowItem)
				priority = Priority.Low;
			else if (item == lowestItem)
				priority = Priority.Lowest;
			else if (item == normalItem)
				priority = Priority.Normal;
			else if (item == nodownItem)
				priority = Priority.DoNotDownload;
			else
				priority = Priority.Normal;
			
			file = (TorrentFile) Model.GetValue (iter, 1);
			
			torrentController.SetFilePriority(file, priority);
			
			Model.SetValue(iter, 2, MainWindow.GetIconPixbuf(
				GetPriorityIconName(priority)));
		}
		
		protected override bool	OnButtonPressEvent (Gdk.EventButton e)
		{
			// Call this first so context menu has a selected torrent
			base.OnButtonPressEvent(e);
			
			if(e.Button == 3 && Selection.CountSelectedRows() == 1){
				contextMenu.ShowAll();
				contextMenu.Popup();
			}
			
			return false;
		}
		
		private void RenderFilename (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			TorrentFile torrentFile = (TorrentFile) model.GetValue (iter, 1);
			(cell as Gtk.CellRendererText).Text = torrentFile.Path;
			
		}
		
		private void RenderProgress (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			TorrentFile torrentFile = (TorrentFile) model.GetValue ( iter, 1);
			
			(cell as Gtk.CellRendererProgress).Value = 0;
			(cell as Gtk.CellRendererProgress).Value = (int)torrentFile.BitField.PercentComplete;
			
			//if (model.IterHasChild(iter))
			//	(cell as Gtk.CellRendererProgress).Visible = false;
			//else
			//	(cell as Gtk.CellRendererProgress).Visible = true;
		}
		
		/*
		public bool PathLookup(out TreeIter iter, string path)
		{
			TreeIter currentIter;
			iter = TreeIter.Zero;

			if(!treeStore.GetIterFirst(out currentIter))
				return false;
			
			do{
				if(path == (string) Model.GetValue (currentIter, 0)){
					iter = currentIter;
					return true;
				}
			} while (treeStore.IterNext(ref currentIter));
			
			return false;
		}
		*/
		
	}
}