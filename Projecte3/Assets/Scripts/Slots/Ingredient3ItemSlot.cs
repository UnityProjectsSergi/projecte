using UnityEngine;
using System.Collections;
using Assets.Scripts.ObjPooler;
public class Ingredient3ItemSlot : ItemSlot
{

    // Use this for initialization
    public override void Start()
    {
        item = Ingredient2Pool.Instance.GetObjFromPool(transform);
     
        base.Start();
    }

    public override void Catch(CharacterControllerAct player)
    {
        base.Catch(player);
        item = Ingredient2Pool.Instance.GetObjFromPool(transform);
        
     
    }
    // Update is called once per frame
    void Update()
    {

    }
}
