using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public interface ISystem
    {
        //ϵͳ��ʼ��
        void OnSystemInit();
        //ϵͳ����ʱ
        void OnSystemUnInit();
    }
}
