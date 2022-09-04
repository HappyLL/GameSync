using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBE;

public class MainCityUI : MonoBehaviour
{
    public Text avatarNameTxt;
    public Button matchBtn;
    // Start is called before the first frame update
    void Start()
    {
        avatarNameTxt.text = $"½ÇÉ«Ãû×Ö: {ProxyMgr.GetInstance().GetAvatarProxy().avatarName}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
