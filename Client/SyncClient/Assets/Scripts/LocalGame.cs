using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore;

public class LocalGame : MonoBehaviour
{
    public void Start()
    {
        GameSystem.GetInstance().OnSystemInit();
        PlayerSystem playerSystem = GameSystem.GetInstance().GetSystem<PlayerSystem>();
        var playerInfo = new PlayerInfo();
        playerInfo.uid = 1;
        playerInfo.isMainPlayer = true;
        playerSystem.RegisterPlayer(playerInfo.uid, playerInfo);
    }

    // Update is called once per frame
    public void Update()
    {
        GameSystem.GetInstance().Update();
    }

    public void OnDestroy()
    {
        GameSystem.GetInstance().OnSystemUnInit();
    }

}
