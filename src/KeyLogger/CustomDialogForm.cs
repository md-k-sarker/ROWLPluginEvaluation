using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace KeyLogger
{
    public partial class CustomDialogForm : Form
    {
        private static CustomDialogForm customDialogForm;

        private string agreeOrNotMsg = "\n\nThe information below will be logged.\n\n" +
                                "1. Number of keys pressed on the keyboard (not the key itself).\n\n" +
                                "2. Number of mouse clicks.\n\n" +
                                "3. Total of time used. \n\n\n" +
                                "Do you agree?";

        public CustomDialogForm()
        {
            InitializeComponent();
            customDialogForm = this;
            customDialogForm.rtbAgreement.Text = agreeOrNotMsg;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm mainForm = new MainForm(this);
            mainForm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Application.Exit();

            Process[] process = Process.GetProcesses();
            foreach (Process p in process)
            {
                if (p.ProcessName.StartsWith("javaw"))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Exception exception)
                    {
                        
                    }
                }

            }

            Environment.Exit(0);
        }
    }
}
