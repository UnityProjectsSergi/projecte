using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_System : MonoBehaviour
{
    public UI_Screen currentScreen;
    public UI_Screen previousScreen;
    public UI_Screen startScreen;
    public Component[] screens = new Component[0];
    // Start is called before the first frame update
    void Start()
    {
        
        screens = GetComponentsInChildren<UI_Screen>(true);
        InitiaizeScreens();
        SwitchScreen(startScreen);
    }
    public 
    // Update is called once per frame
    void Update()
    {

    }
    private void InitiaizeScreens()
    {
        foreach (var screen in screens)
        {

            screen.gameObject.SetActive(true);
            //screen.GetComponent<Image>().color = BGScreensColor;
        }
    }
    public void SwitchScreen(UI_Screen newScreen)
    {
        if (newScreen)
        {
            if (currentScreen)
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
