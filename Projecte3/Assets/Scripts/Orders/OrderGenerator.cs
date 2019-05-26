using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.ObjPooler;

public class OrderGenerator : MonoBehaviour
{

    // Use this for initialization
    public GameObject OrderUIPrefb,Ing1UIPrefab,Ing2UIPrefab,Ing3UIPrafab;
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
    public Order GenerateOrder(float counter, int numIng, float duration, Order.OrderRes orderServed)
    {
        // listes Elements a generar x crear ordre
        List<Item> listIng = new List<Item>();
        List<ItemUI> listIngUI = new List<ItemUI>();

        if (numIng > 0)
        {
            for (int i = 0; i < numIng; i++)
            {
                rad = Random.Range(0.0f, 1.0f);
                Debug.Log(rad);
                // UI elements
                GameObject m = null;
                // item elements
                Item n = null;

                /// Decideixo quin ingredinent si un o l'altre amb random
                // float rad = Random.Range(0.0f, 1.0f);
                if (counter % 9 == 0)
                //  if (rad>0.33f)
                {
                    n = Ing1Pool.Instance.GetObjFromPool();
                    m = Instantiate(Ing1UIPrefab);
                }
                else if (counter % 3 == 0)
                //else if(rad>0.3 && rad <0.6)
                {
                    n = Ingredient2Pool.Instance.GetObjFromPool();
                    m = Instantiate(Ing2UIPrefab);
                }
                else if (counter % 1 == 0)
                {
                    n = Ingredient3Pool.Instance.GetObjFromPool();
                    m = Instantiate(Ing3UIPrafab);
                }

                if (n != null)
                {
                    n.gameObject.SetActive(false);
                    //// Adegirixo a llistes a generar la UI i els obj Ingreienr o Item
                    ItemUI mn = m.GetComponent<ItemUI>();
                    listIngUI.Add(mn);
                    listIng.Add(n);
                }
            }
        }

        // Creo Obj order passat li la list ingredients
        Order order = new Order(listIng,duration,orderServed);
        // Creao obj de tipus OrdreUI 
        GameObject orderUI = Instantiate(OrderUIPrefb, parentUI);
        // li poso pare de la llista de elements a UI
        orderUI.transform.SetParent(parentUI);
        // Trec el script OrdrerUI del obj
        OrderUI orderUIS = orderUI.GetComponent<OrderUI>();
       // afegeixo els la llista d'ingredients UI generada al ordre 
        orderUIS.ItemUIlist.AddRange(listIngUI);
        // genero i ordeno la llista ingredienta a UI
        orderUIS.generateItemsUI();
        // Assigno obj OrderUi a l'order
        order.SetOrderUi(orderUIS);
        return order;
    }
}
