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
using System.Net;
using System.Net.Sockets;

namespace KeyLogger
{
    public partial class MainForm : Form
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
        private static MainForm form1;
        //private static string easyQsnFileName = "questionsEasy.txt";
        //private static string intmdeQsnFileName = "questionsIntermediate.txt";
        //private static string dfcltQsnFileName = "questionsDifficult.txt";
        private static string qstnFileName = "questions.txt";
        private static string sgsnFileName = "suggestions.txt";
        private static string statFileName = "statistics.txt";
        private static Questions[] questionObs = new Questions[12];
        private static OWLClassAndPropertiesSuggestion[] suggestionObs = new OWLClassAndPropertiesSuggestion[12];
        private static int currentQuestionNo;
        private static DateTime startTime;
        private static DateTime endTime;
        private static int userGroup;
        private static string noIpFound = "Local IP Address Not Found!";
        private static string goToSurveyText = "\n\nYou have completed all the questions. \n\nPlease take a minute to complete a brief survey.";
        private static string noSkipText = "\n\nModel the question according to your understanding.\nIf you press Next you will not be able to come back to this questions again. ";
        private static string doNotCloseText1 = "\n\nDo not close the Protege after you are done with modeling. \nWe need the modified ontology.";
        private static string doNotCloseText2 = "\n\nDo not close the Protege.";
        private static string globalWelcomeInstruction = "\nPlease read:" +
                                                         "\n\n1. There will be total 12 questions." +
                                                        "\nYou have to model half the questions using the ROWLTab plugin of Protege and " +
                                                         "half the questions without using the ROWLTab plugin. " +
                                                         "\nYou will be instructed accordingly." +
                                                        "\n\n2. All OWL classes and OWL properties to be used are already declared in Protege." +
                                                        "\n\n3. No skip option is provided." +
                                                        "\nIf you go to the next question you cannot come back to the previous questions." +
                                                        "\n\n4. After modeling the questions do not close the Protege.  ";
        private static string welComeSuggestionG1 = "\n\n\nPlease use only the ROWLTab plugin interface to model the first 6 questions.\n";
        private static string welComeSuggestionG2 = "\n\n\nPlease use standard Protege (without ROWLTab plugin) to model first 6 questions.";
        private static string midSuggestionG1 = "\n\n\nPlease use standard Protege (without the ROWLTab plugin) to model the 6 remaining questions.";
        private static string midSuggestionG2 = "\n\n\nPlease use ROWLTab plugin interface to model 6 remaining questions.";
        private static string toolROWLSuggestion = "Use the ROWLTab plugin for this question.";
        private static string toolProtegeSuggestion = "Use standard Protege (without the ROWLTab plugin) to model this question.";
        private static string toolROWLName = "ROWLTab Plugin";
        private static string toolProtegeName = "Standard Protege";


        //private static string finishMsg = "\n\nThank you for model the questions. \n Please give a brief survey about the the survey.";

        CustomDialogForm customDialogForm;
        PopupDialog ppd;

        public MainForm(CustomDialogForm customDialogForm)
        {
            //save instance
            this.customDialogForm = customDialogForm;

            //initialize all the visual components
            //code is inside of the MainForm.Designer.cs file
            InitializeComponent();

            //initialize questions
            InitializeQuestions();

            //initializeSuggestion
            InitializeSuggestions();

            //order questions according to group. not necessary now.
            //OrderQuestions();


            //Check user agrement
            //If agree then show questions and track clicks.
            //If not agree then 
            //      If Protege is open close Protege
            //      Safely close this program.

            // DialogResult result = MessageBox.Show(agreeOrNotMsg, "User Agreement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)

            _hookIDKey = SetHook(_procKey);
            _hookIDMouse = SetHook(_procMouse);
            form1 = this; // (Form1)Application.OpenForms[0];
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            //manually set currentQuestionNo = -1. to skip writing statistics before question 1.
            currentQuestionNo = -1;

            //showCurrentQuestion
            btnNext_Click(null, null);

        }

        //Usergroup 1 will use ROWLTab for first 6 questions and then will use bare protege for existing 6 questions
        //return ToolBox suggestion for user group.
        //zero based indexing
        private static string getToolBoxSuggestion(int qNo)
        {

            if (userGroup == 1)
            {
                if (qNo < 6) return toolROWLSuggestion;
                else return toolProtegeSuggestion;
            }
            else if (userGroup == 2)
            {
                if (qNo < 6) return toolProtegeSuggestion;
                else return toolROWLSuggestion;
            }
            else return "Blank";
        }

        //1 for ROWL
        //2 for bare Protege
        //zero based indexing
        private static string getToolName(int qNo)
        {
            if (userGroup == 1)
            {
                if (qNo < 6) return toolROWLName;
                else return toolProtegeName;
            }
            else
            {
                if (qNo < 6) return toolProtegeName;
                else return toolROWLName;
            }
        }


        private static void ShowSuggestions()
        {
            if (currentQuestionNo < 12)
            {
                form1.rtbClassAndProperties.Clear();

                if (suggestionObs[currentQuestionNo].OwlClasses.Count > 0)
                {

                    form1.rtbClassAndProperties.AppendText("OWLClasses: ");
                    int start = form1.rtbClassAndProperties.Text.IndexOf("OWLClasses:");
                    form1.rtbClassAndProperties.Select(start, ("OWLClasses::").Length);
                    form1.rtbClassAndProperties.SelectionColor = Color.Black;

                    int c = 0;

                    foreach (string eachOWLClass in suggestionObs[currentQuestionNo].OwlClasses)
                    {
                        if (c > 0)
                        {
                            form1.rtbClassAndProperties.AppendText(",");
                        }
                        form1.rtbClassAndProperties.AppendText(eachOWLClass);

                        start = form1.rtbClassAndProperties.Text.IndexOf(eachOWLClass);
                        form1.rtbClassAndProperties.Select(start, eachOWLClass.Length);

                        form1.rtbClassAndProperties.SelectionColor = Color.Green;
                        c++;
                    }
                }

                if (suggestionObs[currentQuestionNo].OwlObjectProperties.Count > 0)
                {
                    form1.rtbClassAndProperties.AppendText("\nOWLObjectproperties: ");

                    int start = form1.rtbClassAndProperties.Text.IndexOf("OWLObjectproperties:");
                    form1.rtbClassAndProperties.Select(start, ("OWLObjectproperties:").Length);
                    form1.rtbClassAndProperties.SelectionColor = Color.Black;

                    int c = 0;

                    foreach (string eachOwlObjectProperties in suggestionObs[currentQuestionNo].OwlObjectProperties)
                    {
                        if (c > 0)
                        {
                            form1.rtbClassAndProperties.AppendText(",");
                        }
                        form1.rtbClassAndProperties.AppendText(eachOwlObjectProperties);

                        start = form1.rtbClassAndProperties.Text.IndexOf(eachOwlObjectProperties);
                        form1.rtbClassAndProperties.Select(start, eachOwlObjectProperties.Length);
                        form1.rtbClassAndProperties.SelectionColor = Color.Green;
                        c++;
                    }
                }



                form1.tblLayoutPnl.Controls.Add(form1.rtbClassAndProperties, 0, 4);
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return noIpFound;
        }

        //Show Questions
        private static void ShowQuestions()
        {
            if (currentQuestionNo < 12)
            {


                form1.lblQuestionNo.Text = "Question: " + (currentQuestionNo + 1).ToString();
                form1.lblQuestion.Text = questionObs[currentQuestionNo].Question;

                //center alignment
                form1.rtbSuggestedTool.Text = getToolBoxSuggestion(currentQuestionNo);
                form1.rtbSuggestedTool.SelectAll();
                form1.rtbSuggestedTool.SelectionAlignment = HorizontalAlignment.Center;


                //change color of tool
                if (questionObs[currentQuestionNo].ModelIn == toolProtegeName)
                {
                    form1.rtbSuggestedTool.Select(13, 36);

                }
                else if (questionObs[currentQuestionNo].ModelIn == toolROWLName)
                {
                    form1.rtbSuggestedTool.Select(8, 14);
                }

                form1.rtbSuggestedTool.SelectionColor = Color.Green;

                if (currentQuestionNo == 11)
                {
                    form1.btnNext.Text = "Finish.";
                }

                if (currentQuestionNo != 11)
                {
                    form1.rtbSuggestedTool.AppendText(noSkipText);
                    form1.rtbSuggestedTool.Select(form1.rtbSuggestedTool.Text.IndexOf(noSkipText), noSkipText.Length);
                    form1.rtbSuggestedTool.SelectionColor = Color.Black;
                    form1.rtbSuggestedTool.SelectionFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }if(currentQuestionNo == 11)
                {
                    form1.rtbSuggestedTool.AppendText(doNotCloseText1);
                    form1.rtbSuggestedTool.Select(form1.rtbSuggestedTool.Text.IndexOf(doNotCloseText1), doNotCloseText1.Length);
                    form1.rtbSuggestedTool.SelectionColor = Color.Black;
                    form1.rtbSuggestedTool.SelectionFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }

            }
            else if (currentQuestionNo == 12)
            {

                PopupDialog ppd = new PopupDialog(goToSurveyText+doNotCloseText2, true, form1);
                ppd.Show();

                //UsabilityFormQ1 usf1 = new UsabilityFormQ1();
                //usf1.Show();
                form1.Close();

                // Environment.Exit(0);

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (currentQuestionNo > -1 && currentQuestionNo < 12)
            {
                endTime = DateTime.Now;
                WriteStatistics();
            }
            currentQuestionNo++;

            if (currentQuestionNo == 0)
            {
                ppd = new PopupDialog(globalWelcomeInstruction, false, form1);
                ppd.ShowDialog();

                if (userGroup == 1)  //Welcome group 1 people
                {

                    ppd = new PopupDialog(welComeSuggestionG1, false, form1);
                    ppd.ShowDialog();
                }
                else if (userGroup == 2)  //Welcome group 1 people
                {
                    ppd = new PopupDialog(welComeSuggestionG2, false, form1);
                    ppd.ShowDialog();
                }
            }


            //show popup to change tool.
            if (currentQuestionNo == 6)
            {
                if (userGroup == 1)  //used rowl already. now change to protege
                {
                    ppd = new PopupDialog(midSuggestionG1, false, form1);
                    ppd.ShowDialog();
                }
                else if (userGroup == 2)  //used protege already. now change to rowltab
                {
                    ppd = new PopupDialog(midSuggestionG2, false, form1);
                    ppd.ShowDialog();
                }
            }

            InitializeCounter();

            ShowQuestions();

            ShowSuggestions();

        }

        private TimeSpan getSpentTime()
        {
            TimeSpan t = endTime - startTime;
            return t;
        }


        //statistics will start to write as follows
        // 1,2,3,.....,12
        //rather than 
        // 0,1,2,.....,11
        private void WriteStatistics()
        {

            int qNo = currentQuestionNo + 1;

            if (qNo == 1)
            {
                using (StreamWriter w = File.AppendText(statFileName))
                {
                    w.WriteLine("System started at: " + DateTime.Now.ToLongTimeString());
                    w.WriteLine();
                    w.WriteLine();
                    w.WriteLine("################################ Ontology Questions ###############");
                }
            }

            if (qNo > 0 && qNo < 13)
            {
                using (StreamWriter w = File.AppendText(statFileName))
                {
                    w.WriteLine("Question {0}: " + questionObs[qNo - 1].Question, qNo);
                    w.WriteLine("Tool Used: " + questionObs[qNo - 1].ModelIn);
                    w.WriteLine("Number of mouse clicks: " + mouseClickCounter.ToString());
                    w.WriteLine("Number of keys pressed:  " + keyClickCounter.ToString());
                    TimeSpan t = getSpentTime();
                    w.WriteLine("Total of time used: {0} hour, {1} minutes, {2} seconds, {3} miliseconds.", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
                    w.WriteLine("");
                }
            }
        }

        private void InitializeCounter()
        {
            keyClickCounter = 0;
            mouseClickCounter = 0;
            totalClickCounter = 0;
            startTime = DateTime.Now;
        }

        //Initialize and set Suggestions
        private static void InitializeSuggestions()
        {

            int qCounter = 0;

            //readTxt file for questions
            List<string> __owlClasses = new List<String>();
            List<string> __owlproperties = new List<String>();

            using (StreamReader streamReader = new StreamReader(sgsnFileName))
            {
                int lc = 0;

                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();

                    if (!line.StartsWith("#") && line.Length > 1)
                    {
                        lc++;

                        if (lc == 1)
                        {
                            __owlClasses = new List<String>();
                            __owlproperties = new List<String>();
                        }
                        if (line.StartsWith("OWLClass:"))
                        {
                            //set groupNo
                            //Group 1 means will use rowltab first
                            //Group 2 means will use standard protege first
                            string _owlClasses = line.Substring(("OWLClass:").Length);

                            if (_owlClasses.Length > 1)
                            {
                                string[] owlClasses = _owlClasses.Split(',');
                                foreach (string eachOWLCLass in owlClasses)
                                {
                                    __owlClasses.Add(eachOWLCLass);
                                }

                            }
                        }
                        else if (line.StartsWith("OWLProperties:"))
                        {
                            string _owlproperties = line.Substring(("OWLProperties:").Length);

                            if (_owlproperties.Length > 1)
                            {
                                string[] owlObjectProperties = _owlproperties.Split(',');
                                foreach (string eachOWLObjectProperty in owlObjectProperties)
                                {
                                    __owlproperties.Add(eachOWLObjectProperty);
                                }
                            }
                        }
                        if (lc == 2)
                        {
                            suggestionObs[qCounter] = new OWLClassAndPropertiesSuggestion(__owlClasses, __owlproperties);
                            lc = 0;
                            qCounter++;

                            // MessageBox.Show("length: " + suggestionObs[qCounter - 1].OwlObjectProperties.Count.ToString());
                        }
                    }
                }
            }


        }


        //Initialize and set questions
        private static void InitializeQuestions()
        {

            int qCounter = 0;

            //readTxt file for questions

            using (StreamReader streamReader = new StreamReader(qstnFileName))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    if (!line.StartsWith("#") && line.Length > 1)
                    {
                        if (line.StartsWith("__Group__="))
                        {
                            //set groupNo
                            //Group 1 means will use rowltab first
                            //Group 2 means will use standard protege first
                            string group = line.Substring(10);

                            userGroup = Int32.Parse(group);
                        }
                        else
                        {
                            questionObs[qCounter] = new Questions(0, line, getToolName(qCounter));
                            qCounter++;
                        }
                    }
                }
            }
        }

        private static void OrderQuestions()
        {

        }
        //Button to start tracking manually
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_hookIDKey != null)
                UnhookWindowsHookEx(_hookIDKey);
            if (_hookIDMouse != null)
                UnhookWindowsHookEx(_hookIDMouse);

            //Set tracking handler turn On
            _hookIDKey = SetHook(_procKey);
            _hookIDMouse = SetHook(_procMouse);

            //enable and disable corresponding button
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            // form1 = (Form1)Application.OpenForms[0];
        }

        //Button to stop tracking manually
        private void btnStop_Click(object sender, EventArgs e)
        {
            //remove tracking handler
            UnhookWindowsHookEx(_hookIDKey);
            UnhookWindowsHookEx(_hookIDMouse);

            //enable and disable corresponding button
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        //Set Keyboard Hook
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        ////Set Mouse Hook
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
                // StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
                //sw.WriteLine((Keys)vkCode);
                //sw.Close();
                keyClickCounter++;
                //form1.lblStatus.Text = "Writing: " + keyClickCounter.ToString() + "th string";
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
                // StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
                //sw.WriteLine((Keys)vkCode);
                // sw.Close();
                mouseClickCounter++;
            }


            totalClickCounter = keyClickCounter + mouseClickCounter;

            form1.txtBxKeyClick.Text = keyClickCounter.ToString();
            form1.txtBxMouseClick.Text = mouseClickCounter.ToString();
            form1.txtBxTotalClickCounter.Text = totalClickCounter.ToString();

            return CallNextHookEx(_hookIDMouse, nCode, wParam, lParam);
        }

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

        //manually reset all counters
        private void btnReset_Click(object sender, EventArgs e)
        {
            //StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", false);
            //sw.Close();
            keyClickCounter = 0;
            mouseClickCounter = 0;
            totalClickCounter = 0;
            txtBxKeyClick.Text = keyClickCounter.ToString();
            txtBxMouseClick.Text = mouseClickCounter.ToString();
            txtBxTotalClickCounter.Text = totalClickCounter.ToString();
        }

        [DllImport("user32")]
        public static extern void LockWorkStation();
    }
}
