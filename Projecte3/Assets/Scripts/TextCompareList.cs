using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.ObjPooler;
public class TextCompareList : MonoBehaviour
{
    public List<Item> mm=new List<Item>() , mn=new List<Item>() ;

    // Use this for initialization
    void Start()
    {
        mm.Add(Ingredient2Pool.Instance.GetObjFromPool());
        mn.Add(Ingredient2Pool.Instance.GetObjFromPool());
        if (Utils.CompareLists2<Item>(mm, mn))
            Debug.Log("has same");
        else
            Debug.Log("not same");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
