using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncServer.Core.Time
{
    public static class GTime
    {
        public static long serverTimeMs
        {
            get
            {
                return DateTimeOffset.Now.ToUnixTimeMilliseconds();
            }
        }

        //有时区的客户端时间
        public static long serverTime
        {
            get
            {
                return DateTimeOffset.Now.ToUnixTimeSeconds();
            }
        }
    }
}
