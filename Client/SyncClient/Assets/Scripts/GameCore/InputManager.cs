using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public enum InputKeyType
    {
        UP = 1 << 0,
        DOWN = 1 << 1,
        RIGHT = 1 << 2,
        LEFT = 1 << 3,
    }

    public class InputManager: ITick
    {
        private uint keyMask;
        
        public InputManager()
        {
            keyMask = 0;
        }
        public void Tick(uint tickCount)
        {

        }

        public void OneKeyDown(InputKeyType keyType)
        {
            keyMask |= (uint)keyType;
        }

        public void OneKeyUp(InputKeyType keyType)
        {
            keyMask &= (~((uint)keyType));
        }
    }
}