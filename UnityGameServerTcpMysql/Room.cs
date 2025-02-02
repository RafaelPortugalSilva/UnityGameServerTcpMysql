using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityGameServerTcpMysql
{
    public class Room
    {
        public string Name;
        public int MaxPlayers = 2;
        public bool IsOpen = true;
        public Dictionary<string, object> Settings;

        public Room(string name, int maxPlayers)
        {
            this.Name = name;
            this.MaxPlayers = maxPlayers;
            this.IsOpen = true;
        }
    }
}
