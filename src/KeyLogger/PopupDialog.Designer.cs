namespace KeyLogger
{
    partial class PopupDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupDialog));
            this.tblPnlAgrementForm = new System.Windows.Forms.TableLayoutPanel();
            this.bottomPnl = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.rtbSuggestion = new System.Windows.Forms.RichTextBox();
            this.tblPnlAgrementForm.SuspendLayout();
            this.bottomPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblPnlAgrementForm
            // 
            this.tblPnlAgrementForm.ColumnCount = 1;
            this.tblPnlAgrementForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPnlAgrementForm.Controls.Add(this.bottomPnl, 0, 1);
            this.tblPnlAgrementForm.Controls.Add(this.rtbSuggestion, 0, 0);
            this.tblPnlAgrementForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPnlAgrementForm.Location = new System.Drawing.Point(0, 0);
            this.tblPnlAgrementForm.Name = "tblPnlAgrementForm";
            this.tblPnlAgrementForm.RowCount = 2;
            this.tblPnlAgrementForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tblPnlAgrementForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblPnlAgrementForm.Size = new System.Drawing.Size(984, 562);
            this.tblPnlAgrementForm.TabIndex = 1;
            // 
            // bottomPnl
            // 
            this.bottomPnl.Controls.Add(this.btnOK);
            this.bottomPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPnl.Location = new System.Drawing.Point(3, 452);
            this.bottomPnl.Name = "bottomPnl";
            this.bottomPnl.Size = new System.Drawing.Size(978, 107);
            this.bottomPnl.TabIndex = 17;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(400, 27);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(150, 40);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rtbSuggestion
            // 
            this.rtbSuggestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rtbSuggestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSuggestion.Font = new System.Drawing.Font("Courier New", 15.25F);
            this.rtbSuggestion.Location = new System.Drawing.Point(67, 31);
            this.rtbSuggestion.MaximumSize = new System.Drawing.Size(800, 300);
            this.rtbSuggestion.MinimumSize = new System.Drawing.Size(850, 400);
            this.rtbSuggestion.Name = "rtbSuggestion";
            this.rtbSuggestion.ReadOnly = true;
            this.rtbSuggestion.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbSuggestion.Size = new System.Drawing.Size(850, 400);
            this.rtbSuggestion.TabIndex = 3;
            this.rtbSuggestion.TabStop = false;
            this.rtbSuggestion.Text = "Suggestion Text";
            // 
            // PopupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.ControlBox = false;
            this.Controls.Add(this.tblPnlAgrementForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "PopupDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instructions";
            this.tblPnlAgrementForm.ResumeLayout(false);
            this.bottomPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblPnlAgrementForm;
        private System.Windows.Forms.Panel bottomPnl;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RichTextBox rtbSuggestion;
    }
}