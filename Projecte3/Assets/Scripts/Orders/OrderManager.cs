using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
    class OrderManager:MonoBehaviour
    {
    private static OrderManager _instance;
    public static OrderManager Instance { get { return _instance; } private set { } }
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
        listOrders.Add(OrderGenerator.GenerateOrder(5));
    }
    public Order FoundOrder;
    public bool CheckAllOrder(VialItem item)
    {
       //
        bool found1=false;
        foreach (var order in listOrders)
        {
            if (!order.isServed)
            {
                FoundOrder = null;

                if (!Utils.CompareLists<Item>(order._ingredients, item.listItem))
                {
                    found1 = true;
                    FoundOrder = order;
                    order.isServed = true;
                    break;
                }
            }
            

        }
        return found1;
    }
    //public bool CheckOrder(Order order,Item item)
    //{
        
    //}
    public void RemoveOrder()
    {

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddOrder();
        }
    }
}

