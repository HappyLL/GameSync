using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBEngine;
using UnityEngine;
using GameState;

namespace KBE
{
    public class ProxyMgr
    {
        private static ProxyMgr _ins = null;
        private AccountProxy _accountProxy = null;
        private AvatarProxy _avatarProxy = null;

        private ProxyMgr()
        {

        }
        public static ProxyMgr GetInstance()
        {
            if (_ins == null)
                _ins = new ProxyMgr();
            return _ins;
        }

        private void InstallEvents()
        {
            KBEngine.Event.registerOut(KBEngine.EventOutTypes.onCreateAccountProxy, this, "OnCreateAccountProxy");
            KBEngine.Event.registerOut(KBEngine.EventOutTypes.onDestroyAccountProxy, this, "OnDestroyAccountProxy");
            KBEngine.Event.registerOut(KBEngine.EventOutTypes.onCreateAvatarProxy, this, "OnCreateAvatarProxy");
            KBEngine.Event.registerOut(KBEngine.EventOutTypes.onDestroyAvatarProxy, this, "OnDestroyAvatarProxy");
        }

        private void UnInstallEvents()
        {
            KBEngine.Event.deregisterOut(KBEngine.EventOutTypes.onCreateAccountProxy, this, "OnCreateAccountProxy");
            KBEngine.Event.deregisterOut(KBEngine.EventOutTypes.onDestroyAccountProxy, this, "OnDestroyAccountProxy");
            KBEngine.Event.deregisterOut(KBEngine.EventOutTypes.onCreateAvatarProxy, this, "OnCreateAvatarProxy");
            KBEngine.Event.deregisterOut(KBEngine.EventOutTypes.onDestroyAvatarProxy, this, "OnDestroyAvatarProxy");
        }

        public AccountProxy GetAccountProxy()
        {
            if (_accountProxy != null)
            {
                return _accountProxy;
            }
            return null;
        }

        public AvatarProxy GetAvatarProxy()
        {
            if (_avatarProxy != null)
            {
                return _avatarProxy;
            }
            return null;
        }

        public void OnCreateAccountProxy(Dictionary<string, object> info)
        {
            Debug.Log("OnCreateAccountProxy");
            _accountProxy = new AccountProxy();
            _accountProxy.InitFromData(info);
            _accountProxy.BaseCall("reqAvatarList");
        }

        public void OnDestroyAccountProxy()
        {
            _accountProxy.Destroy();
            _accountProxy = null;
        }

        public void OnCreateAvatarProxy(Dictionary<string, object> info)
        {
            Debug.Log("OnCreateAvatarProxy");
            _avatarProxy = new AvatarProxy();
            _avatarProxy.InitFromData(info);
            GameStateMgr.GetInstance().ChangeState(GameStateType.MainCity);
        }

        public void OnDestroyAvatarProxy()
        {

        }

        public void Init()
        {
            InstallEvents();
        }

        public void UnInit()
        {
            UnInstallEvents();
        }

    }
}
