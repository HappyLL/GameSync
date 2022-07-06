using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GTime;

namespace GameCore
{
    public class GameSystem : ISystem
    {
        //每秒多少tick
        public uint tickPerSeconds = 30;

        private long startLaunchTimeMs = -1;
        private long curRunningTimeMs = 0;
        private Dictionary<System.Type, ISystem> regSystemInfo;
        private List<ISystem> systems;
        private static GameSystem _ins;

        public void RegisterSystem(ISystem system)
        {
            var sysType = system.GetType();
            if (regSystemInfo.ContainsKey(sysType))
            {
                throw new System.Exception(string.Format("RegisterSystem system {0} repeat", sysType));
            }
            regSystemInfo[sysType] = system;
            systems.Add(system);
            system.OnSystemInit();
        }

        public void UnRegisterSystem(ISystem system)
        {
            var sysType = system.GetType();
            if (regSystemInfo.ContainsKey(sysType))
            {
                regSystemInfo[sysType].OnSystemUnInit();
                regSystemInfo[sysType] = null;
                systems.Remove(system);
            }
        }

        public T GetSystem<T>(){
            regSystemInfo.TryGetValue(typeof(T), out ISystem system);
            return (T)system;
        }

        public void Tick(uint tickCount)
        {
            foreach(var system in systems)
            {
                system.Tick(tickCount);
            }
        }

        public void Update()
        {
            Tick(GetCurTickCount());
        }

        public uint GetCurTickCount()
        {
            curRunningTimeMs = GameTime.clientTimeMs;
            return (uint)((curRunningTimeMs - startLaunchTimeMs) * tickPerSeconds / 1000);
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
            systems = new List<ISystem>();
            startLaunchTimeMs = GameTime.clientTimeMs;
            curRunningTimeMs = startLaunchTimeMs;

            RegisterSystem(new PlayerSystem());
        }

        public void OnSystemUnInit()
        {
            Debug.Log("On GameSystem UnInit");
            systems = null;
            foreach (var systemInfo in regSystemInfo)
            {
                systemInfo.Value.OnSystemUnInit();
            }
            regSystemInfo = null;
        }
    }
}