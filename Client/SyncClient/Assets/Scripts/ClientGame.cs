using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore;

public class ClientGame : Game
{
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        PlayerSystem playerSystem = GameSystem.GetInstance().GetSystem<PlayerSystem>();
        var playerInfo = new PlayerInfo();
        playerInfo.uid = 1;
        playerInfo.isMainPlayer = true;
        playerSystem.RegisterPlayer(playerInfo.uid, playerInfo);
    }
}
