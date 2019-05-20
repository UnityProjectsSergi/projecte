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
    public Color TimeOutColor;
    public SkackeGameObject SkackeGameObject;
    public Image ImageOrderServed;
    public Image ImageOrderLost;
    public Color InitColor;
    public Color FinishColor;


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
    }

    internal void OrderServed(Order.OrderRes order, Order order1)
    {
        StartCoroutine(FadeTo(ImageOrderServed, 0.5f, 0.5f, 0.5f,order,order1));
    }
    IEnumerator FadeTo(Image image, float aValue, float aTime, float bTime,Order.OrderRes order=null,Order orderObj=null)
    {

        float alpha = image.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(alpha, aValue, t));
            image.color = newColor;
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
        if (timeOutValue < 0.05f)
        {
            StartCoroutine(FadeTo(ImageOrderLost, 0.5f, 0.5f, 0.5f));
        }
        imageTimeOut.fillAmount = timeOutValue;
        imageTimeOut.color = TimeOutColor;
    }

    IEnumerator Countdown()
    {
        // 3 seconds you can change this to
        //to whatever you want
        float totalTime = 0;
        while (totalTime <= duration)
        {
            if (!timeout)
            {
                timeOutValue = Mathf.Lerp(1.0f, 0.0f, totalTime / duration);
                TimeOutColor = Color.Lerp(InitColor, FinishColor, totalTime / duration);
                totalTime += Time.deltaTime;
                if (timeOutValue <= 0.01f)
                    timeout = true;
            }
            yield return null;
        }
    }

}