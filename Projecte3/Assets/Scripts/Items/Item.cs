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
    public ItemType itemType;
    public bool isPot;
    public int points;
    public string namme;
    public StateIngredient stateIngredient;
    public RigidbodyController rigidbodyController;
    
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
            return false;
        }
        var objOther = other as Item;
        if (namme != objOther.namme)
            return false;
        return true;
    }
    public static bool operator ==(Item x, Item y)
    {
        return x.Equals(y);
    }
    public static bool operator !=(Item x,Item y)
    {
        return !(x == y);
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

