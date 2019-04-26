using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VialItem : Item
{
  
    public List<Item> listItem;
    public GameObject vial;
    public Material fullMaterial;
    
    //Get Vial Item from VialItemPool
    public void Start()
    {
        rigidbodyController = GetComponent<RigidbodyController>();
        itemType = ItemType.Vial;
        
    }

    public void ResetVial()
    {
        listItem.Clear();
    }

    public void ChangeMaterial()
    {
        vial.GetComponent<Renderer>().material = fullMaterial;
    }
}

