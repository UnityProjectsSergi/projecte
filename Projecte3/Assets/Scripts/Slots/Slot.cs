using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public abstract class Slot :MonoBehaviour
{
    public Item item;
    public Transform positionObjOn;

    public Material iniMaterial;
    public Material selectedMaterial;

    public bool isActive;
    public bool hasObjectOn; //Object in slot

    public virtual void Catch(CharacterControllerAct player)
    {  
        if (hasObjectOn)
        {    
            item.transform.parent = player.attachTransform;
            item.transform.position = player.attachTransform.position;
            player.attachedObject = item.gameObject;
            item.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            hasObjectOn = false;
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
        if(selectedMaterial != null)
            this.gameObject.GetComponent<Renderer>().material = selectedMaterial;
    }

    public void ChangeMaterialIni()
    {
        if (iniMaterial != null)
            this.gameObject.GetComponent<Renderer>().material = iniMaterial;
    }
}

