namespace KeyLogger
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtBxKeyClick = new System.Windows.Forms.TextBox();
            this.txtBxMouseClick = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtBxTotalClickCounter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key Click Count";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(105, 35);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Inspection";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(195, 35);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(77, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop Inspection";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtBxKeyClick
            // 
            this.txtBxKeyClick.Location = new System.Drawing.Point(151, 99);
            this.txtBxKeyClick.Name = "txtBxKeyClick";
            this.txtBxKeyClick.ReadOnly = true;
            this.txtBxKeyClick.Size = new System.Drawing.Size(67, 20);
            this.txtBxKeyClick.TabIndex = 3;
            // 
            // txtBxMouseClick
            // 
            this.txtBxMouseClick.Location = new System.Drawing.Point(151, 132);
            this.txtBxMouseClick.Name = "txtBxMouseClick";
            this.txtBxMouseClick.ReadOnly = true;
            this.txtBxMouseClick.Size = new System.Drawing.Size(67, 20);
            this.txtBxMouseClick.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mouse Click Count";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 35);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtBxTotalClickCounter
            // 
            this.txtBxTotalClickCounter.Location = new System.Drawing.Point(151, 162);
            this.txtBxTotalClickCounter.Name = "txtBxTotalClickCounter";
            this.txtBxTotalClickCounter.ReadOnly = true;
            this.txtBxTotalClickCounter.Size = new System.Drawing.Size(67, 20);
            this.txtBxTotalClickCounter.TabIndex = 8;
            this.txtBxTotalClickCounter.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total Click Count";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txtBxTotalClickCounter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtBxMouseClick);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBxKeyClick);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "KeyLogger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtBxKeyClick;
        private System.Windows.Forms.TextBox txtBxMouseClick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtBxTotalClickCounter;
        private System.Windows.Forms.Label label3;
    }
}

