using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI:MonoBehaviour
{
    public Image imageTimeOut;
    public List<ItemUI> ItemUIlist;
    public float duration;
    public OrderUI()
    {

    }
    public void Start()
    {
        ItemUIlist = new List<ItemUI>();
    }
    public void generateItems()
    {

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