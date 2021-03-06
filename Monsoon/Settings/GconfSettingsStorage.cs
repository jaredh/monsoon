//
// GconfSettingsStorage.cs
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
using GConf;

namespace Monsoon
{
	public class GconfSettingsStorage
	{
		private static GconfSettingsStorage instance = new GconfSettingsStorage();
		
		private GConf.Client client;
		private readonly string GCONF_APP_PATH = "/apps/monsoon/";
		private static NLog.Logger logger = MainClass.DebugEnabled ? NLog.LogManager.GetCurrentClassLogger () : new EmptyLogger ();
		
		public static GconfSettingsStorage Instance
		{
			get { return instance; }
		}
		
		private GconfSettingsStorage()
		{
			client = new GConf.Client();
		}

		public void AddListener (string path, NotifyEventHandler handler)
		{
			client.AddNotify (path, handler);
		}
		
		public void Store(string key, object val)
		{
			lock (GCONF_APP_PATH)
				client.Set(GCONF_APP_PATH + key, val);
		}

		public object Retrieve(string key)
		{
			return RetrieveAbsolute (GCONF_APP_PATH + key);
		}

		public object RetrieveAbsolute (string key)
		{
			try
			{
				lock (GCONF_APP_PATH)
					return client.Get(key);
			}
			catch (GConf.NoSuchKeyException e)
			{
				logger.Info("Key not found: " + e.Message);
				throw new SettingNotFoundException("Setting '" + key + "' cannot be found"); 
			}
		}

		public void Flush()
		{
		}
	}
}
