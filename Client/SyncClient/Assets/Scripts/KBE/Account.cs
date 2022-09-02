﻿using UnityEngine;

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
            Event.fireOut(EventOutTypes.onCreateAccountProxy);
        }

        private void InstallEvents()
        {

        }

        private void UnInstallEvents()
        {
        }

        public override void onDestroy()
        {
            base.onDestroy();
            UnInstallEvents();
        }

        public override void onCreateAvatarResult(byte arg1, AVATAR_INFOS arg2)
        {

        }

        public override void onRemoveAvatar(ulong arg1)
        {
            throw new System.NotImplementedException();
        }

        public override void onReqAvatarList(AVATAR_INFOS_LIST arg1)
        {
            throw new System.NotImplementedException();
        }
    }
}
