using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initscren : MonoBehaviour
{
    public UI_System system;
    public UI_Screen nextScreen;
    public SelectorManager selector;

    // Update is called once per frame
    void Update()
    {
        if(InputManager.Instance.GetButtonDown("J1SettingsButtonPS4"))
        {
            system.SwitchScreen(nextScreen);
            selector.enabled = true;
        }
    }
}
