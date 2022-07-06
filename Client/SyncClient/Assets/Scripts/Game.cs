using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore;
public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        GameSystem.GetInstance().OnSystemInit();
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
