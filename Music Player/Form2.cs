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

        Dictionary<string, string> musicFileName = new Dictionary<string, string>(); // Will store the Path of the music and music name

        string playlistFolder = ""; // Used to store the path to the Select Folder 

        string copyToFolderPath; // Used to store the playlist path

        public Form2(int value, List<string> connectDir)
        {
            InitializeComponent();
            
            string nameForm = value == 1 ? nameForm = "Create Playlist" : value == 2 ? nameForm = "Add music" : nameForm = "Delete Playlist";

            this.value = value;

            this.dirCurrent = connectDir;

            this.Text = nameForm;

            //lblDisplay.Text = value == 1 ? lblDisplay.Text = "Here is where your Playlist will be created" : value == 2 ? lblDisplay.Text = "Here is where you can add the music" : lblDisplay.Text = "Select playlist from the dropdown and then press\nthe Confirm button to \"Delete\" the playlist";
            lblDisplay.Text = value == 1 ? lblDisplay.Text = "" : value == 2 ? lblDisplay.Text = "" : lblDisplay.Text = "Select playlist from the dropdown and then press\nthe Confirm button to \"Delete\" the playlist";
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
                lstMusicDisplay.Visible = false;
                lstMusicDisplay.Enabled = false;
                lblSelectFolder.Text = "";
                lblDefaultLocation.Text = "By not selecting a folder your Playlist will be given\n the default location in your Music folder";
                txtPlaylist.TabIndex = 0;
                btnSelectFolder.TabIndex = 1;
                btnConfirm.TabIndex = 2;
                btnCancel.TabIndex = 3;

                this.Size = new Size(280, 199);
            }
            else if(value == 2)
            {
                btnSelectFolder.Enabled = false;
                btnSelectFolder.Visible = false;
                lblDefaultLocation.Visible = false;
                lblSelectFolder.Visible = false;
                lblTellLength.Text = "Pressing the Upload button will get the\nmusic you want stored into your playlist";
                lblTellLength.Location = new Point(11, 1);
                txtPlaylist.Visible = false;
                txtPlaylist.Enabled = false;
                btnUpload.TabIndex = 0;
                cmbSelectPlaylist.TabIndex = 1;
                lblShowDo.Text = "Select a Playlist from the drop that you wish to\nadd your music to";
                lblShowDo.Location = new Point(10, 58);
                btnConfirm.TabIndex = 2;
                btnConfirm.Enabled = false;
                btnCancel.TabIndex = 3;
                cmbSelectPlaylist.DropDownStyle = ComboBoxStyle.DropDownList;
                lstMusicDisplay.SelectionMode = SelectionMode.One;

                LoadComboBox();
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

                LoadComboBox();

                //string[] fileSplits;

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

        // used to populate the combobox
        private void LoadComboBox()
        {
            HashSet<string> playlistDisplay = new HashSet<string>();

            string[] addToHash;

            for(int i = 0; i < dirCurrent.Count; i++)
            {
                addToHash = dirCurrent[i].Split('\\', ':');

                if (dirCurrent[i].Contains(".mp3"))
                {                    
                    playlistDisplay.Add(addToHash[addToHash.Length - 2]);
                }
                else
                {
                    playlistDisplay.Add(addToHash[addToHash.Length - 1]);
                }
            }

            for(int x = 0; x < playlistDisplay.Count; x++)
            {
                cmbSelectPlaylist.Items.Add(playlistDisplay.ElementAt(x));
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string pattern = @"[A-Za-z0-9_\s][^\d]";            
            string textBoxMatch = Convert.ToString(txtPlaylist);

            Regex patternMatch = new Regex(pattern);

            if (value == 1)
            {
                string alertError = "";
                bool checkFailed = false;

                // Checks which one has thrown the error and then gives it number to give the right message to display
                int numberCheckFalse = !patternMatch.IsMatch(textBoxMatch) ? numberCheckFalse = 1 : string.IsNullOrWhiteSpace(txtPlaylist.Text) ? numberCheckFalse = 2 : numberCheckFalse = 0;

                alertError = numberCheckFalse == 1 ? alertError = "Enter in a Valid Playlist name longer than 4 characters" : numberCheckFalse == 2 ? alertError = "Pressing the spacebar 5 times is not a valid Playlist name" : alertError = "true";

                try
                {
                    checkFailed = Convert.ToBoolean(alertError);
                }
                catch
                {
                    // if chechFailed couldn't convert to true it would be false still and then display the correct error message
                }

                if (checkFailed != true) // Checks which error message will be displayed
                {
                    MessageBox.Show(alertError, "Not Correct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(playlistFolder == "")
                {
                    DialogResult makeSureFolder = MessageBox.Show("You will be adding your Playlist to the default loaction on your PC which will be the Music folder", "Create Playlist", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if(makeSureFolder == DialogResult.Yes)
                    {
                        playlistFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);// Gets default location which is the user Music Folder
                        
                        CreatePlaylist(playlistFolder);
                    }
                }
                else
                {
                    CreatePlaylist(playlistFolder);
                }
            }
            else if (value == 2)
            {   
                if(lstMusicDisplay.Items.Count != -1) // Copies the music over to the Playlist selected
                {
                    for (int i = 0; i < lstMusicDisplay.Items.Count; i++)
                    {
                        KeyValuePair<string, string> muiscPath = musicFileName.ElementAt(i);
                        string sendCopyOfMuisc = muiscPath.Key; // Path fo the music
                        string musicCopyName = muiscPath.Value; // music name

                        string newFileLocation = copyToFolderPath + "\\" + musicCopyName + ".mp3"; // Combines music to new path location

                        File.Copy(sendCopyOfMuisc, newFileLocation);
                    }
                    MessageBox.Show("Music was added successfully", "Add Music", MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No music has been select to go into the playlist", "Add Muisc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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

        private void CreatePlaylist(string folderName) // Will Create the playlist in the specified location
        {
            string newPath = folderName + "\\" + txtPlaylist.Text;

            if (!Directory.Exists(newPath))
            {               
                WriteToTextFile(newPath);
           
                Directory.CreateDirectory(newPath); // Creates the Folder loaction

                MessageBox.Show("Playlist was Created", "Success", MessageBoxButtons.OK);
                this.Close();                                                          
            }
            else
            {
                MessageBox.Show("The Folder in which you are storing the Playlist already exists", "Create Playlist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }

        private void WriteToTextFile(string urlPath)// Will store the Url Path of the folder
        {
            string pathSearch = Directory.GetCurrentDirectory();
            string cutEndpath = "Music Player";
            int indexOfBinPath = pathSearch.IndexOf(cutEndpath); // Gets the index of where the cut off for the URL begins

            string pathFiletext = pathSearch.Substring(0, indexOfBinPath);
            string[] getfile = Directory.GetFiles(pathFiletext, "PlaylistAndSong*", SearchOption.AllDirectories); // Gest the textfile location named PlaylistAndSong

            using (StreamWriter writeUrlPath = File.AppendText(getfile[0]))
            {
                writeUrlPath.WriteLine(urlPath);
                writeUrlPath.Close();
                writeUrlPath.Dispose();
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
               
                string filePath = Environment.SpecialFolder.UserProfile + "\\Downloads"; // Add ToString() might work
                openFile.Title = "Add Song";
                openFile.Filter = "Music(.mp3)|*.mp3";
                openFile.Multiselect = true;

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string[] fileSong = openFile.FileNames;

                    for(int i = 0; i < fileSong.Length; i++)
                    {
                        string musicName = fileSong[i].Split('\\').Last().Replace(".mp3", "");

                        lstMusicDisplay.Items.Add(musicName);

                        musicFileName.Add(fileSong[i], musicName);
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
                    for(int i = 0; i < dirCurrent.Count; i++)
                    {
                        if (dirCurrent[i].Contains(cmbSelectPlaylist.SelectedItem.ToString()))
                        {
                            copyToFolderPath = dirCurrent.ElementAt(i);
                            break;
                        }
                    }
                    lblShowDo.Visible = false;
                    btnConfirm.Enabled = true;
                }
            }            
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)// Gets the Location for in Which the user wants to create their Playlist
        {
            FolderBrowserDialog browserFolders = new FolderBrowserDialog();

            browserFolders.Description = "Select Folder";

            if(browserFolders.ShowDialog() == DialogResult.OK) // Lets you select which folder to store your playlist in
            {
                playlistFolder = browserFolders.SelectedPath;
                lblDefaultLocation.Text = "";
                lblSelectFolder.Text = "Your Playlist will be stored\n in the folder of your choice";
            }
        }

        private void lstMusicDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMusicDisplay.SelectedIndex != -1)
            {               
                DialogResult checkIfRemove = MessageBox.Show("By selecting the music you will be removing it from the\nPlaylist you want to store it.\n\nDo you wish to proceed with this?", "Add Music", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                lstMusicDisplay.ClearSelected();

                if (DialogResult.Yes == checkIfRemove) // Removes the Path and music name from Dictionary and removes from listbox 
                {                  
                    musicFileName.Remove(musicFileName.FirstOrDefault(x => x.Value == lstMusicDisplay.SelectedItem.ToString()).Key); // Remvoes the Key from the Dictionary by getting the value

                    lstMusicDisplay.Items.Remove(lstMusicDisplay.SelectedItem);
                }              
            }
        }
    }
}
