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
    public int _points;
    public List<Item> _ingredients;
    public bool isTriggered;
    public bool isServed;
    public OrderUI _orderUI;
    public bool isTimeOut;
    public float duration = 3f;
   
    public Order (List<Item> ingredients,int points,OrderUI orderUI)
    {
        _points = points;
        _ingredients = ingredients;
        _orderUI = orderUI;
    }
   public void HasisServed()
    {
        _orderUI = null;
    }
}


