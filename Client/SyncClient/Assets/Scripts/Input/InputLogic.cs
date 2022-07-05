using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLogic : MonoBehaviour
{

    private KeyCode[] hookKeyCodes = {KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.D };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void KeyDownLogic()
    {
        for(int i = 0; i < hookKeyCodes.Length; ++i)
        {
            if (Input.GetKeyDown(hookKeyCodes[i]))
            {
                Debug.Log("KeyDownLogic is "+ hookKeyCodes[i]);

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
