using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_System : MonoBehaviour
{
    public UI_Screen currentScreen;
    public UI_Screen previousScreen;
    public UI_Screen startScreen;
    // Start is called before the first frame update
    void Start()
    {
        SwitchScreen(startScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchScreen(UI_Screen newScreen)
    {
        if(newScreen)
        {
            if(currentScreen)
            {
                currentScreen.CloseScreen();
                previousScreen = currentScreen;
            }
            newScreen.gameObject.SetActive(false);
            currentScreen = newScreen;
            currentScreen.gameObject.SetActive(true);
            currentScreen.OpenScreen();
        }
    }
    public void GoToPreviousScreen()
    {
        if (previousScreen)
            SwitchScreen(previousScreen);
    }
}
