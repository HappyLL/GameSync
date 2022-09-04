using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBE
{
    public class AvatarProxy:ProxyBase
    {
        public string avatarName;
        public uint avatarId;
        public override void InitFromData(Dictionary<string, object> data)
        {
            avatarName = data["avatarName"].ToString();
            avatarId = UInt32.Parse(data["avatarId"].ToString());
        }
    }
}
