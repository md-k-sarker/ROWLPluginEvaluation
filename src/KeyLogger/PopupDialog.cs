using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyLogger
{
    public partial class PopupDialog : Form
    {
        bool finished = false;

        public PopupDialog(String text, bool finished, MainForm mainForm)
        {
            InitializeComponent();

            this.rtbSuggestion.Text = text;
            this.btnOK.Focus();
            this.finished = finished;

            if (finished)
            {
                //this.btnOK.Hide();
                //this.Close();
                // this.Text = "Thank you";

                this.btnOK.Text = "Go to survey";



            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.finished)
            {
                UsabilityFormQ1 usf1 = new UsabilityFormQ1();
                usf1.Show();
            }

            this.Close();
        }
    }
}
