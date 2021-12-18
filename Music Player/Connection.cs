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
            string cutEndpath = "bin";
            int indexOfBinPath = directoryPath.IndexOf(cutEndpath);

            string pathFiletext = directoryPath.Substring(0, indexOfBinPath);
            string[] getfile = Directory.GetFiles(pathFiletext, "PlaylistAndSong*", SearchOption.AllDirectories);

            StreamReader readTextFile = new StreamReader(getfile[0]);

            string textFileLine;
            
            //if (textFileLine != null)
            //{
            while (!(readTextFile.EndOfStream))
            {
                if (readTextFile != null)
                {
                    textFileLine = readTextFile.ReadLine();
                    fileConnection.Add(textFileLine);
                }
                else
                {
                    textFileLine = "No music in file";
                    fileConnection.Add(textFileLine);
                }
            }
            //}
            //else
            //{
                
            //}

            //string end2 = "Music Player";
            //int indexOne = dirCon.IndexOf(end2);

            //string driConTwo = dirCon.Substring(0, indexOne);
            //dirCon = driConTwo + "Music Playlists\\";
            //dirConnection = dirCon;
        }

        public List<string> fullPathName()
        {
            List<string> paths = fileConnection;
            return paths;
        }
    }
}
