using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.ObjPooler;

public class OrderGenerator : MonoBehaviour
{

    // Use this for initialization
    public GameObject OrderUIPrefb,Ing1UIPrefab,Ing2UIPrefab;
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
    public Order GenerateOrder(int numIng)
    {
        // listes Elements a generar x crear ordre
        List<Item> listIng = new List<Item>();
        List<ItemUI> listIngUI = new List<ItemUI>();
        
        if (numIng > 0)
        {
            for (int i = 0; i < numIng; i++)
            {
                // UI elements
                GameObject m;
                // item elements
                Item n;
                /// Decideixo quin ingredinent si un o l'altre amb random
                float rad = Random.Range(0.0f, 1.0f);
                if (rad>0.5f)
                {
                    n = Ing1Pool.Instance.GetObjFromPool();
                     m = Instantiate(Ing1UIPrefab);
                   
                }
                else
                {
                    n = Ingredient2Pool.Instance.GetObjFromPool();
                     m = Instantiate(Ing2UIPrefab);
                    
                }
                //// Adegirixo a llistes a generar la UI i els obj Ingreienr o Item
                ItemUI mn =m.GetComponent<ItemUI>();
                listIngUI.Add(mn);
                listIng.Add(n);
            }    
        }
        // Creo Obj order passat li la list ingredients
        Order order = new Order(listIng, 8);
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
