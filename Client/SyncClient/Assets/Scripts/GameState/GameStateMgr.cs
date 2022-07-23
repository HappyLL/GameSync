using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameState
{
    public enum GameStateType
    {
        None, 
        NoLogin, //未登录
        MainCity, //在主城
        InFight, //在战斗中
    }
    //游戏状态管理器
    public class GameStateMgr
    {
        private Dictionary<GameStateType, GameBaseState> _stateTypeToState;
        private GameBaseState _curState;
        private GameStateType _curStateType = GameStateType.None;

        private static GameStateMgr _ins;
        public static GameStateMgr GetInstance()
        {
            if(_ins == null)
            {
                _ins = new GameStateMgr();
            }
            return _ins;
        }

        public void Destroy()
        {
            if (_curState != null)
            {
                _curState.OnExit();
            }
            foreach(var stateInfo in _stateTypeToState)
            {
                stateInfo.Value.Destroy();
            }
            _stateTypeToState = null;
            _ins = null;
        }

        public GameStateMgr()
        {
            _stateTypeToState = new Dictionary<GameStateType, GameBaseState>();
            _stateTypeToState[GameStateType.NoLogin] = new GameNoLoginState();
            _stateTypeToState[GameStateType.MainCity] = new GameMainCityState();
            _stateTypeToState[GameStateType.InFight] = new GameInFightState();
            _curState = null;
            _curStateType = GameStateType.None;
        }

        public void ChangeState(GameStateType stateType)
        {
            if(stateType == _curStateType)
            {
                return;
            }

            _stateTypeToState.TryGetValue(_curStateType, out GameBaseState curState);
            if(curState != null)
                curState.OnExit();
            _stateTypeToState.TryGetValue(stateType, out GameBaseState state);
            if(state != null)
                state.OnEnter();
            _curStateType = stateType;
            _curState = state;
        }

        public void Update()
        {
            if (_curState == null)
                return;
            _curState.Update();
        }
        
        public GameStateType GetCurStateType()
        {
            return _curStateType;
        }

    }
}