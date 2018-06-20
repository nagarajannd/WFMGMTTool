using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WMSupportLibrary
{
    public static class AlreadyRunningChecker
    {
        public static bool isApplicationRunning()
        {
            Process thisprocess = Process.GetCurrentProcess();
            if (Process.GetProcessesByName(thisprocess.ProcessName).Length > 1)
            {
                //System.Windows.Forms.MessageBox.Show("Application is already up and running!", "Workflow Management Tool",
                    //System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                foreach (Process process in Process.GetProcessesByName(thisprocess.ProcessName))
                    ActivateProcessMainWindow(process.MainWindowHandle);
                return false;
            }
            return true;
        }
        private static void ActivateProcessMainWindow(IntPtr handle)
        {
            if (handle != IntPtr.Zero)
            {
                APILibrary.ShowWindow(handle, (int)APILibrary.ShowWindowCommands.ShowNA);
                APILibrary.SetForegroundWindow(handle);
            }
        }
    }
}
