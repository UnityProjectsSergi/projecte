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

    }
    public bool CheckAllOrder(VialItem item)
    {
        bool found1=false;
        foreach (var order in listOrders)
        {
            List<Item> difsItem;
            if (order.ingredients.Count == item.listItem.Count)
            {
                difsItem = order.ingredients.Where(a => item.listItem.Any(b => a.namme.Equals(b.namme))).ToList();
                if (difsItem.Count == item.listItem.Count)

                    found1 = true;
            }
            //  difsItem =  order.ingredients.Where(p1 => item.listItem.Any(p2 => p1.name == p2.name)).ToList();
                            return true;
        }
        if (found1)
            return true;
        return false;
    }
    //public bool CheckOrder(Order order,Item item)
    //{
        
    //}
    public void RemoveOrder()
    {

    }
}

