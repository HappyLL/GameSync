using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class GameCore : ITick
    {
        //每一秒的逻辑帧率
        public uint tickPerSeconds = 30;

        private ulong startLaunchTimeMs = 0;
        private ulong curRunningTimeMs = 0;
        private Dictionary<System.Type, ISystem> regSystemInfo;

        public void RegisterSystem(ISystem system)
        {

        }

        public void UnRegisterSystem(ISystem system)
        {

        }

        public void Tick(uint tickCount)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {

        }
    }
}