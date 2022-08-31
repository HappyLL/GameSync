using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;
using Event = KBEngine.Event;

public class LoginUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Button m_Button;
    public InputField m_InputField;
    void Start()
    {
        m_Button.onClick.AddListener(() =>
        {
            if(m_InputField.text.Length == 0)
            {
                Debug.LogError("inputField text empty");
                return;
            }
            Event.fireIn(EventInTypes.login, m_InputField.text, "", new byte[1] { 0});
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
