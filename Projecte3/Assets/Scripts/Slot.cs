﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public abstract class Slot :MonoBehaviour
{
    protected GameObject item;
    public Transform positionObjOn;

    public bool isActive;
    public bool hasObjectOn; //Object in slot

    public virtual void Catch(CharacterControllerAct player)
    {
        if (hasObjectOn)
        {
            item.transform.parent = player.attachTransform;
            item.transform.position = player.attachTransform.position;
            player.attachedObject = item;
            hasObjectOn = false;
            item = null;
        }
    }

    public void CatchObjOn(Player player)
        {
            
        }
   
    public virtual void LeaveObjOn(CharacterControllerAct player)
    {
        if (!hasObjectOn)
        {
            hasObjectOn = true;
            player.attachedObject.transform.parent = positionObjOn.transform;
            item = player.attachedObject;
            item.transform.position = positionObjOn.transform.position;
            player.attachedObject = null;
        }
    }
}

