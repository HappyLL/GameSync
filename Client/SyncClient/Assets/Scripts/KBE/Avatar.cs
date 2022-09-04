using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBEngine
{
    public class Avatar : AvatarBase
    {
        public override void __init__()
        {
            base.__init__();
            Event.fireOut(EventOutTypes.onCreateAvatarProxy, new Dictionary<string, object>() { { "avatarName", name}, { "avatarId", this.uid} });
            Dbg.INFO_MSG("Avatar Init Complete " + this.name);
        }

        public override void onDestroy()
        {
            Event.fireOut(EventOutTypes.onDestroyAvatarProxy);
            base.onDestroy();
        }

        public override void dialog_addOption(byte arg1, uint arg2, string arg3, int arg4)
        {
            throw new NotImplementedException();
        }

        public override void dialog_close()
        {
            throw new NotImplementedException();
        }

        public override void dialog_setText(string arg1, byte arg2, uint arg3, string arg4)
        {
            throw new NotImplementedException();
        }

        public override void onAddSkill(int arg1)
        {
            throw new NotImplementedException();
        }

        public override void onJump()
        {
            throw new NotImplementedException();
        }

        public override void onRemoveSkill(int arg1)
        {
            throw new NotImplementedException();
        }

        public override void recvDamage(int arg1, int arg2, int arg3, int arg4)
        {
            throw new NotImplementedException();
        }
    }
}
