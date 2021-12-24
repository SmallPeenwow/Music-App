
namespace Music_Player
{
    partial class Settings
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblDisplayValid = new System.Windows.Forms.Label();
            this.cmbSelectNumber = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(121, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(13, 58);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblDisplayValid
            // 
            this.lblDisplayValid.AutoSize = true;
            this.lblDisplayValid.Location = new System.Drawing.Point(93, 6);
            this.lblDisplayValid.Name = "lblDisplayValid";
            this.lblDisplayValid.Size = new System.Drawing.Size(0, 13);
            this.lblDisplayValid.TabIndex = 3;
            this.lblDisplayValid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSelectNumber
            // 
            this.cmbSelectNumber.FormattingEnabled = true;
            this.cmbSelectNumber.Location = new System.Drawing.Point(13, 22);
            this.cmbSelectNumber.Name = "cmbSelectNumber";
            this.cmbSelectNumber.Size = new System.Drawing.Size(74, 21);
            this.cmbSelectNumber.TabIndex = 4;
            this.cmbSelectNumber.SelectedIndexChanged += new System.EventHandler(this.cmbSelectNumber_SelectedIndexChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 96);
            this.ControlBox = false;
            this.Controls.Add(this.cmbSelectNumber);
            this.Controls.Add(this.lblDisplayValid);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblDisplayValid;
        private System.Windows.Forms.ComboBox cmbSelectNumber;
    }
}