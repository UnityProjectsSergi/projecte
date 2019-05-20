using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_ScreenTimer : UI_Screen
{
    public float timerToClose=2;
    private float timer = 0;
    public bool isOpen;
    public UnityEvent OnComplete;
    // Start is called before the first frame update
   public override void  Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public override void CloseScreen()
    {
        isOpen = false;
        base.CloseScreen();
    }
    public override void OpenScreen()
    {
        isOpen = true;
        timer = Time.time;

        base.OpenScreen();
        StartCoroutine(WaitForTime());

    }
    public IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timerToClose);
        if (OnComplete != null)
            OnComplete.Invoke();
    }


}
