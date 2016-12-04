using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyLogger
{
    public partial class UsabilityFormQ1 : Form
    {
        private string[] questions = { "ROWL is a useful tool to help with ontology modeling.",
            "Modeling rules with the ROWL tab was easier for me than modeling without it.",
            "Given some practice, I think I will find modeling rules with the ROWL tab easier than modeling without it.",
            "The ROWL tab is better for ontology modeling than the SWRL tab." };

        private string thanksMsg = "\n        Thank you for participating the survey.\n          Do not close the Protege.";
        private string finishTxt = "Finish";

        int counter;

        private static string statFileName = "statistics.txt";

        public UsabilityFormQ1()
        {
            InitializeComponent();
            counter = 0;

            button1_Click(null, null);
        }

        //rtb1 = strongly disagree
        //rtb7 = strongly agree

        private void clearAllRadioButtons()
        {
            this.rtb1Q1.Checked = false;
            this.rtb2Q1.Checked = false;
            this.rtb3Q1.Checked = false;
            this.rtb4Q1.Checked = false;
            this.rtb5Q1.Checked = false;
            this.rtb6Q1.Checked = false;
            this.rtb7Q1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //write answers
            if (counter <= 4 && counter >= 1)
            {
                if (!isAnyoneChecked())
                {
                    //Not a single answer is checked
                    //show popup
                    AutoClosingMessageBox.Show("You have not selected any answer. Please select one. ", "", 1500);

                    return;
                }
                writeStatistics();
            }

            //clear all cradiobuttons
            clearAllRadioButtons();

            //show questions
            if (counter < 4)
            {
                this.rtbQuestions.Text = questions[counter];
                // this.groupBox1.Text = "Question " + (counter+1).ToString()+"/"+(4).ToString();

                if (counter == 3)
                {
                    this.button1.Text = finishTxt;
                }

                counter++;
            }
            else if( counter == 4)
            {
                // this.groupBox1.Text = "Thanks for Taking the survey";

                this.rtbQuestions.Text = thanksMsg ;
                this.button1.Text = "Finish";

                this.rtb1Q1.Hide();
                this.rtb2Q1.Hide();
                this.rtb3Q1.Hide();
                this.rtb4Q1.Hide();
                this.rtb5Q1.Hide();
                this.rtb6Q1.Hide();
                this.rtb7Q1.Hide();
                counter++;
            }
            else
            {
                if(this.button1.Text == "Finish" && counter == 5)
                {
                    using (StreamWriter w = File.AppendText(statFileName))
                    {
                        w.WriteLine("");
                        w.WriteLine("");
                        w.WriteLine("System closed at: " + DateTime.Now.ToLongTimeString());
                        w.WriteLine();
                        w.WriteLine();
                        
                    }
                    Environment.Exit(0);
                }
            }
        }

        private bool isAnyoneChecked()
        {
            bool choosen = false;

            if (this.rtb1Q1.Checked) choosen = true;
            else if (this.rtb2Q1.Checked) choosen = true;
            else if (this.rtb3Q1.Checked) choosen = true;
            else if (this.rtb4Q1.Checked) choosen = true;
            else if (this.rtb5Q1.Checked) choosen = true;
            else if (this.rtb6Q1.Checked) choosen = true;
            else if (this.rtb7Q1.Checked) choosen = true;

            return choosen;

        }

        private string getAnswerFromRadioButon()
        {
            String answer = "";

            if (this.rtb1Q1.Checked) answer = this.rtb1Q1.Text;
            if (this.rtb2Q1.Checked) answer = this.rtb2Q1.Text;
            if (this.rtb3Q1.Checked) answer = this.rtb3Q1.Text;
            if (this.rtb4Q1.Checked) answer = this.rtb4Q1.Text;
            if (this.rtb5Q1.Checked) answer = this.rtb5Q1.Text;
            if (this.rtb6Q1.Checked) answer = this.rtb6Q1.Text;
            if (this.rtb7Q1.Checked) answer = this.rtb7Q1.Text;

            return answer;

        }
        private void writeStatistics()
        {
            using (StreamWriter w = File.AppendText(statFileName))
            {
                if (counter == 1)
                {
                    w.WriteLine("");
                    w.WriteLine("");
                    w.WriteLine("################## Usability Question Answers###################");
                    w.WriteLine("");
                }
                w.WriteLine("Question: " + questions[counter - 1]);
                w.WriteLine("Answer: " + getAnswerFromRadioButon());
                w.WriteLine("");

            }
        }

        private void UsabilityFormQ1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
