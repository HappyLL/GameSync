using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncServer
{

    using Core;

    class Program
    {
        static void Main(string[] args)
        {
            Server svr = new Server();
            svr.Run();
        }
    }
}
