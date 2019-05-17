using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;

public class Order
{
    public int _points;
    public List<Item> _ingredients;
    public bool isTriggered;
    public bool isServed;
    public OrderUI _orderUI;
    public bool isTimeOut;
    public float duration = 3f;
    public Order.OrderRes OrderLost;
    public Order.OrderRes OrderServed;

    public Order (List<Item> ingredients,int points,OrderUI orderUI)
    {
        _points = points;

        _ingredients = ingredients;
        _orderUI = orderUI;
    }
    public Order(List<Item> ingredients, int points,float duracio,OrderRes  res)
    {
      
        _points = points;
        _ingredients = ingredients;
        duration = duracio;
        OrderServed += res;
      
    }
    public void HideUIOrder()
    {
        _orderUI.gameObject.SetActive(false);
        _orderUI.gameObject.transform.parent = null;
    }
    
    public void SetOrderUi(OrderUI ordrrui)
    {
        _orderUI = ordrrui;
        _orderUI.duration = duration;
    }
    public bool IsServed()
    {
        return isServed;
    }
    public bool IsTimeout()
    {
        return _orderUI.timeout;
    }
  

    internal void _OrderServed(Order order)
    {
        _orderUI.OrderServed(OrderServed, order);
    }
    public delegate void OrderRes(Order order);
   
   
}


