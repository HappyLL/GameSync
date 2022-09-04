using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using KBEngine;

namespace KBE
{
    public class AccountProxy: ProxyBase
    {
        public string accountName;
        public override void InitFromData(Dictionary<string, object> data)
        {
            base.InitFromData(data);
            accountName = "";
            if (data.ContainsKey("accountName"))
            {
                accountName = data["accountName"].ToString();
            }
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
                if (accountName.Length > 0)
                    this.BaseCall("reqCreateAvatar", (byte)1, accountName);//角色类型 和 角色名字
                else
                    Debug.LogError("account name is empty");
                return;
            }
            this.BaseCall("selectAvatarGame", avatarInfoList.values[0].dbid);
        }

        public void onCreateAvatarResult(byte code, AVATAR_INFOS avatarInfos)
        {
            if((UINT8)code != 0)
            {
                Debug.Log("onCreateAvatarResult " + code);
                return;
            }
            this.BaseCall("selectAvatarGame", avatarInfos.dbid);
        }
    }
}
