using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player
{
    class Connection
    {
        private string dirConnection;

        public string DirConnection
        {
            get
            {
                return dirConnection;
            }
            set
            {
                dirConnection = value;
            }
        }

        public Connection(string dirCon)
        {
            string end2 = "Music Player";
            int indexOne = dirCon.IndexOf(end2);

            string driConTwo = dirCon.Substring(0, indexOne);
            dirCon = driConTwo + "Music Playlists\\";
            dirConnection = dirCon;
        }

        public string fullPathName()
        {
            string paths = dirConnection;
            return paths;
        }
    }
}
