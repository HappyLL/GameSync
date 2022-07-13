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
        private List<ITick> tickSystems;
        private List<IUpdate> updateSystems;
        private static GameSystem _ins;
        private uint _curTickCount = 0;

        public void RegisterSystem(ISystem system)
        {
            var sysType = system.GetType();
            if (regSystemInfo.ContainsKey(sysType))
            {
                throw new System.Exception(string.Format("RegisterSystem system {0} repeat", sysType));
            }
            regSystemInfo[sysType] = system;
            if (typeof(ITick).IsAssignableFrom(sysType))
            {
                tickSystems.Add((ITick)system);
            }
            if (typeof(IUpdate).IsAssignableFrom(sysType))
            {
                updateSystems.Add((IUpdate)system);
            }
            system.OnSystemInit();
        }

        public void UnRegisterSystem(ISystem system)
        {
            var sysType = system.GetType();
            if (regSystemInfo.ContainsKey(sysType))
            {
                regSystemInfo[sysType].OnSystemUnInit();
                regSystemInfo[sysType] = null;
                //systems.Remove(system);
                if (typeof(ITick).IsAssignableFrom(sysType))
                {
                    tickSystems.Remove((ITick)system);
                }
                if (typeof(IUpdate).IsAssignableFrom(sysType))
                {
                    updateSystems.Remove((IUpdate)system);
                }
            }
        }

        public T GetSystem<T>(){
            regSystemInfo.TryGetValue(typeof(T), out ISystem system);
            return (T)system;
        }

        public void Tick(uint tickCount)
        {
            if (_curTickCount == tickCount)
                return;
            _curTickCount = tickCount;
            foreach(var system in tickSystems)
            {
                system.Tick(tickCount);
            }
        }

        public void Update()
        {
            Tick(GetCurTickCount());

            float dt = Time.deltaTime;

            foreach(var system in updateSystems)
            {
                system.Update(dt);
            }
        }

        //从第一帧开始
        public uint GetCurTickCount()
        {
            curRunningTimeMs = GameTime.clientTimeMs;
            return (uint)((curRunningTimeMs - startLaunchTimeMs) * tickPerSeconds / 1000) + 1;
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
            tickSystems = new List<ITick>();
            updateSystems = new List<IUpdate>();
            startLaunchTimeMs = GameTime.clientTimeMs;
            curRunningTimeMs = startLaunchTimeMs;

            RegisterSystem(new PlayerSystem());
            RegisterSystem(new PlayerViewSystem());
        }

        public void OnSystemUnInit()
        {
            Debug.Log("On GameSystem UnInit");
            tickSystems = null;
            updateSystems = null;
            foreach (var systemInfo in regSystemInfo)
            {
                systemInfo.Value.OnSystemUnInit();
            }
            regSystemInfo = null;
        }
    }
}