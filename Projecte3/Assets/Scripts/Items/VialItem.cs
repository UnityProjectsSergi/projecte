using System.Collections.Generic;
using UnityEngine;

public class VialItem : Item
{
    [SerializeField]
    public List<Item> listItem;
    public GameObject vial;
    private Material iniMaterial;
    public Material fullMaterial;

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

    public void ChangeMaterial()
    {
        vial.GetComponent<Renderer>().material = fullMaterial;
    }

    public void ResetMaterial()
    {
        vial.GetComponent<Renderer>().material = iniMaterial;
    }
}

