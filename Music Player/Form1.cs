using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WMPLib;
using System.Drawing.Drawing2D;

namespace Music_Player
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        public string[] fileSplits;
        
        double time = 0;

        public Form1()
        {
            InitializeComponent();         
        }

        // The song is the " playSelected " variable
        // The playlist is the " playlistSelected " variable
        private void playBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(time != 0)
                {
                    player.controls.play();
                }
                else if (!(musicListBox.SelectedIndex == -1) && !(storeOfPlayListSelect.Text == null))
                {
                    string playSelected = musicListBox.SelectedItem.ToString(); 
                    string playlistSelected = storeOfPlayListSelect.Text.ToString();                    

                    playMusic(playSelected, playlistSelected);
                    
                }
                else
                {
                    MessageBox.Show("Failed to play music", "Not Responding", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorDisplayMesslbl.Text = "Make sure a Song and Playlist are selected.";
                }
            }
            catch (NullReferenceException emtpy)
            {
                MessageBox.Show("Empty" + emtpy, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception error)
            {
                MessageBox.Show("Not working", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void playMusic(string music, string playlist)
        {
            string willPlay = "C:\\Music App\\Music Playlists\\" + playlist + " Playlist\\" + music + ".mp3";

            player.URL = willPlay;

            player.controls.play();

            musicIndex.Text = music;
            currentSonglbl.Text = music;
            currentSonglbl.Font = new Font("Microsoft Sans Serif", 10);
            player.settings.volume = 60;
            lblVolumeDisplay.Text = "Volume : " + player.settings.volume.ToString();
        }

        // Method that controls the Next and Previous button
        // Gets next song or previous song
        public void playMusic(string currentMusic, string playlist, int nextMusic)
        {
            int num = musicListBox.Items.IndexOf(currentMusic); // the value that will be used to either go up or down the ListBox

            if (nextMusic == 1)// The value used to determine if it Next or Previous Button 
            {              
                num++;

                if (num >= musicListBox.Items.Count)
                {
                    currentMusic = musicListBox.Items[0].ToString();

                    playMusic(currentMusic, playlist);
                }
                else
                {
                    currentMusic = musicListBox.Items[num].ToString();

                    playMusic(currentMusic, playlist);
                }                              
            }
            else
            {
                num--;

                num = num < 0 ? num = musicListBox.Items.Count - 1 : num;

                currentMusic = num >= musicListBox.Items.Count ? currentMusic = musicListBox.Items[musicListBox.Items.Count - 1].ToString() : currentMusic = musicListBox.Items[num].ToString();

                playMusic(currentMusic, playlist);
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            currentSonglbl.Text = "";
            lblVolumeDisplay.Text = "Volume :";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            errorDisplayMesslbl.Font = new Font("Arial", 14, FontStyle.Underline);

            ListSelecter.DropDownStyle = ComboBoxStyle.DropDownList;
            playSelectlbl.Text = "Select Playlist";

            storeOfPlayListSelect.Enabled = false;
            storeOfPlayListSelect.Visible = false;
            musicIndex.Enabled = false;
            musicIndex.Visible = false;
            musicListBox.SelectionMode = SelectionMode.One;
            currentSonglbl.Text = "";

            try
            {
                string[] folderName = Directory.GetDirectories(@"C:\Music App\Music Playlists", "*", SearchOption.AllDirectories);

                for (int i = 0; i < folderName.Length; i++)
                {
                    if (folderName[i].Contains("Playlist"))
                    {
                        fileSplits = folderName[i].Split(' ', '\\', ':');

                        ListSelecter.Items.Add(fileSplits[fileSplits.Length - 2]);
                    }
                }
            }
            catch (Exception fail)
            {
                MessageBox.Show("Couldn't load music list" + fail, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pause_Click(object sender, EventArgs e)
        {
            time = player.controls.currentPosition;
            player.controls.pause();
        }

        private void CursorChange(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void CursorBack(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void ListSelecter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                musicListBox.Items.Clear();

                string playlistSelected = ListSelecter.SelectedItem.ToString();

                storeOfPlayListSelect.Text = playlistSelected;

                string[] files = Directory.GetFiles(@"C:\Music App\Music Playlists\" + playlistSelected + " Playlist");

                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Contains("mp3"))
                    {
                        fileSplits = files[i].Split('\\', ':');

                        musicListBox.Items.Add(fileSplits[fileSplits.Length - 1].Replace(".mp3", ""));
                    }
                }
            }
            catch (Exception loadFail)
            {
                MessageBox.Show("Was not able to load songs. " + loadFail, "Not Working", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                    
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            errorDisplayMesslbl.Text = null;
        }

        private void musicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sets the time of the song to zero so the current song select by the user can be played
            if (musicListBox.SelectedIndex > -1) 
            {
                time = 0;
            }
        }

        // Checks for values and then sends to playMusic method
        private void nextBtn_Click(object sender, EventArgs e)
        {       
            if (!(musicListBox.SelectedIndex == -1) && !(storeOfPlayListSelect.Text == null) && !(musicIndex.Text == null))
            {
                string playSelected = musicIndex.Text.ToString();
                string playlistSelected = storeOfPlayListSelect.Text.ToString();
                int nextNumber = 1;

                playMusic(playSelected, playlistSelected, nextNumber);
            }
            else
            {
                MessageBox.Show("Failed to play music", "Not Responding", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorDisplayMesslbl.Text = "Make sure a Song and Playlist are selected.";
            }                  
        }

        // Checks for values and then sends to playMusic method
        private void previousBtn_Click(object sender, EventArgs e)
        {
            if (!(musicListBox.SelectedIndex == -1) && !(storeOfPlayListSelect.Text == null) && !(musicIndex.Text == null))
            {
                string playSelected = musicIndex.Text.ToString();
                string playlistSelected = storeOfPlayListSelect.Text.ToString();
                int nextNumber = 2;

                playMusic(playSelected, playlistSelected, nextNumber); 
            }
            else
            {
                MessageBox.Show("Failed to play music", "Not Responding", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorDisplayMesslbl.Text = "Make sure a Song and Playlist are selected.";
            }
        }

        // File will be created and added to the Music Playlist file
        private void createPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult answer = MessageBox.Show("You can create a new Playlist to store music in by selecting \'YES\'", "Create Playlist", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (answer == DialogResult.Yes)
            //{
                int value = 1;

                CreateMenuFileSave(value);
            //}
        }

        // This method is for creating files and for add songs
        private void CreateMenuFileSave(int value)
        {
            Form2 createFolder = new Form2(value);
            createFolder.ShowDialog();
        }

        private void addMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult answer = MessageBox.Show("You can add your Song to your Playlist by selecting \'YES\'", "Add Song", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (answer == DialogResult.Yes)
            //{
                int value = 2;

                CreateMenuFileSave(value);// Used to get form to add song
            //}
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            player.settings.volume += 1;
            lblVolumeDisplay.Text = "Volume : " + player.settings.volume.ToString();
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            player.settings.volume -= 1;
            lblVolumeDisplay.Text = "Volume : " + player.settings.volume.ToString();
        }

        private void btnMute_Click(object sender, EventArgs e)
        {

            player.settings.mute = player.settings.mute;
        }
    }
}
