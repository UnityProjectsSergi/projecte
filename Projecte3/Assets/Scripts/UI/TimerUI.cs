using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Text textTimer;
    public float timeLeft = 300.0f;
    public GameObject TimerUP;
   
    public bool clock;
    private float mins;
    private float secs;
    public bool isPaused;
    bool isStop = false;

    public float timeChangeScene;
    public string nameNextScene;

    void Start()
    {
        textTimer = GetComponent<UnityEngine.UI.Text>();
    }

    void Update()
    {
        if (!isPaused)
        {
            if (timeLeft > 0.0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer();
            }
            else
            {
                if (!isStop)
                    isStop = true;
                TimerUP.SetActive(true);
                Time.timeScale = 0.0f;
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