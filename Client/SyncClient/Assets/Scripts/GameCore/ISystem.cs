using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public interface ISystem
    {
        void OnSystemInit();
        void OnSystemUnInit();
    }
}
