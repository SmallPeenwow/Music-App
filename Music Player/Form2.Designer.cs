
namespace Music_Player
{
    partial class Form2
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
            this.txtPlaylist = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.lblTellLength = new System.Windows.Forms.Label();
            this.cmbSelectPlaylist = new System.Windows.Forms.ComboBox();
            this.lblShowDo = new System.Windows.Forms.Label();
            this.lstMusicDisplay = new System.Windows.Forms.ListBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lblSelectFolder = new System.Windows.Forms.Label();
            this.lblDefaultLocation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPlaylist
            // 
            this.txtPlaylist.Location = new System.Drawing.Point(13, 20);
            this.txtPlaylist.Name = "txtPlaylist";
            this.txtPlaylist.Size = new System.Drawing.Size(147, 20);
            this.txtPlaylist.TabIndex = 0;
            this.txtPlaylist.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPlaylist_KeyUp);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(12, 126);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(99, 29);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(120, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Location = new System.Drawing.Point(12, 8);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(35, 13);
            this.lblDisplay.TabIndex = 4;
            this.lblDisplay.Text = "label1";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(11, 27);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(99, 23);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lblTellLength
            // 
            this.lblTellLength.AutoSize = true;
            this.lblTellLength.Location = new System.Drawing.Point(9, 4);
            this.lblTellLength.Name = "lblTellLength";
            this.lblTellLength.Size = new System.Drawing.Size(67, 13);
            this.lblTellLength.TabIndex = 6;
            this.lblTellLength.Text = "lengthCheck";
            // 
            // cmbSelectPlaylist
            // 
            this.cmbSelectPlaylist.FormattingEnabled = true;
            this.cmbSelectPlaylist.Location = new System.Drawing.Point(12, 56);
            this.cmbSelectPlaylist.Name = "cmbSelectPlaylist";
            this.cmbSelectPlaylist.Size = new System.Drawing.Size(148, 21);
            this.cmbSelectPlaylist.TabIndex = 7;
            this.cmbSelectPlaylist.SelectedIndexChanged += new System.EventHandler(this.cmbSelectPlaylist_SelectedIndexChanged);
            // 
            // lblShowDo
            // 
            this.lblShowDo.AutoSize = true;
            this.lblShowDo.Location = new System.Drawing.Point(117, 27);
            this.lblShowDo.Name = "lblShowDo";
            this.lblShowDo.Size = new System.Drawing.Size(35, 13);
            this.lblShowDo.TabIndex = 8;
            this.lblShowDo.Text = "label3";
            // 
            // lstMusicDisplay
            // 
            this.lstMusicDisplay.FormattingEnabled = true;
            this.lstMusicDisplay.HorizontalScrollbar = true;
            this.lstMusicDisplay.Location = new System.Drawing.Point(237, 8);
            this.lstMusicDisplay.Name = "lstMusicDisplay";
            this.lstMusicDisplay.Size = new System.Drawing.Size(130, 147);
            this.lstMusicDisplay.TabIndex = 9;
            this.lstMusicDisplay.TabStop = false;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(12, 80);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(99, 30);
            this.btnSelectFolder.TabIndex = 10;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lblSelectFolder
            // 
            this.lblSelectFolder.AutoSize = true;
            this.lblSelectFolder.Location = new System.Drawing.Point(111, 80);
            this.lblSelectFolder.Name = "lblSelectFolder";
            this.lblSelectFolder.Size = new System.Drawing.Size(109, 13);
            this.lblSelectFolder.TabIndex = 11;
            this.lblSelectFolder.Text = "select folder message";
            // 
            // lblDefaultLocation
            // 
            this.lblDefaultLocation.AutoSize = true;
            this.lblDefaultLocation.Location = new System.Drawing.Point(10, 43);
            this.lblDefaultLocation.Name = "lblDefaultLocation";
            this.lblDefaultLocation.Size = new System.Drawing.Size(95, 13);
            this.lblDefaultLocation.TabIndex = 12;
            this.lblDefaultLocation.Text = "tell default location";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(369, 160);
            this.ControlBox = false;
            this.Controls.Add(this.lblDefaultLocation);
            this.Controls.Add(this.lblSelectFolder);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.lstMusicDisplay);
            this.Controls.Add(this.lblShowDo);
            this.Controls.Add(this.cmbSelectPlaylist);
            this.Controls.Add(this.lblTellLength);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lblDisplay);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtPlaylist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(280, 400);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlaylist;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label lblTellLength;
        private System.Windows.Forms.ComboBox cmbSelectPlaylist;
        private System.Windows.Forms.Label lblShowDo;
        private System.Windows.Forms.ListBox lstMusicDisplay;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Label lblSelectFolder;
        private System.Windows.Forms.Label lblDefaultLocation;
    }
}