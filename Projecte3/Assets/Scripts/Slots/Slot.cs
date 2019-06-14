using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Slot :MonoBehaviour
{
    public Renderer renderer;

    public Item item;
    public Transform positionObjOn;

    public bool isActive;
    public bool hasObjectOn; //Object in slot

    public virtual void Catch(CharacterControllerAct player)
    {  
        if (hasObjectOn)
        {    
            item.transform.parent = player.attachTransform;
            item.transform.position = player.attachTransform.position;
            player.attachedObject = item.gameObject;
            player.HasItem = true;
            item.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            hasObjectOn = false;
            item.collider.enabled = false;
            item = null;
        }
    }
  
    public virtual void LeaveObjOn(CharacterControllerAct player)
    {
        if (!hasObjectOn)
        { 
            hasObjectOn = true;
            player.attachedObject.GetComponent<Rigidbody>().isKinematic = true;
            player.attachedObject.transform.parent = positionObjOn.transform;
            item = player.attachedObject.GetComponent<Item>();
            item.transform.position = positionObjOn.transform.position;
            player.attachedObject = null;
        }    
    }

    public virtual void Action(CharacterControllerAct player)
    {

    }

    public void ChangeMaterialSelected()
    {
        renderer.material.EnableKeyword("_EMISSION");
    }

    public void ChangeMaterialIni()
    {
        renderer.material.DisableKeyword("_EMISSION");
    }
}

