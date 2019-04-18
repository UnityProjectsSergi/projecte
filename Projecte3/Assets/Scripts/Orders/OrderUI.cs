using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI:MonoBehaviour
{
    public Image imageTimeOut;
    public List<ItemUI> ItemUIlist=new List<ItemUI>();
    public float duration;
    public float timeOutValue;
    public GameObject ListItemsUIParent;
    public bool timeout;
    public Color TimeOutColor;
    public void Start()
    {
        timeout = false;
        StartCoroutine(Countdown());
        
    }
    public void generateItemsUI()
    {
        RectTransform rect = GetComponent<RectTransform>();
        float withOfRect= rect.rect.width;
        Debug.Log(withOfRect);
        float withOfChilds = withOfRect / ItemUIlist.Count;
        Debug.Log(withOfChilds);
        foreach (var item in ItemUIlist)
        {
            item.gameObject.transform.SetParent(ListItemsUIParent.transform);
            item.gameObject.transform.position = transform.position;
            item.gameObject.transform.rotation = transform.rotation;
            item.gameObject.transform.localScale = transform.localScale;
            item.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, withOfChilds);
        }
    }
    public void Update()
    {
        UpdateTimeOut();
    }
    public void UpdateTimeOut()
    {

        imageTimeOut.fillAmount = timeOutValue;
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

            totalTime += Time.deltaTime;
            if (timeOutValue < 0.01f)
                timeout = true;
        }
            yield return null;
        }
    }

}