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
                    textFileLine = readTextFile.ReadLine();                    

                    fileConnection.Add(textFileLine);
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
