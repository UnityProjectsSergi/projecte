using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public TimerUI timeUi;
    public PauseController pauseController;
    public UI_System UI_System;
    public UI_Screen SoundScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

         timeUi.isPaused = pauseController.isPausedGame;
     
    }
    public void OpenSoundOptions()
    {
        if (pauseController.isPausedGame)
        {
            UI_System.SwitchScreen(SoundScreen);
        }
    }

}
