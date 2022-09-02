using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBEngine;
using UnityEngine;

namespace KBE
{
    public class ProxyMgr
    {
        private static ProxyMgr _ins = null;
        private AccountProxy _accountProxy = null;

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
        }

        private void UnInstallEvents()
        {
            KBEngine.Event.deregisterOut(KBEngine.EventOutTypes.onCreateAccountProxy, this, "OnCreateAccountProxy");
            KBEngine.Event.deregisterOut(KBEngine.EventOutTypes.onDestroyAccountProxy, this, "OnDestroyAccountProxy");
        }

        public ProxyBase GetProxy()
        {
            if (_accountProxy != null)
            {
                return _accountProxy;
            }
            return null;
        }

        public void OnCreateAccountProxy()
        {
            Debug.Log("OnCreateAccountProxy");
            _accountProxy = new AccountProxy();
        }

        public void OnDestroyAccountProxy()
        {
            _accountProxy.Destroy();
            _accountProxy = null;
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
