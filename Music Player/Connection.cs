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
            //string[] split = dirCon.Split('\\');
            string end2 = "Music Player";
            int indexOne = dirCon.IndexOf(end2);

            string driConTwo = dirCon.Substring(0, indexOne);
            dirCon = driConTwo + "Music Playlists\\";
            //string firstPath = split[0];
            //string secondPath = split[1];
            //dirCon = firstPath + "\\" + secondPath;
            dirConnection = dirCon;
        }

        public string fullPathName()
        {           
            string paths = dirConnection;
            return paths;
        }

        //public override string ToString()
        //{
        //    return base.ToString() + dirConnection;
        //}

    }
}
