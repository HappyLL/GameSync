using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameState
{
    class GameMainCityState: GameBaseState
    {
        public new const GameStateType stateType = GameStateType.MainCity;
        public override void OnEnter()
        {
            base.OnEnter();
            GameObject.Find("UIRoot").GetComponent<UIRoot>().ShowUI("MainCityUI");
        }

        public override void OnExit()
        {
            base.OnExit();
            GameObject.Find("UIRoot").GetComponent<UIRoot>().HideUI("MainCityUI");
        }
    }
}
