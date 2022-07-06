using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GTime;

namespace GameCore
{
    public class GameSystem : ITick, ISystem
    {
        //每秒多少tick
        public uint tickPerSeconds = 30;

        private long startLaunchTimeMs = -1;
        private long curRunningTimeMs = 0;
        private Dictionary<System.Type, ISystem> regSystemInfo;
        private static GameSystem _ins;

        public void RegisterSystem(ISystem system)
        {
            regSystemInfo[system.GetType()] = system;
            system.OnSystemInit();
        }

        public void UnRegisterSystem(ISystem system)
        {
            var sysType = system.GetType();
            if (regSystemInfo.ContainsKey(sysType))
            {
                regSystemInfo[sysType].OnSystemUnInit();
                regSystemInfo[sysType] = null;
            }

        }

        public ISystem GetSystem(System.Type sysType){
            regSystemInfo.TryGetValue(sysType, out ISystem system);
            return system;
        }

        public void Tick(uint tickCount)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
        }
           
        public static GameSystem GetInstance()
        {
            if (_ins == null)
            {
                _ins = new GameSystem();
            }
            return _ins;
        }

        //初始化
        public void OnSystemInit()
        {
            Debug.Log("On GameSystem Init");
            regSystemInfo = new Dictionary<System.Type, ISystem>();
            startLaunchTimeMs = GameTime.clientTimeMs;
            curRunningTimeMs = startLaunchTimeMs;

            RegisterSystem(new PlayerSystem());
        }

        public void OnSystemUnInit()
        {
            Debug.Log("On GameSystem UnInit");
            foreach (var systemInfo in regSystemInfo)
            {
                systemInfo.Value.OnSystemUnInit();
            }
            regSystemInfo = null;
        }
    }
}