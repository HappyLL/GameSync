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

        private void ApplyOneTickData(ushort kMask)
        {
            //´¿¿Í»§¶Ë
            TickData tickData = new TickData();
            tickData.keyMask = kMask;
            tickData.tickCount = GameSystem.GetInstance().GetCurTickCount();
            tickData.uid = GameSystem.GetInstance().GetSystem<PlayerSystem>().GetMainPlayer().UID;
        }

        public void OneKeyDown(InputKeyType keyType)
        {
            var curKeyType = (ushort)keyType;
            if ((keyMask & curKeyType) == 0)
            {
                ApplyOneTickData((ushort)((1 << 8) | curKeyType));
            }
            keyMask |= curKeyType;
        }

        public void OneKeyUp(InputKeyType keyType)
        {
            var curKeyType = (ushort)keyType;
            if ((keyMask & curKeyType) != 0)
            {
                ApplyOneTickData(curKeyType);
            }
            keyMask &= (uint)(~curKeyType);
        }
    }
}