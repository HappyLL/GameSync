using UnityEngine;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace KBEngine
{
    public class Account : AccountBase
    {
        public Account():base()
        {
        }

        public override void __init__()
        {
            InstallEvents();
            Event.fireOut(EventOutTypes.onCreateAccountProxy, new Dictionary<string, object>() { { "accountName", KBEngineApp.app.username} });
            Dbg.INFO_MSG("Account Init complete");
        }

        private void InstallEvents()
        {
            Event.registerIn(EventInTypes.baseCall, this, "BaseCall");
        }

        private void UnInstallEvents()
        {
            Event.deregisterIn(EventInTypes.baseCall, this, "BaseCall");
        }

        public void BaseCall(string callName, params object[] args)
        {
            Dbg.INFO_MSG("BaseCall " + callName);
            MethodInfo method = baseEntityCall.GetType().GetMethod(callName, BindingFlags.Public | BindingFlags.Instance);
            if(method == null)
            {
                Dbg.ERROR_MSG($"BaseCall error empty method");
                return;
            }
            method.Invoke(baseEntityCall, args);
        }

        public override void onDestroy()
        {
            Dbg.INFO_MSG("Account Destroy " + this.id);
            Event.fireOut(EventOutTypes.onDestroyAccountProxy);
            base.onDestroy();
            UnInstallEvents();
        }

        public override void onCreateAvatarResult(byte arg1, AVATAR_INFOS arg2)
        {
            Dbg.INFO_MSG("onCreateAvatarResult " + arg1);
            Event.fireOut(EventOutTypes.onBaseCallResponse, "onCreateAvatarResult", new object[] { arg1, arg2 });
        }

        public override void onRemoveAvatar(ulong arg1)
        {
            throw new System.NotImplementedException();
        }

        public override void onReqAvatarList(AVATAR_INFOS_LIST arg1)
        {
            Event.fireOut(EventOutTypes.onBaseCallResponse, "onReqAvatarList", new object[] { arg1} );
        }
    }
}
