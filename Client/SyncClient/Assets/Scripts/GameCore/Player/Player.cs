using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class Player : ITick, IController
    {
        private uint _uid;
        private InputManager _input;
        private PlayerInfo _playerInfo;
        private List<TickData> _tickDatas;
        public uint UID {
            get
            {
                return _uid;
            }
        }

        public InputManager InputManager
        {
            get
            {
                return _input;
            }
        }

        public Player(uint uid, PlayerInfo playerInfo)
        {
            _uid = uid;
            _input = new InputManager();
            _playerInfo = playerInfo;
            _tickDatas = new List<TickData>();
        }

        public bool IsMainPlayer()
        {
            return _playerInfo.isMainPlayer;
        }

        public void Tick(uint tickCount)
        {
            while(_tickDatas.Count > 0 && _tickDatas[0].tickCount <= tickCount)
            {
                ApplyController(_tickDatas[0]);
                _tickDatas.RemoveAt(0);
            }
        }
        
        public void Destroy()
        {

        }

        public void ApplyController(TickData data)
        {
            
        }

        public void AppendOneTickData(TickData data)
        {
            var lastCount = _tickDatas.Count;
           if(lastCount > 0 && _tickDatas[lastCount - 1].tickCount > data.tickCount)
           {
                throw new System.Exception(string.Format("AppendOneTickData tickCount less last one {0} {1}", _tickDatas[lastCount - 1].tickCount, data.tickCount));
           }

            _tickDatas.Add(data);
        }
    }
}
