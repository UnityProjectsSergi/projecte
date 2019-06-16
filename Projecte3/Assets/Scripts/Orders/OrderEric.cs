using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class OrderEric 
{
    public Sprite img;
    public int _points;
    public List<Item> _ingredients;
    public bool isTriggered;
    public bool isServed;
    public OrderUIEric _orderUI;
    public bool isTimeOut;
    public float duration = 3f;
    public OrderEric.OrderRes OrderLost;
    public OrderEric.OrderRes OrderServed;
    // Use this for initialization
    public OrderEric(List<Item> ingredients, int points, OrderUIEric orderUI)
    {
        _points = points;

        _ingredients = ingredients;
        _orderUI = orderUI;
    }
    public OrderEric(List<Item> ingredients, float duracio, OrderRes res)
    {


        _ingredients = ingredients;
        duration = duracio;
        OrderServed += res;
        //SetPointsOder(_ingredients);
    }

    private void SetPointsOder(List<Item> ingredients)
    {
        foreach (var item in ingredients)
        {
            _points += item.points;
        }
    }
    public void HideUIOrder()
    {
        _orderUI.gameObject.SetActive(false);
        _orderUI.gameObject.transform.parent = null;
    }

    public void SetOrderUi(OrderUIEric ordrrui)
    {

        _orderUI = ordrrui;
        _orderUI.duration = duration;
        _orderUI.Order = this;
        _orderUI.SetCooldown();
    }
    public bool IsServed()
    {
        return isServed;
    }
    public bool IsTimeout()
    {
        return _orderUI.timeout;
    }


    internal void _OrderServed(OrderEric order)
    {
        _orderUI.OrderServed(OrderServed, order);
    }
    public delegate void OrderRes(OrderEric order);


}
