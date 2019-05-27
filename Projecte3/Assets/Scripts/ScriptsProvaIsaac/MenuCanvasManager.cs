using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvasManager : MonoBehaviour
{
    enum MenuState
    {
        Ini,
        Selector
    }

    MenuState currentState = MenuState.Ini;

    public UI_System uiController;

    private void Update()
    {
        
        switch(currentState)
        {
            /*
            case MenuState.Ini:
                if (Input.GetAxis("J1SettingsButtonPS4") > 0)
                    //uiController.CloseScree
                break;
                */
        }
        
    }
}
