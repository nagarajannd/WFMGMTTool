using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WMSupportLibrary;

namespace WorkflowManagementTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (AlreadyRunningChecker.isApplicationRunning())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormCreateWorkFlow());
                //Application.Run(new FormExecuteWorkFlow());
                //Application.Run(new FormPreviewFlowChart());
            }
        }
    }
}
