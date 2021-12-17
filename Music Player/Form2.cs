using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Music_Player
{
    public partial class Form2 : Form
    {
        private int value;

        public Form2(int value)
        {
            InitializeComponent();
            
            string nameForm = value == 1 ? nameForm = "Create Playlist" : value == 2 ? nameForm = "Add music" : nameForm = "Delete Playlist";

            this.value = value;

            this.Text = nameForm;

            lblDisplay.Text = value == 1 ? lblDisplay.Text = "The word Playlist will be added onto the end of the Playlist made" : value == 2 ? lblDisplay.Text = "Here is where you can add the music" : lblDisplay.Text = "Select playlist from the dropdown and then press\nthe Confirm button to \"Delete\" the playlist";
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
                cmbSelectPlaylist.TabIndex = 1;
                cmbSelectPlaylist.DropDownStyle = ComboBoxStyle.DropDownList;
                btnConfirm.TabIndex = 2;
                btnCancel.TabIndex = 3;

                btnUpload.Visible = value == 3 ? btnUpload.Visible = false : btnUpload.Visible = true;
                lblShowDo.Text = value == 3 ? lblShowDo.Text = "" : lblShowDo.Text = "Select a Playlist first!";

                string[] fileSplits;

                string[] folderName = Directory.GetDirectories(@"C:\Music App\Music Player\Music Playlists", "*", SearchOption.AllDirectories);

                for (int i = 0; i < folderName.Length; i++)
                {
                    if (folderName[i].Contains("Playlist"))
                    {
                        fileSplits = folderName[i].Split('\\', ':');

                        cmbSelectPlaylist.Items.Add(fileSplits[fileSplits.Length - 1]);
                    }
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string pattern = @"[A-Za-z0-9_\s][^\d]";            
            string textBoxMatch = Convert.ToString(txtPlaylist);

            Regex patternMatch = new Regex(pattern);

            if (value == 1)
            {
                if (patternMatch.IsMatch(textBoxMatch) || string.IsNullOrWhiteSpace(txtPlaylist.Text) || Directory.Exists(txtPlaylist.Text)) // !(txtPlaylist.Text.Contains("Playlist")) Could do this
                {
                    MessageBox.Show("Make sure you have entered in a valid Playlist name longer than 3 characters.\n\nPlaylist could already Exist.", "Not Correct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string newPath = @"C:\Music App\Music Player\Music Playlists\" + txtPlaylist.Text + " Playlist";

                    Directory.CreateDirectory(newPath);

                    MessageBox.Show("Playlist was Created", "Success", MessageBoxButtons.OK);
                    this.Close();
                }              
            }
            else
            {
                try
                {
                    string deletePath = @"C:\Music App\Music Player\Music Playlists\" + cmbSelectPlaylist.Text;

                    Directory.Delete(deletePath, true);
                    MessageBox.Show("Playlist was Deleted", "Success", MessageBoxButtons.OK);
                }
                catch(Exception error)
                {
                    MessageBox.Show("failed " + error);
                }              
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
                lblTellLength.Visible = true;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string fileContent;
                OpenFileDialog openFile = new OpenFileDialog();

                string filePath = Environment.SpecialFolder.UserProfile + "\\Downloads";
                openFile.InitialDirectory = filePath;
                openFile.Title = "Add Song";
                openFile.Filter = "Music(.mp3)|*.mp3";

                if (openFile.ShowDialog() == DialogResult.OK)
                {                   
                    string fileSong = openFile.FileName.Split('\\').Last();

                    if (fileSong.Contains(".mp3"))
                    {
                        fileContent = openFile.FileName;

                        string newFileLocation = @"C:\Music App\Music Player\Music Playlists\" + cmbSelectPlaylist.SelectedItem.ToString() + "\\" + fileSong;

                        File.Move(fileContent, newFileLocation);
                        MessageBox.Show("Song was added successfully", "Success", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Select a Song that is a  \"mp3\"", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }                                         
            }
            catch (Exception fileOpenError)
            {
                MessageBox.Show("failed " + fileOpenError, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void cmbSelectPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (value == 3)
            {
                btnConfirm.Enabled = cmbSelectPlaylist.SelectedIndex != -1 ? btnConfirm.Enabled = true : btnConfirm.Enabled = false;
            }
            else
            {
                if (cmbSelectPlaylist.SelectedItem != null)
                {
                    btnUpload.Enabled = true;
                    lblShowDo.Visible = false;
                }
            }            
        }
    }
}
