using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    class PlayerSystem : ISystem, ITick
    {
        private Dictionary<uint, Player> players;
        public void OnSystemInit()
        {
            players = new Dictionary<uint, Player>();
        }

        public void RegisterPlayer(uint uid, PlayerInfo playerInfo)
        {
            if (players.ContainsKey(uid))
            {
                throw new Exception(string.Format("uid {0} has registered", uid));
            }
            players[uid] = new Player(uid, playerInfo);
        }

        public void UnRegisterPlayer(uint uid)
        {
            if (players.ContainsKey(uid))
            {
                players[uid].Destroy();
                players[uid] = null;
            }
        }

        public void OnSystemUnInit()
        {
            foreach(var playerInfo in players)
            {
                playerInfo.Value.Destroy();
            }
            players = null;
        }

        public void Tick(uint tickCount)
        {

        }
    }
}
