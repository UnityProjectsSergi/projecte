﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.ObjPooler;
using System;



// x fer unna maq esstats

    [System.Serializable]
public  class Item : MonoBehaviour
{
    [Header("Item Variables")]
    public ItemUiType ing;
    public ItemType itemType;
   
    public int points;
    public string nameO;
    public StateIngredient stateIngredient;
    public RigidbodyController rigidbodyController;
    public float duration;
    public float ingCookValue = 0;


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
            Debug.Log("Other is nnull");
            return false;
        }
        var objOther = other as Item;
        Debug.LogWarning(ing != objOther.ing);
        if(GetType()!=objOther.GetType())
       // if (ing!=objOther.ing)
            return false;
        Debug.Log("is same obj");
        return true;
    }
    // crec q funciona xo 
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
    public float percentCooked;
    public IEnumerator Cook()
    {
        float journey = 0f;
        while (journey <= duration)
        {
            journey += Time.deltaTime;
            percentCooked = Mathf.Clamp01(journey / duration);

            ingCookValue = Mathf.Lerp(0, 1.0f, percentCooked);
            if (ingCookValue > 0.99f)
                stateIngredient = StateIngredient.cooked;

            yield return null;

        }
    }
  
}

