using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public enum InputKeyType
    {
        FORWARD = 1 << 0,
        BACK = 1 << 1,
        RIGHT = 1 << 2,
        LEFT = 1 << 3,
    }

    public class InputManager: ITick
    {
        private uint keyMask;
        private Player _player;
        
        
        public InputManager(Player player)
        {
            keyMask = 0;
            _player = player;
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
            tickData.uid = _player.UID;
            _player.AppendOneTickData(tickData);
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

        public void Destroy()
        {
            _player = null;
        }
    }
}