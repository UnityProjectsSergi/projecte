using UnityEngine;
using System.Collections;
using Assets.Scripts.ObjPooler;
using UnityEngine.UI;

public class Ingredient3ItemSlot : ItemSlot
{

    // Use this for initialization
    public override void Start()
    {
        item = Ingredient3Pool.Instance.GetObjFromPool(transform);
     
        base.Start();
    }

    public override void Catch(CharacterControllerAct player)
    {
        base.Catch(player);
        item = Ingredient3Pool.Instance.GetObjFromPool(transform);
        item.GetComponent<Ingredient3>().canvas.GetComponentInChildren<Image>().sprite = item.GetComponent<Item>().spriteIng;
     
    }
    // Update is called once per frame
    void Update()
    {

    }
}
