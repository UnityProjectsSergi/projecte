using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public abstract class Slot :MonoBehaviour
{
    protected Ingredient item;
    public Transform positionObjOn;

    public bool isActive;
    public bool hasObjectOn; //Object in slot

    public virtual void Catch(CharacterControllerAct player)
    {
        Debug.Log("sssss");
        if (hasObjectOn)
        {
            Debug.Log("ddd");
            item.transform.parent = player.attachTransform;
            item.transform.position = player.attachTransform.position;
            player.attachedObject = item.gameObject;
            hasObjectOn = false;
            item = null;
        }
    }


   
    public virtual void LeaveObjOn(CharacterControllerAct player)
    {
        if (!hasObjectOn)
        {
            hasObjectOn = true;
            player.attachedObject.transform.parent = positionObjOn.transform;
            item = player.attachedObject.GetComponent<Ingredient>();
            item.transform.position = positionObjOn.transform.position;
            player.attachedObject = null;
        }    
    }
}

