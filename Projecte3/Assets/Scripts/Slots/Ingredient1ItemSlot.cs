using UnityEngine;
using System.Collections;
using Assets.Scripts.ObjPooler;
public class Ingredient1ItemSlot : ItemSlot
{
    public Transform pivot;
    // Use this for initialization
    public override void Start()
    {
        item = Ing1Pool.Instance.GetObjFromPool(pivot);
        base.Start();
    }

    public override void Catch(CharacterControllerAct player)
    {
        base.Catch(player);
        item = Ing1Pool.Instance.GetObjFromPool(pivot);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
