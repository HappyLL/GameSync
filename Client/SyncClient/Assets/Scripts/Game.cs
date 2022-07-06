using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore;
public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameSystem.GetInstance().OnSystemInit();
    }

    // Update is called once per frame
    void Update()
    {
        GameSystem.GetInstance().Update();
    }
    
    void OnDestroy()
    {
        GameSystem.GetInstance().OnSystemUnInit();
    }

}
