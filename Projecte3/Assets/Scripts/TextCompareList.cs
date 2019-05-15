using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.ObjPooler;
using System.Linq;
public class TextCompareList : MonoBehaviour
{
    public List<Item> OrderList=new List<Item>() , OrderToChecl=new List<Item>() ;
    public List<Item> equalItems = new List<Item>(), In1OfOrderList = new List<Item>(), Ing2OfOrderList = new List<Item>(), equalItems2Ing1 = new List<Item>(), equalItems2Ing2 = new List<Item>();
    // Use this for initialization
    void Start()
    {
        // lista de ordes
        OrderList.Add(Ingredient2Pool.Instance.GetObjFromPool());
        OrderList.Add(Ing1Pool.Instance.GetObjFromPool());
        OrderList.Add(Ingredient2Pool.Instance.GetObjFromPool());
        OrderList.Add(Ing1Pool.Instance.GetObjFromPool());
        // ordre a checkejar
        OrderToChecl.Add(Ing1Pool.Instance.GetObjFromPool());
        OrderToChecl.Add(Ing1Pool.Instance.GetObjFromPool());
        OrderToChecl.Add(Ingredient2Pool.Instance.GetObjFromPool());
        OrderToChecl.Add(Ing1Pool.Instance.GetObjFromPool());
        OrderToChecl.Add(Ingredient2Pool.Instance.GetObjFromPool());
        // 2 llistte
        
        In1OfOrderList = OrderList.OfType<Ingredient1>().ToList<Item>();
        Ing2OfOrderList = OrderList.OfType<Ingredient2>().ToList<Item>();
        equalItems2Ing2 = OrderToChecl.OfType<Ingredient2>().ToList<Item>();
        equalItems2Ing1 = OrderToChecl.OfType<Ingredient1>().ToList<Item>();
        if (equalItems2Ing1.Count == In1OfOrderList.Count)
            Debug.Log("Ing1 has same number of ing at 2 lists");
        if(equalItems2Ing2.Count==Ing2OfOrderList.Count)
            Debug.Log("Ing2 has same number of ing at 2 list");
        if (equalItems2Ing1.Count == In1OfOrderList.Count && equalItems2Ing2.Count == Ing2OfOrderList.Count)
            Debug.Log("lists has same numbros of each ingredient");
        //cada llista te 2 tipus dobj vull saber si el nombre dobj dun tipus es igual a l'altra llista 

        if (Utils.CompareLists2<Item>(OrderList, OrderToChecl))
            Debug.Log("has same");
        else
            Debug.Log("not same");

        if (OrderToChecl.Intersect(OrderList).Any()) // check if there is equal items
        {

            equalItems = OrderToChecl.Intersect(OrderList).ToList(); // get list of equal items (2, 6, 9)
            if (equalItems.Count == OrderList.Count && equalItems.Count == OrderToChecl.Count)
                Debug.Log("has same items");
            else
                Debug.Log("not same");
            foreach (var item in equalItems)
            {
                Debug.Log(item);
            }
        }
        else
        {
            Debug.Log("not equals");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
