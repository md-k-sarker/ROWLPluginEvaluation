using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace KeyLogger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        //private static bool checkinstancerunning()
        //{
        //    var assembly = typeof(program).assembly;
        //    var attribute = (guidattribute)assembly.getcustomattributes(typeof(guidattribute), true)[0];
        //    var appguid = attribute.value;

        //    using (system.threading.mutex mutex = new mutex(false, "global\\" + appguid))
        //    {
        //        if (!mutex.waitone(0, false))
        //        {
        //            messagebox.show("instance already running");
        //            return true;
        //        }
        //        else return false;
        //    }
        //}

        static void Main()
        {
            String processName = Process.GetCurrentProcess().ProcessName;

            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("Application "+ processName+" already running. Only one instance of this application is allowed");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CustomDialogForm customDialogForm = new CustomDialogForm();
            customDialogForm.Show();



            Application.Run();
        }
    }
}
