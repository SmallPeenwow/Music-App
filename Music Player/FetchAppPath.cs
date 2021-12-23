using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Music_Player
{
    internal class FetchAppPath
    {
        private string appPath;

        public string AppPath
        {
            get { return appPath; }
            set { appPath = value; }
        }

        public string fetchAppPath()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string checkFile = Path.Combine(appDataFolder + "\\PlaylistAndSong.txt");

            if (!File.Exists(checkFile))
            {
                using (FileStream createTxtFile = File.Create(checkFile))// Creates file for storing path of playlists
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes("Mp3 Music will go");
                    createTxtFile.Write(title, 0, title.Length);

                    createTxtFile.Flush();
                    
                    StreamWriter writer = new StreamWriter(createTxtFile);
                    writer.BaseStream.Seek(0, SeekOrigin.End);

                    writer.WriteLine(Environment.NewLine);
                    writer.Flush();
                    writer.Close();
                    createTxtFile.Close();
                }
            }

            appPath = appDataFolder;
            return appPath;
        }  
        
        public string appPathOnly() // Just gets path to folder and doesn't run through the create method
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appPath = appDataFolder;
            return appPath;
        }
    }
}
