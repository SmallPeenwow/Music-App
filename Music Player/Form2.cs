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
        private int value; // Used to display if Create or Delete or Add muisc controls will be displayed and used

        List<string> dirCurrent = new List<string>(); 

        string musicFileName;

        public Form2(int value, List<string> connectDir)
        {
            InitializeComponent();
            
            string nameForm = value == 1 ? nameForm = "Create Playlist" : value == 2 ? nameForm = "Add music" : nameForm = "Delete Playlist";

            this.value = value;

            this.dirCurrent = connectDir;

            this.Text = nameForm;

            lblDisplay.Text = value == 1 ? lblDisplay.Text = "Here is where your Playlist will be created" : value == 2 ? lblDisplay.Text = "Here is where you can add the music" : lblDisplay.Text = "Select playlist from the dropdown and then press\nthe Confirm button to \"Delete\" the playlist";
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
                lblTellLength.Text = "Your Playlist needs to have more than 4 characters";
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
                //btnUpload.Enabled = false;              
                cmbSelectPlaylist.TabIndex = 1;
                cmbSelectPlaylist.DropDownStyle = ComboBoxStyle.DropDownList;
                btnConfirm.TabIndex = 2;
                btnCancel.TabIndex = 3;

                btnUpload.Visible = value == 3 ? btnUpload.Visible = false : btnUpload.Visible = true;
                lblShowDo.Text = value == 3 ? lblShowDo.Text = "" : lblShowDo.Text = "Select a Playlist first!";

                string[] fileSplits;
                
                //string[] folderName = Directory.GetDirectories(dirCurrent, "*", SearchOption.AllDirectories);
                     
                //for (int i = 0; i < folderName.Length; i++)
                //{
                //    if (folderName[i].Contains("Playlist"))
                //    {
                //        fileSplits = folderName[i].Split('\\', ':');

                //        cmbSelectPlaylist.Items.Add(fileSplits[fileSplits.Length - 1]);
                //    }
                //}                            
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string pattern = @"[A-Za-z0-9_\s][^\d]";            
            string textBoxMatch = Convert.ToString(txtPlaylist);

            Regex patternMatch = new Regex(pattern);

            if (value == 1)
            {
                if (!(patternMatch.IsMatch(textBoxMatch)) || string.IsNullOrWhiteSpace(txtPlaylist.Text) || Directory.Exists(txtPlaylist.Text))
                {
                    MessageBox.Show("Make sure you have entered in a valid Playlist name longer than 4 characters.\n\nPlaylist could already Exist.", "Not Correct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string newPath = dirCurrent + txtPlaylist.Text;
                    Directory.CreateDirectory(newPath);

                    MessageBox.Show("Playlist was Created", "Success", MessageBoxButtons.OK);
                    this.Close();
                }              
            }
            else if (value == 2)
            {
                //File.Move(fileContent, newFileLocation);
                MessageBox.Show("Song was added successfully", "Success", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                try
                {
                    DialogResult yesNo = MessageBox.Show("Are you sure you want to delete this playlist", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(DialogResult.Yes == yesNo)
                    {
                        string deletePath = dirCurrent + cmbSelectPlaylist.Text;

                        Directory.Delete(deletePath, true);
                        MessageBox.Show("Playlist was Deleted", "Success", MessageBoxButtons.OK);
                        this.Close();
                    }                
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

        // Gets the songs file path and then stores it in a textfile
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {               
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
                        //fileContent = openFile.FileName;
                        musicFileName = openFile.FileName;

                        string newFileLocation = dirCurrent + cmbSelectPlaylist.SelectedItem.ToString() + "\\" + fileSong;

                        //File.Move(fileContent, newFileLocation);
                        //MessageBox.Show("Song was added successfully", "Success", MessageBoxButtons.OK);
                        //this.Close();
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
                    //btnUpload.Enabled = true;
                    lblShowDo.Visible = false;
                }
            }            
        }
    }
}
