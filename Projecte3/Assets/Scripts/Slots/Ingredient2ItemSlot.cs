using UnityEngine;
using System.Collections;
using Assets.Scripts.ObjPooler;
using UnityEngine.UI;

public class Ingredient2ItemSlot : ItemSlot
{
    public Transform pivot;
    // Use this for initialization
    public override void Start()
    {
        item = Ingredient2Pool.Instance.GetObjFromPool(pivot);
     
        base.Start();
    }

    public override void Catch(CharacterControllerAct player)
    {
        base.Catch(player);
        item = Ingredient2Pool.Instance.GetObjFromPool(pivot);
        item.GetComponent<Ingredient2>().canvas.GetComponentInChildren<Image>().sprite = item.GetComponent<Item>().spriteIng;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
