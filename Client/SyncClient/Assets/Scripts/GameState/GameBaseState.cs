using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameState
{
    class GameBaseState
    {
        public const GameStateType stateType = GameStateType.None;
        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void Update() { }

        public virtual void Destroy() { }
    }
}
