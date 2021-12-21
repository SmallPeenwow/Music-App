using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Music_Player
{
    class Connection
    {
        private List<string> fileConnection = new List<string>();

        public List<string> FileConnection
        {
            get
            {
                return fileConnection;
            }
            set
            {
                fileConnection = value;
            }
        }

        // This will get textfile with songs and playlists
        // then will read the contents of the file
        public Connection(string directoryPath)
        {
            string[] folderNames; // Stores the Path of the Folder Playlists

            string cutEndpath = "Music Player";
            int indexOfBinPath = directoryPath.IndexOf(cutEndpath); // Gets the index of where the cut off for the URL begins

            string pathFiletext = directoryPath.Substring(0, indexOfBinPath);
            string[] getfile = Directory.GetFiles(pathFiletext, "PlaylistAndSong*", SearchOption.AllDirectories); // Gest the textfile location named PlaylistAndSong

            StreamReader readTextFile = new StreamReader(getfile[0]);                 

            string textFileLine;

            while (!(readTextFile.EndOfStream)) // Reads all the lines in the textfile and stops when gets to the end of the textfile text
            {
                if (readTextFile != null)
                {
                    textFileLine = readTextFile.ReadLine();// Gest Path of playlist

                    if (textFileLine != "Mp3 Music will go")
                    {                      
                        folderNames = Directory.GetFiles(textFileLine, "*", SearchOption.TopDirectoryOnly);// Gets the music in the Playlist

                        if(folderNames == null || folderNames.Length == 0)// Checks if playlist has no music
                        {
                            fileConnection.Add(textFileLine); // Adds Playlist Path that has no music in it
                        }
                        else
                        {
                            for (int i = 0; i < folderNames.Length; i++)
                            {
                                fileConnection.Add(folderNames[i]); // Adds Path of Playlist and music in it
                            }
                        }                       
                    }                 
                }
            }
            readTextFile.Close();
        }

        // Sends List of all the URL paths to Fomr1 to be loaded into the Comobobox and ListBox
        public List<string> fullPathName()
        {
            List<string> paths = fileConnection;
            return paths;
        }
    }
}
