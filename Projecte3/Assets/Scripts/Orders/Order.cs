using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
[System.Serializable]
public class Order
{
    public int points;
    public List<Item> ingredients;
    public bool isServed;
    public OrderUI orderUI;
    public bool isTimeOut;
    public float duration = 3f;
    public Image countdownImage;
    private IEnumerator Countdown()
    {
       // 3 seconds you can change this to
                             //to whatever you want
        float totalTime = 0;
        while (totalTime <= duration)
        {
            countdownImage.fillAmount = totalTime / duration;
            totalTime += Time.deltaTime;
            var integer = (int)totalTime; /* choose how to quantize this */
                                          /* convert integer to string and assign to text */
            yield return null;
        }
    }
}


