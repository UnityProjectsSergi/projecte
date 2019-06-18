using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Text textTimer;
    public float timeLeft = 300.0f;
    public UI_Screen TimerUP;
    public UI_System System;
    public bool clock;
    private float mins;
    private float secs;
    public bool isPaused;
    bool isStop = false;
    FMOD.Studio.EventInstance EventInstance;
    public float timeChangeScene;
    public string nameNextScene;
    private bool hasStartSound;

    void Start()
    {
        EventInstance = SoundManager.Instance.CreateEventInstaceAttached("event:/INFORMACIÓN JUGADOR/SONIDO CUENTA ATRÁS", this.gameObject);
        textTimer = GetComponent<UnityEngine.UI.Text>();
    }

    void Update()
    {
        if (!isPaused)
        {
            if (timeLeft > 0.0)
            {
                if (!hasStartSound && timeLeft < 30.0f  )
                {
                    hasStartSound = true;
                    EventInstance.start();
                }
                timeLeft -= Time.deltaTime;
                UpdateTimer();
            }
            else
            {
                if (!isStop)
                {
                    EventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    System.SwitchScreen(TimerUP);
                    isStop = true;
                }
                

            }
        }

        if (nameNextScene != null)
        {
            if (isStop)
            {
                if (timeChangeScene > 0.0)
                    timeChangeScene -= Time.unscaledDeltaTime;
                else
                    GameManager.Instance.LoadScene(nameNextScene);

            }
        }
    }

    void UpdateTimer()
    {
        int min = Mathf.FloorToInt(timeLeft / 60);
        
        int sec = Mathf.FloorToInt(timeLeft % 60);
        textTimer.text = min.ToString("00") + ":" + sec.ToString("00");
    }
}