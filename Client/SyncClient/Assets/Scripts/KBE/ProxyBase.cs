using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBEngine;
using System.Reflection;
using UnityEngine;

namespace KBE
{
    public class ProxyBase
    {


        protected virtual void InstallEvents() {

            KBEngine.Event.registerOut(EventOutTypes.onBaseCallResponse, this, "OnBaseCallResponse");
        }
        protected virtual void UnInstallEvents() {
            KBEngine.Event.deregisterOut(EventOutTypes.onBaseCallResponse, this, "OnBaseCallResponse");
        }

        public virtual void InitFromData(Dictionary<string, object> data) {
            InstallEvents();
        }
        protected virtual void OnDestroy() {
            UnInstallEvents();
        }
        public void Destroy()
        {
            OnDestroy();
        }
        public virtual void BaseCall(string callName, params object[] args)
        {
            KBEngine.Event.fireIn(KBEngine.EventInTypes.baseCall, callName, args);
        }

        public virtual void OnBaseCallResponse(string callName, params object[] args)
        {
            var methodInfo = GetType().GetMethod(callName, BindingFlags.Public | BindingFlags.Instance);
            if(methodInfo == null)
            {
                Debug.LogError($"OnBaseCallResponse {callName} empty");
                return;
            }
            Debug.Log("OnBaseCallResponse success " + callName);
            methodInfo.Invoke(this, args);
        }
    }
}
