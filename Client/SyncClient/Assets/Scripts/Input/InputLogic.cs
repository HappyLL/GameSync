using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore;

public class InputLogic : MonoBehaviour
{

    private KeyCode[] hookKeyCodes = { KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.D };
    private InputKeyType[] keyTypes = {InputKeyType.LEFT, InputKeyType.UP, InputKeyType.DOWN, InputKeyType.RIGHT };
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Player GetMainPlayer()
    {
        var playerSystem = GameSystem.GetInstance().GetSystem<PlayerSystem>();
        return playerSystem != null ? playerSystem.GetMainPlayer(): null;
    }

    private void KeyDownLogic()
    {
        for(int i = 0; i < hookKeyCodes.Length; ++i)
        {
            if (Input.GetKeyDown(hookKeyCodes[i]))
            {
                Debug.Log("KeyDownLogic is " + hookKeyCodes[i]);
                var mainPlayer = GetMainPlayer();
                if(mainPlayer != null)
                    mainPlayer.InputManager.OneKeyDown(keyTypes[i]);
            }
        }
    }

    private void KeyUpLogic()
    {
        for (int i = 0; i < hookKeyCodes.Length; ++i)
        {
            if (Input.GetKeyUp(hookKeyCodes[i]))
            {
                Debug.Log("KeyUpLogic is " + hookKeyCodes[i]);
                var mainPlayer = GetMainPlayer();
                if (mainPlayer != null)
                    mainPlayer.InputManager.OneKeyUp(keyTypes[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        KeyDownLogic();
        KeyUpLogic();
    }
}
