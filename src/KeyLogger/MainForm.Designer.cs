namespace KeyLogger
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblKeyClickCount = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtBxKeyClick = new System.Windows.Forms.TextBox();
            this.txtBxMouseClick = new System.Windows.Forms.TextBox();
            this.lblMouseClickCount = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtBxTotalClickCounter = new System.Windows.Forms.TextBox();
            this.lblTotalClickCount = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblQuestionNo = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tblLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.rtbClassAndProperties = new System.Windows.Forms.RichTextBox();
            this.rtbSuggestedTool = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tblLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblKeyClickCount
            // 
            this.lblKeyClickCount.AutoSize = true;
            this.lblKeyClickCount.Location = new System.Drawing.Point(272, 19);
            this.lblKeyClickCount.Name = "lblKeyClickCount";
            this.lblKeyClickCount.Size = new System.Drawing.Size(82, 13);
            this.lblKeyClickCount.TabIndex = 0;
            this.lblKeyClickCount.Text = "Key Click Count";
            this.lblKeyClickCount.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(99, 14);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Inspection";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(189, 14);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(77, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop Inspection";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtBxKeyClick
            // 
            this.txtBxKeyClick.Location = new System.Drawing.Point(382, 16);
            this.txtBxKeyClick.Name = "txtBxKeyClick";
            this.txtBxKeyClick.ReadOnly = true;
            this.txtBxKeyClick.Size = new System.Drawing.Size(67, 20);
            this.txtBxKeyClick.TabIndex = 3;
            this.txtBxKeyClick.Visible = false;
            // 
            // txtBxMouseClick
            // 
            this.txtBxMouseClick.Location = new System.Drawing.Point(566, 16);
            this.txtBxMouseClick.Name = "txtBxMouseClick";
            this.txtBxMouseClick.ReadOnly = true;
            this.txtBxMouseClick.Size = new System.Drawing.Size(67, 20);
            this.txtBxMouseClick.TabIndex = 5;
            this.txtBxMouseClick.Visible = false;
            // 
            // lblMouseClickCount
            // 
            this.lblMouseClickCount.AutoSize = true;
            this.lblMouseClickCount.Location = new System.Drawing.Point(464, 19);
            this.lblMouseClickCount.Name = "lblMouseClickCount";
            this.lblMouseClickCount.Size = new System.Drawing.Size(96, 13);
            this.lblMouseClickCount.TabIndex = 4;
            this.lblMouseClickCount.Text = "Mouse Click Count";
            this.lblMouseClickCount.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(6, 14);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtBxTotalClickCounter
            // 
            this.txtBxTotalClickCounter.Location = new System.Drawing.Point(753, 13);
            this.txtBxTotalClickCounter.Name = "txtBxTotalClickCounter";
            this.txtBxTotalClickCounter.ReadOnly = true;
            this.txtBxTotalClickCounter.Size = new System.Drawing.Size(67, 20);
            this.txtBxTotalClickCounter.TabIndex = 8;
            this.txtBxTotalClickCounter.Visible = false;
            // 
            // lblTotalClickCount
            // 
            this.lblTotalClickCount.AutoSize = true;
            this.lblTotalClickCount.Location = new System.Drawing.Point(659, 16);
            this.lblTotalClickCount.Name = "lblTotalClickCount";
            this.lblTotalClickCount.Size = new System.Drawing.Size(88, 13);
            this.lblTotalClickCount.TabIndex = 7;
            this.lblTotalClickCount.Text = "Total Click Count";
            this.lblTotalClickCount.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(860, 311);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 25);
            this.lblStatus.TabIndex = 9;
            // 
            // lblQuestionNo
            // 
            this.lblQuestionNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQuestionNo.AutoSize = true;
            this.lblQuestionNo.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionNo.Location = new System.Drawing.Point(439, 136);
            this.lblQuestionNo.Name = "lblQuestionNo";
            this.lblQuestionNo.Size = new System.Drawing.Size(106, 22);
            this.lblQuestionNo.TabIndex = 10;
            this.lblQuestionNo.Text = "Question";
            // 
            // lblQuestion
            // 
            this.lblQuestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(443, 263);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(98, 27);
            this.lblQuestion.TabIndex = 11;
            this.lblQuestion.Text = "Question";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(399, 399);
            this.btnNext.MinimumSize = new System.Drawing.Size(100, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(186, 44);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tblLayoutPnl
            // 
            this.tblLayoutPnl.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tblLayoutPnl.ColumnCount = 1;
            this.tblLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutPnl.Controls.Add(this.rtbClassAndProperties, 0, 4);
            this.tblLayoutPnl.Controls.Add(this.rtbSuggestedTool, 0, 0);
            this.tblLayoutPnl.Controls.Add(this.lblQuestionNo, 0, 1);
            this.tblLayoutPnl.Controls.Add(this.lblQuestion, 0, 2);
            this.tblLayoutPnl.Controls.Add(this.btnNext, 0, 3);
            this.tblLayoutPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblLayoutPnl.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutPnl.Name = "tblLayoutPnl";
            this.tblLayoutPnl.RowCount = 5;
            this.tblLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblLayoutPnl.Size = new System.Drawing.Size(984, 584);
            this.tblLayoutPnl.TabIndex = 16;
            // 
            // rtbClassAndProperties
            // 
            this.rtbClassAndProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbClassAndProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbClassAndProperties.Font = new System.Drawing.Font("Courier New", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbClassAndProperties.Location = new System.Drawing.Point(6, 469);
            this.rtbClassAndProperties.MinimumSize = new System.Drawing.Size(600, 45);
            this.rtbClassAndProperties.Name = "rtbClassAndProperties";
            this.rtbClassAndProperties.ReadOnly = true;
            this.rtbClassAndProperties.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbClassAndProperties.Size = new System.Drawing.Size(972, 109);
            this.rtbClassAndProperties.TabIndex = 15;
            this.rtbClassAndProperties.TabStop = false;
            this.rtbClassAndProperties.Text = "SuggestedToolText";
            // 
            // rtbSuggestedTool
            // 
            this.rtbSuggestedTool.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rtbSuggestedTool.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSuggestedTool.Font = new System.Drawing.Font("Courier New", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSuggestedTool.Location = new System.Drawing.Point(192, 9);
            this.rtbSuggestedTool.MinimumSize = new System.Drawing.Size(600, 45);
            this.rtbSuggestedTool.Name = "rtbSuggestedTool";
            this.rtbSuggestedTool.ReadOnly = true;
            this.rtbSuggestedTool.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbSuggestedTool.Size = new System.Drawing.Size(600, 100);
            this.rtbSuggestedTool.TabIndex = 14;
            this.rtbSuggestedTool.TabStop = false;
            this.rtbSuggestedTool.Text = "SuggestedToolText";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(984, 584);
            this.ControlBox = false;
            this.Controls.Add(this.tblLayoutPnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Questions";
            this.tblLayoutPnl.ResumeLayout(false);
            this.tblLayoutPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblKeyClickCount;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtBxKeyClick;
        private System.Windows.Forms.TextBox txtBxMouseClick;
        private System.Windows.Forms.Label lblMouseClickCount;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtBxTotalClickCounter;
        private System.Windows.Forms.Label lblTotalClickCount;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblQuestionNo;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TableLayoutPanel tblLayoutPnl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtbSuggestedTool;
        private System.Windows.Forms.RichTextBox rtbClassAndProperties;
    }
}

