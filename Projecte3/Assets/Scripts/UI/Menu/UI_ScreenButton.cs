using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_ScreenButton : UI_Screen
{
    public float timerToClose = 2;
    private float timer = 0;
    public bool isOpen;

    public UnityEvent OnComplete;
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            if (InputManager.Instance.GetButtonDown("J1XButtonPS4") || InputManager.Instance.GetButtonDown("J2XButtonPS4")
                || InputManager.Instance.GetButtonDown("J3XButtonPS4") || InputManager.Instance.GetButtonDown("J4XButtonPS4"))
            {
                OnComplete.Invoke();
            }
        }
    }
    public override void CloseScreen()
    {
        isOpen = false;
        base.CloseScreen();
    }
    public override void OpenScreen()
    {
        isOpen = true;


        base.OpenScreen();


    }



}
