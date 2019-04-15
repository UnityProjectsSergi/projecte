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
    public bool isTriggered;
    public bool isServed;
    public OrderUI orderUI;
    public bool isTimeOut;
    public float duration = 3f;

   
}


