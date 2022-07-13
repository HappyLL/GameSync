using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameCore
{
    class PlayerSystem : ISystem, ITick
    {
        private Dictionary<uint, Player> players;
        private List<Player> playerList;
        private Player mainPlayer;
        public void OnSystemInit()
        {
            players = new Dictionary<uint, Player>();
            playerList = new List<Player>();
            mainPlayer = null;
        }

        public void RegisterPlayer(uint uid, PlayerInfo playerInfo)
        {
            if (players.ContainsKey(uid) || (playerInfo.isMainPlayer && mainPlayer != null))
            {
                throw new Exception(string.Format("uid {0} has registered or main player repeat", uid));
            }

            var player = new Player(uid, playerInfo);
            players[uid] = player;
            playerList.Add(players[uid]);
            if (player.IsMainPlayer())
            {
                mainPlayer = player;
            }

            GameSystem.GetInstance().GetSystem<PlayerViewSystem>().RegisterPlayerView(uid);
        }

        public void UnRegisterPlayer(uint uid)
        {
            if (players.ContainsKey(uid))
            {
                var player = players[uid];
                if(player == mainPlayer)
                {
                    mainPlayer = player;
                }
                playerList.Remove(player);
                player.Destroy();
                players[uid] = null;
                GameSystem.GetInstance().GetSystem<PlayerViewSystem>().UnRegisterPlayerView(uid);
            }
        }

        public void OnSystemUnInit()
        {
            playerList = null;
            foreach (var playerInfo in players)
            {
                playerInfo.Value.Destroy();
            }
            players = null;
            mainPlayer = null;
        }

        public void Tick(uint tickCount)
        {
            foreach(var player in playerList)
            {
                player.Tick(tickCount);
            }
        }
        
        public Player GetMainPlayer()
        {
            return mainPlayer;
        }

        public Player GetTargetPlayer(uint uid)
        {
            players.TryGetValue(uid, out Player target);
            return target;
        }
    }
}
