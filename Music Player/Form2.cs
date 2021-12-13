﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Music_Player
{
    public partial class Form2 : Form
    {
        private int value;

        public Form2(int value)
        {
            InitializeComponent();

            string nameForm = value == 1 ? nameForm = "Create Playlist" : nameForm = "Add music";

            this.value = value;

            this.Text = nameForm;

            lblDisplay.Text = value == 1 ? lblDisplay.Text = "The word Playlist will be added onto the end of the Playlist made" : lblDisplay.Text = "Here is where you can add the music";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtPlaylist.MaxLength = 50;
            btnConfirm.Enabled = false;
           
            if(value == 1)
            {
                btnUpload.Enabled = false;
                btnUpload.Visible = false;
                btnUpload.TabStop = false;
                lblTellLength.Text = "Your Playlist needs to have more the 4 characters";
                lblShowDo.Visible = false;
                cmbSelectPlaylist.Enabled = false;
                cmbSelectPlaylist.Visible = false;
                cmbSelectPlaylist.TabStop = false;
            }
            else
            {
                txtPlaylist.Enabled = false;
                txtPlaylist.Visible = false;
                txtPlaylist.TabStop = false;
                btnUpload.TabIndex = 0;
                lblTellLength.Visible = false;
                btnUpload.Enabled = false;
                lblShowDo.Text = "Select a Playlist first!";
                cmbSelectPlaylist.TabIndex = 1;
                cmbSelectPlaylist.DropDownStyle = ComboBoxStyle.DropDownList;
                btnConfirm.TabIndex = 2;
                btnCancel.TabIndex = 3;

                string[] fileSplits;

                string[] folderName = Directory.GetDirectories(@"C:\Music App\Music Playlists", "*", SearchOption.AllDirectories);

                for (int i = 0; i < folderName.Length; i++)
                {
                    if (folderName[i].Contains("Playlist"))
                    {
                        fileSplits = folderName[i].Split(' ', '\\', ':');

                        cmbSelectPlaylist.Items.Add(fileSplits[fileSplits.Length - 2]);
                    }
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtPlaylist.Text) || Directory.Exists(txtPlaylist.Text)) // !(txtPlaylist.Text.Contains("Playlist")) Could do this
            {
                MessageBox.Show("Make sure you have entered in a valid Playlist name longer than 3 characters\n\nPlaylist could already Exist", "Not Correct", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(value == 1)
            {
                string newPath = @"C:\Music App\Music Playlists\" + txtPlaylist.Text + " Playlist";

                Directory.CreateDirectory(newPath);

                MessageBox.Show("Playlist was created", "Success", MessageBoxButtons.OK);
                this.Close();
            }        
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPlaylist_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPlaylist.TextLength > 4)
            {
                btnConfirm.Enabled = true;
                lblTellLength.Visible = false;
            }
            else
            {
                btnConfirm.Enabled = false;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string fileContent;

                OpenFileDialog openFile = new OpenFileDialog();
                //SaveFileDialog openFile = new SaveFileDialog();

                string filePath = Environment.SpecialFolder.UserProfile + "\\Downloads";
                openFile.InitialDirectory = filePath;
                openFile.Title = "Add Song";
                openFile.Filter = "Music(.mp3)|*.mp3";
                openFile.RestoreDirectory = true;

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string newFileLocation = @"C:\Music App\Music Playlists\" + cmbSelectPlaylist.SelectedItem.ToString() + " Playlist";

                    //fileContent = openFile.FileName.Split('\\').Last();
                    fileContent = openFile.FileName;

                    string dest = Path.Combine(newFileLocation, fileContent);
                    

                    File.Copy(fileContent, newFileLocation);
                    //Directory.Move(fileContent, newFileLocation);
                    

                    //string tempPath = Path.Combine(newFileLocation, fileContent);
                    //File.Copy(newFileLocation, tempPath);

                    

                    MessageBox.Show("Song was added successfully", "Success", MessageBoxButtons.OK);
                }
                           
                //this.Close();
            }
            catch (Exception fileOpenError)
            {
                MessageBox.Show("failed " + fileOpenError, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void cmbSelectPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectPlaylist.SelectedItem != null)
            {
                btnUpload.Enabled = true;
                lblShowDo.Visible = false;
            }
        }
    }
}
