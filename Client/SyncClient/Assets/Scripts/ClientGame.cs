using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameState;

public class ClientGame : KBEMain
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        GameStateMgr.GetInstance().ChangeState(GameStateType.NoLogin);
    }

    // Update is called once per frame
    void Update()
    {
        GameStateMgr.GetInstance().Update();
    }

    void OnDestroy()
    {
        base.OnDestroy();
        GameStateMgr.GetInstance().Destroy();    
    }

}
