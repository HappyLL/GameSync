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
        avatarNameTxt.text = $"角色名字: {ProxyMgr.GetInstance().GetAvatarProxy().avatarName}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
