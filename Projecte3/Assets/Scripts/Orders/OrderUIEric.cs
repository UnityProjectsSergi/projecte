using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Edelweiss.Coroutine;

public class OrderUIEric : MonoBehaviour
{
    public Image imageTimeOut;
   
    public float duration;
    public float timeOutValue;
    public OrderEric Order;
    public Image SpriteToChange;
    public bool timeout;
    private float totalTime;
    public SkackeGameObject SkackeGameObject;
    public Color ColorOrderServed;
    public Color ColorOrderLost;
    public Color InitColorBarTimeOut;
    public Color FinishColorBarTimeOut;
    
    public Image[] listImags;

    public Color TimeOutColor;
    public SafeCoroutine CountDown;
    public SafeCoroutine OrderLostCo, OrderServedCo;
    public void Start()
    {
        timeout = false;
        totalTime = 0;
        SkackeGameObject = GetComponent<SkackeGameObject>();
        this.StartCoroutine(Countdown());
        listImags = GetComponentsInChildren<Image>();
    }
    public void SetCooldown()
    {  }
    public void SetSpitre(Sprite sprite)
    {
        SpriteToChange.sprite = sprite;
    }

    internal void OrderServed(OrderEric.OrderRes order, OrderEric order1)
    {
      OrderServedCo=this.StartSafeCoroutine(FadeTo(listImags,ColorOrderServed, 1f, 1f,order,order1));
    }
    IEnumerator FadeTo(Image[] imageList,Color  color, float aTime, float bTime,OrderEric.OrderRes order=null,OrderEric orderObj=null)
    {
        for (int i = 0; i < imageList.Length; i++)
        {
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
            {
                Color newColor = Color.Lerp(imageList[i].color, color,t);// new Color.(image[i].color.r, image[i].color.g, image[i].color.b, Mathf.Lerp(alpha, aValue, t));
                imageList[i].color = newColor;
               
            }
            yield return null;
        }
        CanvasGroup canvas = GetComponent<CanvasGroup>();
        for (float f = 0; f <= 2; f += Time.deltaTime / bTime)
        {
            canvas.alpha = Mathf.Lerp(1f, 0f, f);
            yield return null;
        }
        if(order!=null)
        {
            order.Invoke(orderObj);
        }
    }

    internal void OrderLost(OrderEric.OrderRes order)
    {

    }

    public void Update()
    {
        UpdateTimeOut();
    }
    public void UpdateTimeOut()
    {
        if(timeOutValue<0.750 && timeOutValue >0.749)
        {
            Order._points -= 1;
        }
        if (timeOutValue < 0.50 && timeOutValue > 0.499)
        {
            Order._points -= 2;
        }
        if (timeOutValue < 0.25 && timeOutValue > 0.249)
        {
            Order._points -= 2;
        }
        if (timeOutValue < 0.15f)
        {
            SkackeGameObject.InduceShacke(0.5f);
        }
        if (timeOutValue < 0.07f)
        {
            StartCoroutine(FadeTo(listImags,ColorOrderLost, 1f, 1f));
        }
        imageTimeOut.fillAmount = timeOutValue;
        imageTimeOut.color = TimeOutColor;
    }
    public void OnEnable()
    {

    }
    public void OnDisable()
    {
        //RIDO Pause Cooldown
       
    }
    IEnumerator Countdown()
    {
        float totalTime = 0;
        while (totalTime <= duration)
        {
            if (!timeout)
            {
             
                    timeOutValue = Mathf.Lerp(1.0f, 0.0f, totalTime / duration);
                    TimeOutColor = Color.Lerp(InitColorBarTimeOut, FinishColorBarTimeOut, totalTime / duration);
                    totalTime += Time.deltaTime;
                    if (timeOutValue <= 0.03f)
                        timeout = true;
                  yield return null;
            }
           
        }
        
    }

}