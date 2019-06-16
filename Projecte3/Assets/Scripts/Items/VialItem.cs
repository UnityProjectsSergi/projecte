using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VialItem : Item
{
  
    public List<Item> listItem;
    public GameObject vial;
    private Material iniMaterial;
    public Material ing1Material;
    public Material ing2Material;
    public Material ing3Material;

    //Get Vial Item from VialItemPool
    public void Start()
    {
        rigidbodyController = GetComponent<RigidbodyController>();
        itemType = ItemType.Vial;
        iniMaterial = vial.GetComponent<Renderer>().material;
    }

    public void ResetVial()
    {
        listItem.Clear();
    }

    public void ChangeMaterial(ItemUiType type)
    {
        switch(type)
        {
            case ItemUiType.Ing1:
                vial.GetComponent<Renderer>().material = ing1Material;
                break;
            case ItemUiType.Ing2:
                vial.GetComponent<Renderer>().material = ing2Material;
                break;
            case ItemUiType.Ing3:
                vial.GetComponent<Renderer>().material = ing3Material;
                break;
        }
        
    }

    public void ResetMaterial()
    {
        vial.GetComponent<Renderer>().material = iniMaterial;
    }
}

