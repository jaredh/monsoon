// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Monsoon {
    
    
    public partial class LoadTorrentDialog {
        
        private Gtk.VBox vbox4;
        
        private Gtk.Frame frame3;
        
        private Gtk.Alignment GtkAlignment2;
        
        private Gtk.VBox vbox5;
        
        private Gtk.HBox hbox5;
        
        private Gtk.FileChooserButton fileChooser;
        
        private Gtk.Table table1;
        
        private Gtk.Label label2;
        
        private Gtk.Label label3;
        
        private Gtk.Label lblName;
        
        private Gtk.Label lblSize;
        
        private Gtk.Label GtkLabel2;
        
        private Gtk.Expander expander1;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TreeView torrentTreeView;
        
        private Gtk.Label GtkLabel1;
        
        private Gtk.CheckButton checkbutton2;
        
        private Gtk.Button buttonCancel;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget Monsoon.LoadTorrentDialog
            this.Name = "Monsoon.LoadTorrentDialog";
            this.Title = Mono.Unix.Catalog.GetString("Load torrent");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            // Internal child Monsoon.LoadTorrentDialog.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox4 = new Gtk.VBox();
            this.vbox4.Name = "vbox4";
            this.vbox4.Spacing = 6;
            // Container child vbox4.Gtk.Box+BoxChild
            this.frame3 = new Gtk.Frame();
            this.frame3.Name = "frame3";
            this.frame3.ShadowType = ((Gtk.ShadowType)(0));
            // Container child frame3.Gtk.Container+ContainerChild
            this.GtkAlignment2 = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment2.Name = "GtkAlignment2";
            this.GtkAlignment2.LeftPadding = ((uint)(12));
            // Container child GtkAlignment2.Gtk.Container+ContainerChild
            this.vbox5 = new Gtk.VBox();
            this.vbox5.Name = "vbox5";
            this.vbox5.Spacing = 6;
            // Container child vbox5.Gtk.Box+BoxChild
            this.hbox5 = new Gtk.HBox();
            this.hbox5.Name = "hbox5";
            this.hbox5.Spacing = 6;
            // Container child hbox5.Gtk.Box+BoxChild
            this.fileChooser = new Gtk.FileChooserButton(Mono.Unix.Catalog.GetString("Select A Folder"), ((Gtk.FileChooserAction)(2)));
            this.fileChooser.Name = "fileChooser";
            this.fileChooser.ShowHidden = true;
            this.hbox5.Add(this.fileChooser);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox5[this.fileChooser]));
            w2.Position = 0;
            this.vbox5.Add(this.hbox5);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox5[this.hbox5]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.table1 = new Gtk.Table(((uint)(2)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            // Container child table1.Gtk.Table+TableChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.Xalign = 0F;
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Name:");
            this.table1.Add(this.label2);
            Gtk.Table.TableChild w4 = ((Gtk.Table.TableChild)(this.table1[this.label2]));
            w4.XOptions = ((Gtk.AttachOptions)(4));
            w4.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.Xalign = 0F;
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("Size:");
            this.table1.Add(this.label3);
            Gtk.Table.TableChild w5 = ((Gtk.Table.TableChild)(this.table1[this.label3]));
            w5.TopAttach = ((uint)(1));
            w5.BottomAttach = ((uint)(2));
            w5.XOptions = ((Gtk.AttachOptions)(4));
            w5.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.lblName = new Gtk.Label();
            this.lblName.Name = "lblName";
            this.lblName.Xalign = 0F;
            this.lblName.LabelProp = Mono.Unix.Catalog.GetString("Suse-11.0-i386.iso");
            this.table1.Add(this.lblName);
            Gtk.Table.TableChild w6 = ((Gtk.Table.TableChild)(this.table1[this.lblName]));
            w6.LeftAttach = ((uint)(1));
            w6.RightAttach = ((uint)(2));
            w6.XOptions = ((Gtk.AttachOptions)(4));
            w6.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.lblSize = new Gtk.Label();
            this.lblSize.Name = "lblSize";
            this.lblSize.Xalign = 0F;
            this.lblSize.LabelProp = Mono.Unix.Catalog.GetString("700MB");
            this.table1.Add(this.lblSize);
            Gtk.Table.TableChild w7 = ((Gtk.Table.TableChild)(this.table1[this.lblSize]));
            w7.TopAttach = ((uint)(1));
            w7.BottomAttach = ((uint)(2));
            w7.LeftAttach = ((uint)(1));
            w7.RightAttach = ((uint)(2));
            w7.XOptions = ((Gtk.AttachOptions)(4));
            w7.YOptions = ((Gtk.AttachOptions)(4));
            this.vbox5.Add(this.table1);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox5[this.table1]));
            w8.Position = 1;
            w8.Expand = false;
            w8.Fill = false;
            this.GtkAlignment2.Add(this.vbox5);
            this.frame3.Add(this.GtkAlignment2);
            this.GtkLabel2 = new Gtk.Label();
            this.GtkLabel2.Name = "GtkLabel2";
            this.GtkLabel2.LabelProp = Mono.Unix.Catalog.GetString("<b>Save</b>");
            this.GtkLabel2.UseMarkup = true;
            this.frame3.LabelWidget = this.GtkLabel2;
            this.vbox4.Add(this.frame3);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.vbox4[this.frame3]));
            w11.Position = 0;
            w11.Expand = false;
            w11.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.expander1 = new Gtk.Expander(null);
            this.expander1.CanFocus = true;
            this.expander1.Name = "expander1";
            this.expander1.Expanded = true;
            // Container child expander1.Gtk.Container+ContainerChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.torrentTreeView = new Gtk.TreeView();
            this.torrentTreeView.CanFocus = true;
            this.torrentTreeView.Name = "torrentTreeView";
            this.GtkScrolledWindow.Add(this.torrentTreeView);
            this.expander1.Add(this.GtkScrolledWindow);
            this.GtkLabel1 = new Gtk.Label();
            this.GtkLabel1.Name = "GtkLabel1";
            this.GtkLabel1.LabelProp = Mono.Unix.Catalog.GetString("Files");
            this.GtkLabel1.UseUnderline = true;
            this.expander1.LabelWidget = this.GtkLabel1;
            this.vbox4.Add(this.expander1);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.vbox4[this.expander1]));
            w14.Position = 1;
            // Container child vbox4.Gtk.Box+BoxChild
            this.checkbutton2 = new Gtk.CheckButton();
            this.checkbutton2.CanFocus = true;
            this.checkbutton2.Name = "checkbutton2";
            this.checkbutton2.Label = Mono.Unix.Catalog.GetString("Always show this dialog");
            this.checkbutton2.Active = true;
            this.checkbutton2.DrawIndicator = true;
            this.checkbutton2.UseUnderline = true;
            this.vbox4.Add(this.checkbutton2);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox4[this.checkbutton2]));
            w15.Position = 2;
            w15.Expand = false;
            w15.Fill = false;
            w1.Add(this.vbox4);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(w1[this.vbox4]));
            w16.Position = 0;
            // Internal child Monsoon.LoadTorrentDialog.ActionArea
            Gtk.HButtonBox w17 = this.ActionArea;
            w17.Name = "dialog1_ActionArea";
            w17.Spacing = 6;
            w17.BorderWidth = ((uint)(5));
            w17.LayoutStyle = ((Gtk.ButtonBoxStyle)(4));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonCancel = new Gtk.Button();
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseStock = true;
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.buttonCancel, -6);
            Gtk.ButtonBox.ButtonBoxChild w18 = ((Gtk.ButtonBox.ButtonBoxChild)(w17[this.buttonCancel]));
            w18.Expand = false;
            w18.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            this.AddActionWidget(this.buttonOk, -5);
            Gtk.ButtonBox.ButtonBoxChild w19 = ((Gtk.ButtonBox.ButtonBoxChild)(w17[this.buttonOk]));
            w19.Position = 1;
            w19.Expand = false;
            w19.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 400;
            this.DefaultHeight = 474;
            this.Show();
        }
    }
}
