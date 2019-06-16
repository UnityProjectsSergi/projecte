using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

class OrderManagerEric:MonoBehaviour
{
    private static OrderManagerEric _instance;
    public static OrderManagerEric Instance { get { return _instance; } private set { } }
    public Queue<Order> listOrdderQueue = new Queue<Order>();
    public List<OrderEric> listOrders = new List<OrderEric>();
    public OrderGeneratorEric OrderGenerator;
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
        SoundManager.Instance.OneShotEventAttatchet("event:/INFORMACIÓN JUGADOR/RECETA ENTRANTE", this.gameObject);
        listOrders.Add(OrderGenerator.GenerateOrderEric(TypeCounter, numIngredients, duracióOfOder, ServeOrder));
        TypeCounter++;

    }
    public void Start()
    {
   
        InvokeRepeating("order", 2f, SegWaitTo2onOrder);
    }
    public void order()
    {
        if (NumIngredientsOfOrders > 0)
        {
         
            AddOrder(TypeCounter, NumIngredientsOfOrders, durationOfOrders);
        }
        else

        {
            Debug.LogWarning("need to add number of ingedients to orderManager");
        }

    }


    public float TypeCounter;

    public void ServeOrder(OrderEric order)
    {
        SoundManager.Instance.OneShotEventAttatchet("event:/INFORMACIÓN JUGADOR/ENTREGADO/ENTREGADO BIEN", this.gameObject);
        order.HideUIOrder();
        Debug.Log("Oder pounts noew" + order._points + "points now" + pointsUI);
      //  pointsUI += order._points;
        RemoveOrder(order);
    }
    // nessesito algu q em ju
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
                    pointsUI += 5;
             //       SoundManager.Instance.OneShotEventAttatchet("event:/Sounds/Effects/OrderGet", this.gameObject);
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

    public void RemoveOrder(OrderEric m)
    {
        SoundManager.Instance.OneShotEventAttatchet("event:/INFORMACIÓN JUGADOR/ENTREGADO/ENTREGADO MAL", this.gameObject);
        listOrders.Remove(m);
    }

    public void Update()
    {

        if (listOrders.Count == 0)
            AddOrder(TypeCounter, NumIngredientsOfOrders, durationOfOrders);
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
                    //qunat s'acabi el temps rest a4 sempre 
                    listOrders[i].HideUIOrder();
                    // aqui detecta quant el temps de s'acaa 
                    pointsUI -= 2;
                    RemoveOrder(listOrders[i]);
                }
            }

        } 
    }
   
    public void OrderServed()
    {

    }
}

