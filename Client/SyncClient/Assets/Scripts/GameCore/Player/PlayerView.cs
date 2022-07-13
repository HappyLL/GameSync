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
        private GameObject _view;
        public PlayerView(uint uid, GameObject prefab)
        {
            _uid = uid;
            var parentObject = GameObject.Find("Players");
            _view = GameObject.Instantiate<GameObject>(prefab);
            _view.transform.SetParent(parentObject.transform);
            UpdatePositionImm();
        }

        private Vector3? GetViewPosition()
        {
            var playerSystem = GameSystem.GetInstance().GetSystem<PlayerSystem>();
            var player = playerSystem.GetTargetPlayer(_uid);
            if (player == null)
            {
                return null;
            }
            var logicPosition = player.Position;
            return new Vector3(logicPosition.x, logicPosition.y, logicPosition.z);
        }

        private void UpdatePositionImm()
        {
            var viewPos = GetViewPosition();
            if (viewPos == null)
                return;
            _view.transform.position =(Vector3)viewPos;
        }

        private void UpdatePositionLerp()
        {
            

        }

        public void Update(float dt)
        {
            var viewPos = GetViewPosition();
            if (viewPos == null)
                return;
            _view.transform.position = Vector3.Lerp(_view.transform.position, (Vector3)viewPos, dt);
        }

        public void Destroy()
        {
            GameObject.Destroy(_view);
            _view = null;
        }

    }
}
