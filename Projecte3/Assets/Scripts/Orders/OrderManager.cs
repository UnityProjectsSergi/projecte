using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

class OrderManager:MonoBehaviour
{
    private static OrderManager _instance;
    public static OrderManager Instance { get { return _instance; } private set { } }
    public Queue<Order> listOrdderQueue = new Queue<Order>();
    public List<Order> listOrders = new List<Order>();
    public OrderGenerator OrderGenerator;
    public int pointsUI;
    public float SegWaitTo2onOrder=35f;
    public Text Points;
    public int NumIngredientsOfOrders;
    public float durationOfOrders;

    public bool isPausedGame;
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
    public void AddOrder(float num, int numIngredients, float duracióOfOder)
    {
        
        listOrders.Add(OrderGenerator.GenerateOrder(IngCounter, numIngredients, duracióOfOder, ServeOrder));
        IngCounter++;

    }
    public void Start()
    {
   
        InvokeRepeating("order", 2f, SegWaitTo2onOrder);
    }
    public void order()
    {
        if(NumIngredientsOfOrders>0)
        AddOrder(IngCounter, NumIngredientsOfOrders, durationOfOrders);
        else
            
        {
            Debug.LogWarning("need to add number of ingedients to orderManager");
        }

    }


    public float IngCounter;

    public void ServeOrder(Order order)
    {
        order.HideUIOrder();
        pointsUI += order._points;
        RemoveOrder(order);
    }
    public bool CheckAllOrder(VialItem item)
    {
        foreach (var order in listOrders)
        {

            Debug.Log("checkings");
            if (!order.isServed)
            {

                List<Item> In1OfOrderList = order._ingredients.OfType<Ingredient1>().ToList<Item>();
                List<Item> Ing2OfOrderList = order._ingredients.OfType<Ingredient2>().ToList<Item>();
                List<Item> Ing3OfOrderList = order._ingredients.OfType<Ingredient3>().ToList<Item>();
                List<Item> equalItems2Ing2 = item.listItem.OfType<Ingredient2>().ToList<Item>();
                List<Item> equalItems2Ing1 = item.listItem.OfType<Ingredient1>().ToList<Item>();
                List<Item> equalItems2Ing3 = item.listItem.OfType<Ingredient3>().ToList<Item>();
                if (equalItems2Ing1.Count == In1OfOrderList.Count && equalItems2Ing2.Count == Ing2OfOrderList.Count && equalItems2Ing3.Count == Ing3OfOrderList.Count)
                {
                    Debug.Log("lists has same numbros of each ingredient");
                    order.isServed = true;
                    order._OrderServed(order);
                    return true;
                }
                // checkeo si els ingredients de la ordre q em donen el tinc a una ordre de la llista 
                //FoundOrder = null;
                //if (order._ingredients.Count == 0)
                //    return false;
                //if (item.listItem.Count == 0)
                //    return false;
                //if (order._ingredients.Count != item.listItem.Count)
                //    return false;
                //for (int i = 0; i < order._ingredients.Count; i++)
                //{
                //    if (order._ingredients[i].ing != item.listItem[i].ing)
                //        return false;
                //}
                // found1 = true;
                //    FoundOrder = order;
               
                
                //    return found1;
                //if (Utils.CompareLists2<Item>(order._ingredients, item.listItem))
                //{
                //   
                //   // break;
                //}
            }
        }
        return false;
     // com compares 2 llistes   
    }

    public void RemoveOrder(Order m)
    {
        listOrders.Remove(m);
    }

    public void Update()
    {

        if (listOrders.Count == 0)
            AddOrder(IngCounter, NumIngredientsOfOrders, durationOfOrders);
        CheckIfOrderListHasTimeOut();
        Points.text = pointsUI.ToString();
      
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
                    pointsUI -= listOrders[i]._points;
                    RemoveOrder(listOrders[i]);
                }
            }

        } 
    }
   
    public void OrderServed()
    {

    }
}

