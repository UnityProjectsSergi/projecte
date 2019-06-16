using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.ObjPooler;

public class OrderGeneratorEric : MonoBehaviour
{

    // Use this for initialization
    public GameObject OrderUIPrefb,Ing1UIPrefab,Ing2UIPrefab,Ing3UIPrafab;
    public Sprite OrderUIEricIng2Seta, OrderUIEricIng3Seta, OrderUIEricIng2Dit, OrderUIEricIng3Dit,OrderUIEricIng2Min,OrderUIEricIng3Min;
    public Transform parentUI;
    
   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// Order UI and Order data Generator 
    /// </summary>
    /// <param name="numIng"></param>
    /// <returns></returns>
    float rad;
    public OrderEric GenerateOrderEric(float counter, int numIng, float duration, OrderEric.OrderRes orderServed)
    {
        // listes Elements a generar x crear ordre
        List<Item> listIng = new List<Item>();
        List<ItemUI> listIngUI = new List<ItemUI>();

        if (numIng > 0)
        {
            if (counter % 9 == 0)
            { 
                for (int i = 0; i < numIng; i++)
                {
                    listIng.Add(Ing1Pool.Instance.GetObjFromPool());

                }
            }
            else if (counter % 3 == 0)
            {
                for (int i = 0; i < numIng; i++)
                {
                    listIng.Add(Ingredient2Pool.Instance.GetObjFromPool());
                }
            }
            else if(counter%1==0)
            {
                for (int i = 0; i < numIng; i++)
                {
                    listIng.Add(Ingredient3Pool.Instance.GetObjFromPool());
                }
            }

        }
       

        // Creo Obj order passat li la list ingredients
        OrderEric order = new OrderEric(listIng,duration,orderServed);
        // Creao obj de tipus OrdreUI 
        GameObject orderUI = Instantiate(OrderUIPrefb, parentUI);
        // li poso pare de la llista de elements a UI
        orderUI.transform.SetParent(parentUI);
        // Trec el script OrdrerUI del obj
        OrderUIEric orderUIS = orderUI.GetComponent<OrderUIEric>();
        // afegeixo els la llista d'ingredients UI generada al ordre 
        if (numIng == 2 && counter % 9 == 0)
            orderUIS.SetSpitre(OrderUIEricIng2Min);
        else if(numIng==2 && counter%3==0)
            orderUIS.SetSpitre(OrderUIEricIng2Seta);
        else if(numIng==2 && counter%1==0)
            orderUIS.SetSpitre(OrderUIEricIng2Dit);
        else if (numIng == 3 && counter % 9 == 0)
            orderUIS.SetSpitre(OrderUIEricIng3Min);
        else if (numIng == 3 && counter % 3 == 0)
            orderUIS.SetSpitre(OrderUIEricIng3Seta);
        else if (numIng == 3 && counter % 1 == 0)
            orderUIS.SetSpitre(OrderUIEricIng3Dit);
        // Assigno obj OrderUi a l'order
        order.SetOrderUi(orderUIS);
        return order;
    }
}
