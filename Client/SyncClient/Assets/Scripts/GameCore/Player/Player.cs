using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class Player : ITick
    {
        private uint _uid;
        private InputManager _input;
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

        public Player(uint uid)
        {
            _uid = uid;
            _input = new InputManager();
        }


        public void Tick(uint tickCount)
        {
            throw new System.NotImplementedException();
        }
    }
}
