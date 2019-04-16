using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrderGenerator : MonoBehaviour
{

    // Use this for initialization
    public GameObject OrderUIPrefb,Ing1UIPrefab,Ing2UIPrefab;
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
            for (int i = 0; i < numIng; i++)
            {
                //Debug.Log("num" + i);
                GameObject m;
                float rad = Random.Range(0.0f, 1.0f);
              //  Debug.Log(rad);
                if (rad>0.5f)
                {
                     m = Instantiate(Ing1UIPrefab);
                }
                else
                {
                     m = Instantiate(Ing2UIPrefab);
                }
                ItemUI mn =m.GetComponent<ItemUI>();
                listIngUI.Add(mn);
            }    
        }
        GameObject orderUI = Instantiate(OrderUIPrefb, parentUI);
        orderUI.transform.SetParent(parentUI);
        OrderUI orderUIS = orderUI.GetComponent<OrderUI>();
       
       
       orderUIS.ItemUIlist.AddRange(listIngUI);
       orderUIS.generateItems();

        Order order = new Order(listIng, 8, orderUIS);
        return order;
        return null;
    }
   
}
