using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [Header("Pause Varriables")]
    /// <summary>
    /// Says if stay in Main Menu (false) So there's no allow enter to pause menu and when its (true) can open and close pause menu   
    /// </summary>
    public bool AllowEnterPause;
    /// <summary>
    ///  Says if Stay in pause menu or Gameplay Screens
    /// </summary>
    public bool isPausedGame;
    public UI_Screen GamePlayScreen;
    public UI_Screen PauseScreen;
    public UI_System System;
    public float TimeBetweenPause = 1f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        System = GetComponent<UI_System>();
    }

    // Update is called once per frame
    void Update()
    {
        bool Switch = (InputManager.Instance.GetButtonDown("J1SettingsButtonPS4") || InputManager.Instance.GetButtonDown("J2SettingsButtonPS4"));
        if(AllowEnterPause  && Time.time>=timer && Switch)
        {
            isPausedGame =! isPausedGame;
            OrderManager.Instance.isPausedGame = isPausedGame;
            if(isPausedGame)
            {
                System.SwitchScreen(PauseScreen);
            }
            else
            {
                System.SwitchScreen(GamePlayScreen);
            }
            timer = Time.time + TimeBetweenPause;
        }
    }
}
