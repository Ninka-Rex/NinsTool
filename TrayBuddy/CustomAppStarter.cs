using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using NinsTool;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Shell32;

namespace NinsTool
{
    internal class CustomAppStarter
    {
        [ComImport]
        [Guid("00021401-0000-0000-C000-000000000046")]
        internal class ShellLink
        {
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000214F9-0000-0000-C000-000000000046")]
        internal interface IShellLink
        {
            void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] string pszFile, int cchMaxPath, IntPtr pfd, int fFlags);
            void GetIDList(IntPtr ppidl);
            void SetIDList(IntPtr pidl);
            void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] string pszName, int cchMaxName);
            void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
            void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] string pszDir, int cchMaxPath);
            void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
            void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] string pszArgs, int cchMaxPath);
            void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
            void GetHotkey([Out] short pwHotkey);
            void SetHotkey(short wHotkey);
            void GetShowCmd([Out] int piShowCmd);
            void SetShowCmd(int iShowCmd);
            void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int cchIconPath, [Out] int piIcon);
            void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
            void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
            void Resolve(IntPtr hwnd, int fFlags);
            void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
        }
        public void startCustomApps()
        {
            string folderPath2 = @".\AutoLaunchApps";

            foreach (string shortcutPath in Directory.GetFiles(folderPath2, "*.lnk"))
            {
                string shortcutFileName2 = Path.GetFileName(shortcutPath);

                if (shortcutFileName2 != "Add shortcuts to apps you want to start automatically when SteamVR starts here!.txt")
                {
                    string shortcutPath2 = shortcutPath;

                    Shell shell = new Shell();
                    Folder folder = shell.NameSpace(System.IO.Path.GetDirectoryName(shortcutPath2));
                    FolderItem folderItem = folder.Items().Item(System.IO.Path.GetFileName(shortcutPath2));

                    // Invoke the default verb on the shortcut item
                    folderItem.InvokeVerb();

                    // Cleanup
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(folderItem);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(folder);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(shell);

                }
            }
        }

        
    }
}
