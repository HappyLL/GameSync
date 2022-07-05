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
        public void Tick(uint tickCount)
        {
            throw new System.NotImplementedException();
        }

        public void OneKeyDown()
        {

        }

        public void OneKeyUp()
        {

        }
    }
}