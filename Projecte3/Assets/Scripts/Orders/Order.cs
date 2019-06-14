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
    public int _points=0;
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
    public Order(List<Item> ingredients, float duracio, OrderRes res)
    {
       
        
        _ingredients = ingredients;
        duration = duracio;
        OrderServed += res;
        SetPointsOder(_ingredients);
    }

    private void SetPointsOder(List<Item> ingredients)
    {
        foreach (var item in ingredients)
        {

            _points += item.points;

            Debug.Log(item.points + "ing pint" + _points + "ordeeerpints");
        }
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
        _orderUI.Order = this;
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


