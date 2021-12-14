
namespace Music_Player
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
            this.playBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.pause = new System.Windows.Forms.Button();
            this.previousBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.musicListBox = new System.Windows.Forms.ListBox();
            this.ListSelecter = new System.Windows.Forms.ComboBox();
            this.playSelectlbl = new System.Windows.Forms.Label();
            this.storeOfPlayListSelect = new System.Windows.Forms.TextBox();
            this.errorDisplayMesslbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMusicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musicIndex = new System.Windows.Forms.TextBox();
            this.currentSonglbl = new System.Windows.Forms.Label();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.btnDecrease = new System.Windows.Forms.Button();
            this.lblVolumeDisplay = new System.Windows.Forms.Label();
            this.btnMute = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playBtn
            // 
            this.playBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playBtn.Location = new System.Drawing.Point(15, 134);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(100, 25);
            this.playBtn.TabIndex = 2;
            this.playBtn.Text = " Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            this.playBtn.MouseEnter += new System.EventHandler(this.CursorChange);
            this.playBtn.MouseLeave += new System.EventHandler(this.CursorBack);
            // 
            // stopBtn
            // 
            this.stopBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stopBtn.Location = new System.Drawing.Point(15, 165);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(100, 25);
            this.stopBtn.TabIndex = 3;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            this.stopBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.stopBtn.MouseEnter += new System.EventHandler(this.CursorChange);
            this.stopBtn.MouseLeave += new System.EventHandler(this.CursorBack);
            // 
            // pause
            // 
            this.pause.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pause.Location = new System.Drawing.Point(15, 196);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(100, 25);
            this.pause.TabIndex = 4;
            this.pause.Text = "Pause";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            this.pause.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.pause.MouseEnter += new System.EventHandler(this.CursorChange);
            this.pause.MouseLeave += new System.EventHandler(this.CursorBack);
            // 
            // previousBtn
            // 
            this.previousBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.previousBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.previousBtn.Location = new System.Drawing.Point(204, 350);
            this.previousBtn.Name = "previousBtn";
            this.previousBtn.Size = new System.Drawing.Size(75, 25);
            this.previousBtn.TabIndex = 6;
            this.previousBtn.Text = "Previous";
            this.previousBtn.UseVisualStyleBackColor = true;
            this.previousBtn.Click += new System.EventHandler(this.previousBtn_Click);
            this.previousBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.previousBtn.MouseEnter += new System.EventHandler(this.CursorChange);
            this.previousBtn.MouseLeave += new System.EventHandler(this.CursorBack);
            // 
            // nextBtn
            // 
            this.nextBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nextBtn.Location = new System.Drawing.Point(278, 350);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 25);
            this.nextBtn.TabIndex = 7;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            this.nextBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.nextBtn.MouseEnter += new System.EventHandler(this.CursorChange);
            this.nextBtn.MouseLeave += new System.EventHandler(this.CursorBack);
            // 
            // musicListBox
            // 
            this.musicListBox.HorizontalScrollbar = true;
            this.musicListBox.Location = new System.Drawing.Point(413, 124);
            this.musicListBox.Name = "musicListBox";
            this.musicListBox.Size = new System.Drawing.Size(255, 251);
            this.musicListBox.TabIndex = 1;
            this.musicListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.musicListBox.SelectedIndexChanged += new System.EventHandler(this.musicListBox_SelectedIndexChanged);
            this.musicListBox.MouseEnter += new System.EventHandler(this.CursorChange);
            this.musicListBox.MouseLeave += new System.EventHandler(this.CursorBack);
            // 
            // ListSelecter
            // 
            this.ListSelecter.FormattingEnabled = true;
            this.ListSelecter.Location = new System.Drawing.Point(413, 67);
            this.ListSelecter.Name = "ListSelecter";
            this.ListSelecter.Size = new System.Drawing.Size(255, 21);
            this.ListSelecter.TabIndex = 0;
            this.ListSelecter.SelectedIndexChanged += new System.EventHandler(this.ListSelecter_SelectedIndexChanged);
            this.ListSelecter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ListSelecter.MouseEnter += new System.EventHandler(this.CursorChange);
            this.ListSelecter.MouseLeave += new System.EventHandler(this.CursorBack);
            // 
            // playSelectlbl
            // 
            this.playSelectlbl.AutoSize = true;
            this.playSelectlbl.Location = new System.Drawing.Point(410, 51);
            this.playSelectlbl.Name = "playSelectlbl";
            this.playSelectlbl.Size = new System.Drawing.Size(0, 13);
            this.playSelectlbl.TabIndex = 8;
            // 
            // storeOfPlayListSelect
            // 
            this.storeOfPlayListSelect.Location = new System.Drawing.Point(413, 98);
            this.storeOfPlayListSelect.Name = "storeOfPlayListSelect";
            this.storeOfPlayListSelect.Size = new System.Drawing.Size(93, 20);
            this.storeOfPlayListSelect.TabIndex = 9;
            this.storeOfPlayListSelect.TabStop = false;
            // 
            // errorDisplayMesslbl
            // 
            this.errorDisplayMesslbl.AutoSize = true;
            this.errorDisplayMesslbl.Location = new System.Drawing.Point(125, 9);
            this.errorDisplayMesslbl.Name = "errorDisplayMesslbl";
            this.errorDisplayMesslbl.Size = new System.Drawing.Size(0, 13);
            this.errorDisplayMesslbl.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(677, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem2,
            this.settingsToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createPlaylistToolStripMenuItem,
            this.addMusicToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createPlaylistToolStripMenuItem
            // 
            this.createPlaylistToolStripMenuItem.Name = "createPlaylistToolStripMenuItem";
            this.createPlaylistToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.createPlaylistToolStripMenuItem.Text = "Create Playlist";
            this.createPlaylistToolStripMenuItem.Click += new System.EventHandler(this.createPlaylistToolStripMenuItem_Click);
            // 
            // addMusicToolStripMenuItem
            // 
            this.addMusicToolStripMenuItem.Name = "addMusicToolStripMenuItem";
            this.addMusicToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.addMusicToolStripMenuItem.Text = "Add Music";
            this.addMusicToolStripMenuItem.Click += new System.EventHandler(this.addMusicToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(113, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // musicIndex
            // 
            this.musicIndex.Location = new System.Drawing.Point(513, 98);
            this.musicIndex.Name = "musicIndex";
            this.musicIndex.Size = new System.Drawing.Size(87, 20);
            this.musicIndex.TabIndex = 12;
            this.musicIndex.TabStop = false;
            // 
            // currentSonglbl
            // 
            this.currentSonglbl.AutoSize = true;
            this.currentSonglbl.Location = new System.Drawing.Point(12, 36);
            this.currentSonglbl.Name = "currentSonglbl";
            this.currentSonglbl.Size = new System.Drawing.Size(35, 13);
            this.currentSonglbl.TabIndex = 13;
            this.currentSonglbl.Text = "label1";
            // 
            // btnIncrease
            // 
            this.btnIncrease.Location = new System.Drawing.Point(15, 285);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(100, 23);
            this.btnIncrease.TabIndex = 8;
            this.btnIncrease.Text = "Volume Up";
            this.btnIncrease.UseVisualStyleBackColor = true;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            this.btnIncrease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.btnIncrease.MouseEnter += new System.EventHandler(this.CursorChange);
            this.btnIncrease.MouseLeave += new System.EventHandler(this.CursorBack);
            // 
            // btnDecrease
            // 
            this.btnDecrease.Location = new System.Drawing.Point(15, 310);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(100, 23);
            this.btnDecrease.TabIndex = 9;
            this.btnDecrease.Text = "Volume Down";
            this.btnDecrease.UseVisualStyleBackColor = true;
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            this.btnDecrease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.btnDecrease.MouseEnter += new System.EventHandler(this.CursorChange);
            this.btnDecrease.MouseLeave += new System.EventHandler(this.CursorBack);
            // 
            // lblVolumeDisplay
            // 
            this.lblVolumeDisplay.AutoSize = true;
            this.lblVolumeDisplay.Location = new System.Drawing.Point(70, 336);
            this.lblVolumeDisplay.Name = "lblVolumeDisplay";
            this.lblVolumeDisplay.Size = new System.Drawing.Size(48, 13);
            this.lblVolumeDisplay.TabIndex = 14;
            this.lblVolumeDisplay.Text = "Volume :";
            // 
            // btnMute
            // 
            this.btnMute.Location = new System.Drawing.Point(15, 228);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(100, 23);
            this.btnMute.TabIndex = 5;
            this.btnMute.Text = "Mute";
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            this.btnMute.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.btnMute.MouseEnter += new System.EventHandler(this.CursorChange);
            this.btnMute.MouseLeave += new System.EventHandler(this.CursorBack);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 387);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.lblVolumeDisplay);
            this.Controls.Add(this.btnDecrease);
            this.Controls.Add(this.btnIncrease);
            this.Controls.Add(this.currentSonglbl);
            this.Controls.Add(this.musicIndex);
            this.Controls.Add(this.errorDisplayMesslbl);
            this.Controls.Add(this.storeOfPlayListSelect);
            this.Controls.Add(this.playSelectlbl);
            this.Controls.Add(this.ListSelecter);
            this.Controls.Add(this.musicListBox);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.previousBtn);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Our Music";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Button previousBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.ListBox musicListBox;
        private System.Windows.Forms.ComboBox ListSelecter;
        private System.Windows.Forms.Label playSelectlbl;
        private System.Windows.Forms.TextBox storeOfPlayListSelect;
        private System.Windows.Forms.Label errorDisplayMesslbl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox musicIndex;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMusicToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label currentSonglbl;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.Button btnDecrease;
        private System.Windows.Forms.Label lblVolumeDisplay;
        private System.Windows.Forms.Button btnMute;
    }
}

