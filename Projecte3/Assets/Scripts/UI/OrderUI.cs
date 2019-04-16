using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI:MonoBehaviour
{
    public Image imageTimeOut;
    public List<ItemUI> ItemUIlist=new List<ItemUI>();
    public float duration;
    public GameObject ListItemsUIParent;
   
    public void Start()
    {
       
    }
    public void generateItems()
    {
        RectTransform rect = GetComponent<RectTransform>();
        float withOfRect= rect.rect.width;
        Debug.Log(withOfRect);
        float withOfChilds = withOfRect / ItemUIlist.Count;
        Debug.Log(withOfChilds);
        foreach (var item in ItemUIlist)
        {
        //    Debug.Log(item);
             item.gameObject.transform.SetParent(ListItemsUIParent.transform);
            item.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, withOfChilds);
        }
    }
    IEnumerator Countdown()
    {
        // 3 seconds you can change this to
        //to whatever you want
        float totalTime = 0;
        while (totalTime <= duration)
        {
            imageTimeOut.fillAmount = totalTime / duration;
            totalTime += Time.deltaTime;
            var integer = (int)totalTime; /* choose how to quantize this */
                                          /* convert integer to string and assign to text */
            yield return null;
        }
    }

}