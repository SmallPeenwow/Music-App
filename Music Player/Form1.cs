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

namespace Music_Player
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        public string[] fileSplits;

        Timer timer = new Timer();
        
        double time = 0; // Used to store the current position of time in the song

        int numberForVolume = 1; // Used to increment and decrement   

        double nowtime = 0; // Used to display time of song

        private int btnLoopClicked = 1;

        List<string> currentFilePath = new List<string>();

        private Connection connection;

        IDictionary<string, Dictionary<string, string>> musicValue = new Dictionary<string, Dictionary<string, string>>();

        public Form1()
        {
            InitializeComponent();
        }

        // The song is the playSelected variable
        // The playlist is the playlistSelected variable
        private void playBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(time != 0)
                {
                    player.controls.play();
                    timer.Start();
                }
                else if (musicListBox.SelectedIndex != -1 || (musicListBox.SelectedIndex != -1 && storeOfPlayListSelect.Text != "" && musicIndex.Text != ""))
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
            catch (Exception error)
            {
                MessageBox.Show("Not working " + error, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void playMusic(string music, string playlist)// Plays the music using the URL 
        {
            string musicUrlKey = "";

            for (int i = 0; i < musicValue.Count; i++)
            {
                KeyValuePair<string, Dictionary<string, string>> keyValuePair = musicValue.ElementAt(i);
                musicUrlKey = keyValuePair.Key;

                if (musicUrlKey.Contains(playlist) && musicUrlKey.Contains(music))
                {
                    playMusic(musicUrlKey);
                }
            }
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

                    musicListBox.SelectedIndex = musicListBox.SelectedIndex = 0;// moves down the ListBox

                    playMusic(currentMusic, playlist);
                }
                else
                {
                    currentMusic = musicListBox.Items[num].ToString();

                    musicListBox.SelectedIndex = num; // Moves down the ListBox

                    playMusic(currentMusic, playlist);
                }                              
            }
            else
            {
                num--;

                num = num < 0 ? num = musicListBox.Items.Count - 1 : num;

                currentMusic = num >= musicListBox.Items.Count ? currentMusic = musicListBox.Items[musicListBox.Items.Count - 1].ToString() : currentMusic = musicListBox.Items[num].ToString();

                musicListBox.SelectedIndex = num; // Moves up the ListBox

                playMusic(currentMusic, playlist);
            }
        }

        public void playMusic(string musicUrl)// Plays the music using the URL 
        {
            player.URL = musicUrl;

            player.controls.play();

            fileSplits = musicUrl.Split('\\', ':');

            musicIndex.Text = fileSplits[fileSplits.Length - 1].Replace(".mp3", "");
            currentSonglbl.Text = fileSplits[fileSplits.Length - 1].Replace(".mp3", "");
            currentSonglbl.Font = new Font("Microsoft Sans Serif", 10);
            lblVolumeDisplay.Text = "Volume : " + player.settings.volume.ToString();

            timer.Interval = 200;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        // Will check if song is currently playing or if it is paused
        private void stopBtn_Click(object sender, EventArgs e)
        {
            if(player.playState == WMPPlayState.wmppsPlaying || player.playState == WMPPlayState.wmppsPaused)
            {
                player.controls.stop();
                currentSonglbl.Text = "";
                lblVolumeDisplay.Text = "Volume :";
                storeOfPlayListSelect.Clear();
                musicIndex.Clear();
                player.settings.setMode("loop", false);
                btnLoopSongs.Text = "Loop";
                btnLoopClicked = 1;
                musicListBox.ClearSelected();

                lblsongDuration.Text = "";
                timer.Stop();
            }
            else 
            {
                NoMusicPlaying();
            }          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            errorDisplayMesslbl.Font = new Font("Arial", 14, FontStyle.Underline);
            lblVolumeDisplay.Font = new Font("Microsoft Sans Serif", 10);
            ListSelecter.DropDownStyle = ComboBoxStyle.DropDownList;
            playSelectlbl.Text = "Select Playlist";

            storeOfPlayListSelect.Enabled = false;
            storeOfPlayListSelect.Visible = false;
            musicIndex.Enabled = false;
            musicIndex.Visible = false;
            musicListBox.SelectionMode = SelectionMode.One;
            currentSonglbl.Text = "";
            ListSelecter.Items.Add("All");

            try
            {                
                loadPlaylistSongs();
            }
            catch (Exception fail)
            {
                MessageBox.Show("Couldn't load music list" + fail, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private
        public void loadPlaylistSongs()
        {
            musicValue.Clear();
            musicListBox.Items.Clear();

            string pathSearch = Directory.GetCurrentDirectory();
            connection = new Connection(pathSearch);
            currentFilePath = connection.fullPathName();

            HashSet<string> dropDownAdd = new HashSet<string>();

            if (currentFilePath.Any() != true)// Checks if List which contains textfile URLs is empty and if is empty displays this message
            {
                MessageBox.Show("No music found", "Music", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            for (int i = 0; i < currentFilePath.Count; i++)
            {
                string song;
                string playlist;
                string urlPath;                
              
                fileSplits = currentFilePath[i].Split('\\', ':');

                if (fileSplits[fileSplits.Length - 1].Contains(".mp3"))// If URL path contains music
                {
                    song = fileSplits[fileSplits.Length - 1].Replace(".mp3", "");
                    playlist = fileSplits[fileSplits.Length - 2];
                    urlPath = currentFilePath[i];

                    dropDownAdd.Add(playlist);
                    musicListBox.Items.Add(song);

                    musicValue.Add(urlPath, new Dictionary<string, string>());
                    musicValue[urlPath].Add(song, playlist);
                }
                else// For when URL only has Playlist
                {
                    song = "";
                    playlist = fileSplits[fileSplits.Length - 1];
                    urlPath = currentFilePath[i];

                    dropDownAdd.Add(playlist);

                    musicValue.Add(urlPath, new Dictionary<string, string>());
                    musicValue[urlPath].Add(song, playlist);
                }                   
                                              
            }

            for (int x = 0; x < dropDownAdd.Count; x++)// Adds Playlist names to dropdown by using hashset that doesn't duplicate elements
            {
                string playlistName = dropDownAdd.ElementAt(x);
                ListSelecter.Items.Remove(playlistName); // Removes previous Playlist names on call of method
                ListSelecter.Items.Add(playlistName);
            }
        }

        private void pause_Click(object sender, EventArgs e)
        {
            if(player.playState == WMPPlayState.wmppsPlaying)
            {
                time = player.controls.currentPosition;
                player.controls.pause();

                timer.Stop();
            }
            else
            {
                NoMusicPlaying();
            }
            
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
                if (ListSelecter.SelectedItem.ToString() == "All")// Calls loadPlaylistSong method to reload all the songs and playlist
                {
                    storeOfPlayListSelect.Text = "All";
                    //ListSelecter.Items.Remove("All");
                    loadPlaylistSongs();
                }
                else // Gets the music that is in the playlist that was selected in the combobox
                {
                    musicValue.Clear();
                    musicListBox.Items.Clear();

                    string playlistSelected = ListSelecter.SelectedItem.ToString();
                    storeOfPlayListSelect.Text = playlistSelected;

                    for (int i = 0; i < currentFilePath.Count; i++)
                    {
                        fileSplits = currentFilePath[i].Split('\\', ':');
                        string playlist = fileSplits[fileSplits.Length - 2]; // Gets playlist from URL to compare to playlist that was selected in combobox

                        if(playlistSelected == playlist)
                        {
                            string song = fileSplits[fileSplits.Length - 1].Replace(".mp3", "");
                            string urlPath = currentFilePath[i];

                            musicListBox.Items.Add(song);

                            musicValue.Add(urlPath, new Dictionary<string, string>());
                            musicValue[urlPath].Add(song, playlist);
                        }                      
                    }                  
                }                
            }
            catch (Exception loadFail)
            {
                MessageBox.Show("Was not able to load music. " + loadFail, "Not Working", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                    
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            errorDisplayMesslbl.Text = null;
        }

        private String getPlaylistForPlaying(string value)// Gets the Playlist that is associated with the music 
        {
            for (int i = 0; i < musicValue.Count; i++)
            {
                KeyValuePair<string, Dictionary<string, string>> keyValuePair = musicValue.ElementAt(i);
                string musicKey = keyValuePair.Key;
                Dictionary<string, string> dicMusicValue = keyValuePair.Value;

                for (int x = 0; x < dicMusicValue.Count; x++)
                {
                    KeyValuePair<string, string> keyValuePlaylist = dicMusicValue.ElementAt(x);
                    string playlistValue = keyValuePlaylist.Value;

                    if (musicKey.Contains(playlistValue) && musicKey.Contains(musicListBox.SelectedItem.ToString())) // Checks to see if URL has the Playlist name in it
                    {
                        value = playlistValue;
                        break;
                    }
                }              
                if(value != "")
                {
                    break;
                }
            }
            return value; // returns the Playlist name
        }

        private String getPlaylistForPlaying(string currentMusic, int number)// value is music name
        {
            Dictionary<string, string> valueMusicValue = new Dictionary<string, string>();// Value of dictionary
            Dictionary<string, string> compareValues = new Dictionary<string, string>();// Used to store all the keys and values 
            string musicUrlKey = "";
            int num = 0; // used to get the element in the musicValue to get the correct URL
            string playlistStored = "";       

            for (int i = 0; i < musicValue.Count; i++)
            {
                KeyValuePair<string, Dictionary<string, string>> keyValuePair = musicValue.ElementAt(i);
                musicUrlKey = keyValuePair.Key;
                valueMusicValue = keyValuePair.Value;
                
                for (int x = 0; x < valueMusicValue.Count; x++)// iterates through the second dictionary to get the value of the playlist 
                {
                    KeyValuePair<string, string> getsPlaylist = valueMusicValue.ElementAt(x);
                    string musicKey = getsPlaylist.Key;
                    string playlistValue = getsPlaylist.Value;

                    compareValues.Add(musicKey, playlistValue);                  
                }
            }

            num = Array.IndexOf(compareValues.Keys.ToArray(), currentMusic);

            num = number == 1 ? num + 1 : num - 1;// Will increase number or decrease depending on if Next or Previous button was clicked

            num = num > compareValues.Count - 1 ? num = 0 : num < 0 ? num = Array.IndexOf(compareValues.Keys.ToArray(), compareValues.Keys.Last()) : num;           

            playlistStored = compareValues.ElementAt(num).Value; // Gets Playlist name

            storeOfPlayListSelect.Text = playlistStored; // Stores Playlist name in textbox for referencing when next or previous or play music

            return playlistStored;
        }

        private void musicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string playlistSelected = "";
            if (musicListBox.SelectedIndex != -1) 
            {
                playlistSelected = getPlaylistForPlaying(playlistSelected);
                storeOfPlayListSelect.Text = playlistSelected;
            }        
                     
            // Sets the time of the song to zero so the current song select by the user can be played
            if (musicListBox.SelectedIndex > -1)
            {
                time = 0;
            }
        }

        // Checks for values and then sends to playMusic method
        private void nextBtn_Click(object sender, EventArgs e)
        {       
            if (!(musicListBox.SelectedIndex == -1) && !(storeOfPlayListSelect.Text == "") && !(musicIndex.Text == ""))
            {
                int nextNumber = 1;
                string playSelected = musicIndex.Text;
                string playlistSelected = getPlaylistForPlaying(playSelected, nextNumber);// Uses the music to search for the playlist
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
            if (!(musicListBox.SelectedIndex == -1) && !(storeOfPlayListSelect.Text == "") && !(musicIndex.Text == ""))
            {
                int nextNumber = 2;
                string playSelected = musicIndex.Text;
                string playlistSelected = getPlaylistForPlaying(playSelected, nextNumber);// Uses the music to search for the playlist              

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
            int value = 1;
            CreateMenuFileSave(value, currentFilePath);
        }

        // This method is for creating files and for add songs
        private void CreateMenuFileSave(int value, List<string> connectDir)
        {
            Form2 createFolder = new Form2(value, connectDir);
            createFolder.ShowDialog();           
            loadPlaylistSongs();
        }

        private void addMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int value = 2;
            CreateMenuFileSave(value, currentFilePath);// Used to get form to add song
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            player.settings.volume += numberForVolume;
            lblVolumeDisplay.Text = "Volume : " + player.settings.volume.ToString();
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            player.settings.volume -= numberForVolume;
            lblVolumeDisplay.Text = "Volume : " + player.settings.volume.ToString();
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            if(player.playState == WMPPlayState.wmppsPlaying)
            {
                if (player.settings.mute == true)
                {                   
                    player.settings.mute = false;
                }
                else
                {
                    player.settings.mute =  true;
                }
            }
            else
            {
                NoMusicPlaying();
            }
           
            
            btnMute.Enabled = true;
        }

        // Takes to Form to Delete Playlist and songs inside it
        private void deletePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int value = 3;
            CreateMenuFileSave(value, currentFilePath);
        }

        private void btnLoopSongs_Click(object sender, EventArgs e)
        {
            
            if(player.playState == WMPPlayState.wmppsPlaying || player.playState == WMPPlayState.wmppsPaused)
            {
                if (btnLoopClicked == 1)
                {
                    player.settings.setMode("loop", true);
                    btnLoopSongs.Text = "Song on loop";
                    btnLoopClicked = 2;
                }
                else
                {
                    player.settings.setMode("loop", false);
                    btnLoopSongs.Text = "Loop";
                    btnLoopClicked = 1;
                }
            }
            else
            {
                NoMusicPlaying();
                btnLoopClicked = 1;
            }                                               
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan songSeconds = new TimeSpan();
            TimeSpan secondSubtract = new TimeSpan();
            lblsongDuration.Font = new Font("Microsoft Sans Serif", 10);
            double now = player.controls.currentPosition;
            nowtime = player.currentMedia.duration;
            int thisTime = (int)Math.Floor(nowtime);
            int thisNow = (int)Math.Ceiling(now);
            secondSubtract = TimeSpan.FromSeconds(thisNow);
            songSeconds = TimeSpan.FromSeconds(thisTime);
            TimeSpan currentSeconds = songSeconds.Subtract(secondSubtract);
            lblsongDuration.Text = currentSeconds.ToString(@"mm\:ss");

            if (thisNow > thisTime)
            {
                lblsongDuration.Text = currentSeconds.ToString(@"mm\:ss");
                timer.Stop();
                lblsongDuration.Text = "";
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.DataAvailable += new EventHandler(chileDataAvailable);
            set.ShowDialog();
        }

        private void NoMusicPlaying()
        {
            MessageBox.Show("No song has been selected to play", "No music playing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        void chileDataAvailable(object sender, EventArgs e)
        {
            Settings set = sender as Settings;
            if (set != null)
            {
                numberForVolume = set.number;
            }
        }
    }
}
