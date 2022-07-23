using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : MonoBehaviour
{
    private GameObject curUI;
    // Start is called before the first frame update
    void Start()
    {
        ShowUI("LoginUI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowUI(string showUIName)
    {
        if(curUI)
        {
            if (curUI.name.Equals(showUIName))
            {
                return;
            }
            GameObject.Destroy(curUI);
            curUI = null;
        }
        var uiPrefab = Resources.Load<GameObject>("UI/" + showUIName);
        if(uiPrefab == null)
        {
            Debug.LogError(string.Format("showUIName {0} res is empty", showUIName));
            return;
        }
        curUI = GameObject.Instantiate<GameObject>(uiPrefab);
    }
}
