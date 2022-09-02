using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KBE
{
    class AccountProxy: ProxyBase
    {
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        public void onReqAvatarList(object[] args)
        {
            Debug.Log("onReqAvatarList is " + args.Length);
        }
    }
}
