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
    public List<Order> listOrders;
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            listOrders = new List<Order>();
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void AddOrder()
    {

    }
    public void CheckAllOrder(VialItem item)
    { 
        foreach (var order in listOrders)
        {
            
        }
    }
    //public bool CheckOrder(Order order,Item item)
    //{
        
    //}
    public void RemoveOrder()
    {

    }
}

