using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrderGenerator : MonoBehaviour
{

    // Use this for initialization
    public GameObject OrderUIPrefb;
    public Transform parentUI;
    //public List<Item> listAllIngeridients;
    //public List<ItemUI> listAllIngredietsUI;
    void Start()
    {
        //if(listAllIngeridients.Count==0 )
        //    Debug.LogError("List of All ingedients must be filled");
        //if (listAllIngredietsUI.Count==0)
        //    Debug.LogError("List of All ingedientsUI must be filled");
        //if (listAllIngredietsUI.Count != listAllIngeridients.Count)
        //    Debug.LogError("Both list must have same count");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public Order GenerateOrder(int numIng)
    {
        List<Item> listIng = new List<Item>();
        List<ItemUI> listIngUI = new List<ItemUI>();
        
        if (numIng > 0)
        {
            for (int i = 0; i < numIng-1; i++)
            {
                if (Random.Range(0, 1)==0.0)
                {
                    Ingredient2 ing2 = new Ingredient2();
                    ing2.itemType = ItemType.Ing;
                }
            }    
        }

        Order order = new Order(listIng, 8, GerneratorOrderUI(listIngUI));
        return order;
    }
    private OrderUI GerneratorOrderUI(List<ItemUI> ItemUIList)
    {
        GameObject orderUI = Instantiate(OrderUIPrefb, parentUI);
        OrderUI orderUIS = GetComponent<OrderUI>();
        orderUIS.ItemUIlist.AddRange(ItemUIList);
        orderUIS.generateItems();
        return orderUIS;
    }
}
