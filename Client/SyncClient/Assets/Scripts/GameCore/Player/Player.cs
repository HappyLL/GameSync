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
        private GVector3 _position;
        private GVector3 _velocity;
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

        public GVector3 Position
        {
            get
            {
                return _position;
            }
        }

        public GVector3 Velocity
        {
            get
            {
                return _velocity;
            }
        }

        public Player(uint uid, PlayerInfo playerInfo)
        {
            _uid = uid;
            _input = new InputManager(this);
            _playerInfo = playerInfo;
            _tickDatas = new List<TickData>();
        }

        public bool IsMainPlayer()
        {
            return _playerInfo.isMainPlayer;
        }

        public void Tick(uint tickCount)
        {
            _position += _velocity;
            while (_tickDatas.Count > 0 && _tickDatas[0].tickCount <= tickCount)
            {
                ApplyController(_tickDatas[0]);
                _tickDatas.RemoveAt(0);
            }
            //Debug.Log("position " + _position + " velocity " + _velocity);
        }
        
        public void Destroy()
        {
            _input.Destroy();
            _input = null;
        }

        public void ApplyController(TickData data)
        {
            ushort keyMask = data.keyMask;
            InputKeyType keyType = (InputKeyType)(keyMask & 0xFF);
            bool isKeyDown = (keyMask & (1 << 8)) != 0;
            switch (keyType) {
                case InputKeyType.FORWARD:
                    if (isKeyDown)
                        _velocity.z = 1;
                    else
                        _velocity.z = 0;
                    break;
                case InputKeyType.BACK:
                    if (isKeyDown)
                        _velocity.z = -1;
                    else
                        _velocity.z = 0;
                    break;
                case InputKeyType.LEFT:
                    if (isKeyDown)
                        _velocity.x = -1;
                    else
                        _velocity.x = 0;
                    break;
                case InputKeyType.RIGHT:
                    if (isKeyDown)
                        _velocity.x = 1;
                    else
                        _velocity.x = 0;
                    break;

            }
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
