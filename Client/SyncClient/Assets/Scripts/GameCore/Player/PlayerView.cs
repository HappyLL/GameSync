using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameCore
{
    class PlayerView : IUpdate
    {
        private uint _uid;
        public PlayerView(uint uid, GameObject prefab)
        {
            _uid = uid;
        }

        public void Update(float dt)
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {

        }

    }
}
