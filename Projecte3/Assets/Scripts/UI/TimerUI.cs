using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Text textTimer;
   
    // Start is called before the first frame update
    void Start()
    {
        textTimer=GetComponent<UnityEngine.UI.Text>();
    }
    public float timeLeft = 300.0f;
    public GameObject TimerUP;
   
 public   bool clock;
    private float mins;
    private float secs;
    public bool isPaused;

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
                TimerUP.SetActive(true);
                Time.timeScale = 0.0f;
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