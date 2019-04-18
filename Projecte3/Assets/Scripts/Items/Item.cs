using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.ObjPooler;

public enum StateIngredient
{
    raw,cutting,cutted,initCook,cooked
}

// x fer unna maq esstats

public  class Item : MonoBehaviour
{
    [Header("Item Variables")]
    public ItemUiType ing;
    public ItemType itemType;
   
    public int points;
   
    public StateIngredient stateIngredient;
    public RigidbodyController rigidbodyController;
    public float duration;



    private bool inTable { get { return inTable; } set { } }

    private void OnEnable()
    {
       
        stateIngredient=StateIngredient.raw;
    }
    
    public virtual void Catch(CharacterControllerAct player)
    {
        rigidbodyController.ActiveRigidbody(false);
        transform.parent = player.attachTransform;
        transform.position = player.attachTransform.position;
        player.attachedObject = gameObject;    
    }
    public override bool Equals(object other)
    {
        if (!(other is Item))
        {
            Debug.Log("ss");
            return false;
        }
        var objOther = other as Item;
        if (GetType() !=objOther.GetType())
            return false;
        Debug.Log("ssm");
        return true;
    }
    //public static bool operator ==(Item x, Item y)
    //{
    //    return x.Equals(y);
    //}
    //public static bool operator !=(Item x,Item y)
    //{
    //    return !(x == y);
    //}
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    public Item Clone()
    {
        return(Item) this.MemberwiseClone();
    }
}

