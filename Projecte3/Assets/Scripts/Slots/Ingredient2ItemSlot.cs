using UnityEngine;
using System.Collections;
using Assets.Scripts.ObjPooler;
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
        
     
    }
    // Update is called once per frame
    void Update()
    {

    }
}
