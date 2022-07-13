using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameCore
{
    class PlayerViewSystem : ISystem, IUpdate
    {
        private GameObject _playerPrefab;
        Dictionary<uint, PlayerView> _uidToPlayerView;
        List<IUpdate> _updatePlayers;
        public void OnSystemInit()
        {
            _playerPrefab = Resources.Load<GameObject>("Player/Player");
            Debug.Log("PlayerViewSystem " + _playerPrefab);
            _uidToPlayerView = new Dictionary<uint, PlayerView>();
            _updatePlayers = new List<IUpdate>();
        }

        public void RegisterPlayerView(uint uid)
        {
            if (_uidToPlayerView.ContainsKey(uid))
            {
                throw new Exception("RegisterPlayerView repeat " + uid);
            }
            var playerView = new PlayerView(uid, _playerPrefab);
            _uidToPlayerView[uid] = playerView;
        }

        public void UnRegisterPlayerView(uint uid)
        {
            if (!_uidToPlayerView.ContainsKey(uid))
            {
                throw new Exception("UnRegisterPlayerView empty " + uid);
            }
            _uidToPlayerView[uid].Destroy();
            _uidToPlayerView[uid] = null;
        }

        public void OnSystemUnInit()
        {
            _playerPrefab = null;
            _updatePlayers = null;
            foreach(var info in _uidToPlayerView)
            {
                info.Value.Destroy();
            }
            _uidToPlayerView = null;
        }

        public void Update(float dt)
        {
        }
    }
}
