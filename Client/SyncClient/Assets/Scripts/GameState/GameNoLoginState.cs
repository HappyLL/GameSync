using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameState
{
    class GameNoLoginState: GameBaseState
    {
        public new const GameStateType stateType = GameStateType.NoLogin;
        public override void OnEnter()
        {
            GameObject.Find("UIRoot").GetComponent<UIRoot>().ShowUI("LoginUI");
        }

        public override void OnExit()
        {
            GameObject.Find("UIRoot").GetComponent<UIRoot>().HideUI("LoginUI");
        }
    }
}
