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
        public string accountName;
        public override void InitFromData(Dictionary<string, object> data)
        {
            base.InitFromData(data);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        public void onReqAvatarList(AVATAR_INFOS_LIST avatarInfoList)
        {
            var avatarCount = avatarInfoList.values.Count;
            Debug.Log("onReqAvatarList is " + avatarCount);
            if(avatarCount == 0)
            {
                this.BaseCall("reqCreateAvatar", 1);//角色类型 和 角色名字
                return;
            }
        }
    }
}
