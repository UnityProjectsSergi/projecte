using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    public Image imageTimeOut;
    public List<ItemUI> ItemUIlist = new List<ItemUI>();
    public float duration;
    public float timeOutValue;
    public GameObject ListItemsUIParent;
    public bool timeout;
   
    public SkackeGameObject SkackeGameObject;
    public Color ColorOrderServed;
    public Color ColorOrderLost;
    public Color InitColorBarTimeOut;
    public Color FinishColorBarTimeOut;

    public Image[] listImags;

    public Color TimeOutColor;

    public void Start()
    {
        timeout = false;
        SkackeGameObject = GetComponent<SkackeGameObject>();
        StartCoroutine(Countdown());
      
    }
    public void generateItemsUI()
    {
        RectTransform rect = GetComponent<RectTransform>();
        float withOfRect = rect.rect.width;

        float withOfChilds = withOfRect / ItemUIlist.Count;

        foreach (var item in ItemUIlist)
        {
            item.gameObject.transform.SetParent(ListItemsUIParent.transform);
            item.gameObject.transform.position = transform.position;
            item.gameObject.transform.rotation = transform.rotation;
            item.gameObject.transform.localScale = transform.localScale;
            item.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, withOfChilds);
        }
        listImags = GetComponentsInChildren<Image>();
    }

    internal void OrderServed(Order.OrderRes order, Order order1)
    {
        StartCoroutine(FadeTo(listImags,ColorOrderServed, 1f, 1f,order,order1));
    }
    IEnumerator FadeTo(Image[] imageList,Color  color, float aTime, float bTime,Order.OrderRes order=null,Order orderObj=null)
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

    internal void OrderLost(Order.OrderRes order)
    {

    }

    public void Update()
    {
        UpdateTimeOut();
    }
    public void UpdateTimeOut()
    {

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
        //TODO Resume Cooldown
        Debug.Log("ssssm");
    }
    public void OnDisable()
    {
        //RIDO Pause Cooldown
        Debug.Log("ssss");
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
            }
            yield return null;
        }
    }

}