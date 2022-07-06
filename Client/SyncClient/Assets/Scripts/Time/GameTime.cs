using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTime
{
    public static class GameTime
    {
        private static long _svrTime; //服务端时间
        private static long _svrTimeMs; //服务端时间(ms)
        public static float startUpTime; //启动时间
        public static long delayTime; // 延时(ms)
        public static long _serverUpdateTime;

        public static long TimeOffset
        {
            get
            {
                DateTimeOffset localTime = DateTimeOffset.Now;
                return localTime.Offset.Hours * 3600;
            }
        }

        public static long clientTimeMs
        {
            get
            {
                return nowClientUTC0TimeMs + TimeOffset * 1000;
            }
        }

        //有时区的客户端时间
        public static long clientTime
        {
            get
            {
                return nowClientUTC0Time + TimeOffset;
            }
        }

        public static long nowClientUTC0Time
        {
            get
            {
                return DateTimeOffset.Now.ToUnixTimeSeconds();
            }
        }

        public static long nowClientUTC0TimeMs
        {
            get
            {
                return DateTimeOffset.Now.ToUnixTimeMilliseconds();
            }
        }

        private static void UpdateSvrTimeByClient()
        {
            var dt = (nowClientUTC0TimeMs - _serverUpdateTime);
            _svrTimeMs = _svrTimeMs + dt;
            _svrTime = _svrTimeMs / 1000;
            _serverUpdateTime = nowClientUTC0TimeMs;
        }

        public static long svrTime
        {
            get
            {
                UpdateSvrTimeByClient();
                return _svrTime;
            }
        }

        public static long svrTimeMs
        {
            get
            {
                UpdateSvrTimeByClient();
                return _svrTimeMs;
            }
            set
            {
                _serverUpdateTime = nowClientUTC0TimeMs;
                _svrTimeMs = value;
                _svrTime = svrTimeMs / 1000;
            }
        }

    }
}
