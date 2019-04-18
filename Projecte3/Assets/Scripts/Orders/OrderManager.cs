using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using UnityEngine;
    class OrderManager:MonoBehaviour
    {
    private static OrderManager _instance;
    public static OrderManager Instance { get { return _instance; } private set { } }
    public Queue<Order> listOrdderQueue = new Queue<Order>();
    public List<Order> listOrders = new List<Order>();
    public OrderGenerator OrderGenerator;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
         //   listOrders = new List<Order>();
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void AddOrder()
    {
        listOrders.Add(OrderGenerator.GenerateOrder(2));
       // listOrders.Add();
    }
    public Order FoundOrder;
    public bool CheckAllOrder(VialItem item)
    {
       //
        bool found1=false;
        foreach (var order in listOrders)
        {
        //    Debug.Log("ss");
            if (!order.isServed)
            {
                // checkeo si els ingredients de la ordre q em donen el tinc a una ordre de la llista 
                FoundOrder = null;
                if (Utils.CompareLists2<Item>(order._ingredients, item.listItem))
                {
                    found1 = true;
                    FoundOrder = order;
                    order.isServed = true;
                    order.HideUIOrder();
                    break;
                }
            }
        }
        return found1;
    }
    //public bool CheckOrder(Order order,Item item)
    //{
        
    //}
    public void RemoveOrder(Order m)
    {
        listOrders.Remove(m);
    }
    public void Update()
    {
        // Test
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddOrder();
        }
        CheckIfOrderListHasTimeOut();
    }
    public void CheckIfOrderListHasTimeOut()
    {
        foreach (var order in listOrders)
        {
            if (!order.isServed)
            {
                if(order.isTimeout())
                {
                    order.HideUIOrder();
                }
            }
        }
    }
}

