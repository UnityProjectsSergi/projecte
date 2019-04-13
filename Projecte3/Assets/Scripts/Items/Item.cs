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
}
class ItemEqualityComparer : IEqualityComparer<Item>
{
    public bool Equals(Item b1, Item b2)
    {
        if (b2 == null && b1 == null)
            return true;
        else if (b1 == null || b2 == null)
            return false;
         else
            return false;
    }

    public int GetHashCode(Item obj)
    {
        throw new System.NotImplementedException();
    }
}
