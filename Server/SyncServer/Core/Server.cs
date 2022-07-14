using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SyncServer.Core
{
    using Time;
    public class Server
    {
        private const uint tickPerSeconds = 30; //服务器帧率
        private uint secondPerTick = 1000 / tickPerSeconds;
        private long startServerTimeMs;
        private long curServerTimeMs;
        public void Run()
        {

            InstallLib();

            startServerTimeMs = GTime.serverTimeMs;
            curServerTimeMs = startServerTimeMs;

            while (true)
            {
               Update();
               long dt = GTime.serverTimeMs - curServerTimeMs;
               if (dt < secondPerTick)
               {
                    //跑的快的话要休息
                    Thread.Sleep((int)(secondPerTick - dt));
               }
               curServerTimeMs = GTime.serverTimeMs;
            }
        }
        private void Update()
        {
            Console.WriteLine("Server Update");
        }

        private void InstallNetwork()
        {

        }

        private void InstallFileLog()
        {

        }
        
        private void InstallLib()
        {
            InstallFileLog();
            InstallNetwork();
        }

    }
}
