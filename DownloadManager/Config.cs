﻿using System;
using Microsoft.Win32;

namespace DownloadManager
{
    public static class Config
    {
        const string LocalHostNameKey = "AfekaTorrentLocalHostName";
        const string LocalPortKey = "AfekaTorrentLocalPort";
        const string SharedFolderNameKey = "SharedFolderName ";

        public static string LocalHostyName
        {
            get
            {
                //var localHostName = Registry.CurrentUser.GetValue(FreeFileLocalHostNameKey);
                var localHostName = Registry.CurrentUser.GetValue(LocalHostNameKey);
                string hostname = string.Empty;
                if (localHostName == null)
                {
                    hostname = Guid.NewGuid().ToString().Replace("-", "");
                    Registry.CurrentUser.SetValue(LocalHostNameKey, hostname);
                }
                else
                {
                    hostname = localHostName.ToString();
                }
                return hostname;
            }
        }

        public static string SharedFolder
        {
            get
            {
                var sharedFolderName = Registry.CurrentUser.GetValue(SharedFolderNameKey);
                string folder = string.Empty;
                if (sharedFolderName == null)
                {
                    folder = @"C:\FreeFileDirectory"; ;
                    Registry.CurrentUser.SetValue(SharedFolderNameKey, folder);
                }
                else
                {
                    folder = sharedFolderName.ToString();
                }
                return folder;
            }
        }

        public static int LocalPort
        {
            get
            {
                var localPort = Registry.CurrentUser.GetValue(LocalPortKey);
                int port = 20388;
                if (localPort == null)
                {
                    Registry.CurrentUser.SetValue(LocalPortKey, port);
                }
                return port;
            }
        }
    }
}
