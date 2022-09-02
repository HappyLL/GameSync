using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameState;
using KBE;

public class ClientGame : KBEMain
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        ProxyMgr.GetInstance().Init();

        GameStateMgr.GetInstance().ChangeState(GameStateType.NoLogin);
    }

    public override void installEvents()
    {
        base.installEvents();
        //KBEngine.Event
    }

    // Update is called once per frame
    void Update()
    {
        GameStateMgr.GetInstance().Update();
    }

    void OnDestroy()
    {
        base.OnDestroy();
        ProxyMgr.GetInstance().UnInit();
        GameStateMgr.GetInstance().Destroy();    
    }

}
