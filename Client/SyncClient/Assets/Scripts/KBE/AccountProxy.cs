using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using KBEngine;

namespace KBE
{
    class AccountProxy: ProxyBase
    {
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        public void onReqAvatarList(AVATAR_INFOS_LIST avatarInfoList)
        {
            Debug.Log("onReqAvatarList is " + avatarInfoList.values.Count);
        }
    }
}
