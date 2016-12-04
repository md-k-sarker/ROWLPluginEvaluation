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
    public partial class UsabilityForm : Form
    {
        private static string question1 = "  ROWL is a useful tool to help with ontology modeling.";
        private static string question2 = "  Modeling rules with the ROWL tab was easier for me than modeling without it.";
        private static string question3 = "  Given some practice, I think I will find modeling rules with the ROWL tab easier than modeling without it.";
        private static string question4 = "  The ROWL tab is better for ontology modeling than the SWRL tab.";

        public UsabilityForm()
        {
            InitializeComponent();

            InitializeQuestions();

        }


        private  void InitializeQuestions()
        {
            this.groupBox1.Text = question1;
            this.groupBox2.Text = question2;
            this.groupBox3.Text = question3;
            this.groupBox4.Text = question4;
        }
    }
}
