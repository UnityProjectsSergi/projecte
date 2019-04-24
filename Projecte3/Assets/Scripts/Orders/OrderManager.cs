using System;
using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class OrderManager:MonoBehaviour
    {
    private static OrderManager _instance;
    public static OrderManager Instance { get { return _instance; } private set { } }
    public Queue<Order> listOrdderQueue = new Queue<Order>();
    public List<Order> listOrders = new List<Order>();
    public OrderGenerator OrderGenerator;
    public int points;
    public float SegWaitTo2onOrder=35f;
    public Text Points;
    public Text textO;
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
    public void AddOrder(float num,int ingredients,float time)
    { 
        listOrders.Add(OrderGenerator.GenerateOrder(num,ingredients,time));


    }
    public void Start()
    {
        AddOrder(0.4f, 3, 100);
        Invoke("SecondOrder", SegWaitTo2onOrder);
    }
    public void SecondOrder()
    {
        AddOrder(0.7f, 3, 45);
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
                    points+= order._points;
                    OrderManager.Instance.RemoveOrder(order);
                    
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
        if (listOrders.Count == 0)
            SecondOrder();
        CheckIfOrderListHasTimeOut();
        Points.text = points.ToString();
    }
    public void CheckIfOrderListHasTimeOut()
    {
        for (int i = 0; i < listOrders.Count; i++)
        {
            if(!listOrders[i].IsServed())
            {
                if (listOrders[i].IsTimeout())
                {
                    listOrders[i].HideUIOrder();
                    points -= listOrders[i]._points;
                    textO.text = "OrderLost";
                    StartCoroutine(HideText(5f));
                    RemoveOrder(listOrders[i]);
                }
            }

        } 
    }
    IEnumerator HideText(float num)
    {
        yield return new WaitForSeconds(num);
        textO.text = "";
    //    listOrders.Add(OrderGenerator.GenerateOrder(0.3f, ingredients, time));
    }
}

