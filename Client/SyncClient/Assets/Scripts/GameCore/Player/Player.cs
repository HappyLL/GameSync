using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class Player : ITick
    {
        private uint _uid;
        private InputManager _input;
        private PlayerInfo _playerInfo;
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
        }


        public void Tick(uint tickCount)
        {
            throw new System.NotImplementedException();
        }
        
        public void Destroy()
        {

        }

    }
}
