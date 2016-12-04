namespace KeyLogger
{
    partial class CustomDialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomDialogForm));
            this.tblPnlAgrementForm = new System.Windows.Forms.TableLayoutPanel();
            this.bottomPnl = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rtbAgreement = new System.Windows.Forms.RichTextBox();
            this.tblPnlAgrementForm.SuspendLayout();
            this.bottomPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblPnlAgrementForm
            // 
            this.tblPnlAgrementForm.ColumnCount = 1;
            this.tblPnlAgrementForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPnlAgrementForm.Controls.Add(this.bottomPnl, 0, 1);
            this.tblPnlAgrementForm.Controls.Add(this.rtbAgreement, 0, 0);
            this.tblPnlAgrementForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPnlAgrementForm.Location = new System.Drawing.Point(0, 0);
            this.tblPnlAgrementForm.Name = "tblPnlAgrementForm";
            this.tblPnlAgrementForm.RowCount = 2;
            this.tblPnlAgrementForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblPnlAgrementForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblPnlAgrementForm.Size = new System.Drawing.Size(984, 562);
            this.tblPnlAgrementForm.TabIndex = 0;
            // 
            // bottomPnl
            // 
            this.bottomPnl.Controls.Add(this.btnOK);
            this.bottomPnl.Controls.Add(this.btnCancel);
            this.bottomPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPnl.Location = new System.Drawing.Point(3, 396);
            this.bottomPnl.Name = "bottomPnl";
            this.bottomPnl.Size = new System.Drawing.Size(978, 163);
            this.bottomPnl.TabIndex = 17;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(477, 50);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(147, 44);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Yes";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(275, 50);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 44);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "No";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rtbAgreement
            // 
            this.rtbAgreement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rtbAgreement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAgreement.Font = new System.Drawing.Font("Courier New", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbAgreement.Location = new System.Drawing.Point(92, 46);
            this.rtbAgreement.MaximumSize = new System.Drawing.Size(800, 200);
            this.rtbAgreement.MinimumSize = new System.Drawing.Size(800, 300);
            this.rtbAgreement.Name = "rtbAgreement";
            this.rtbAgreement.ReadOnly = true;
            this.rtbAgreement.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbAgreement.Size = new System.Drawing.Size(800, 300);
            this.rtbAgreement.TabIndex = 2;
            this.rtbAgreement.TabStop = false;
            this.rtbAgreement.Text = "Agreement Text";
            // 
            // CustomDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.ControlBox = false;
            this.Controls.Add(this.tblPnlAgrementForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Agreement";
            this.tblPnlAgrementForm.ResumeLayout(false);
            this.bottomPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblPnlAgrementForm;
        private System.Windows.Forms.RichTextBox rtbAgreement;
        private System.Windows.Forms.Panel bottomPnl;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}