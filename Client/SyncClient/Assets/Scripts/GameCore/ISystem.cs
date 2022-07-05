using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public interface ISystem
    {
        //系统初始化
        void OnSystemInit();
        //系统销毁时
        void OnSystemUnInit();
    }
}
