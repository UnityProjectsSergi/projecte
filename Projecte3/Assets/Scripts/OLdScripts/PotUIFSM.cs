﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotUIFSM : MonoBehaviour
{
    public PotUIState potUIState;
    public List<ItemUIPot> listUIItems= new List<ItemUIPot>();
    public GameObject ListIng;
    public GameObject ItemPotUIPrefab;
    private ItemPotFSM ItemPot;
    public int currentSoltUi=0;
    public bool hasStoveUnder;
    public float duration;
    private int oldSlot;

    // Start is called before the first frame update
    public void Start()
    {

    }
    public void StartUiPot()
    {
        ItemPot = transform.parent.GetComponent<ItemPotFSM>();

        for (int i = 0; i < ItemPot.NumIngedientsOfPot; i++)
        {
            
            GameObject ingPot = Instantiate(ItemPotUIPrefab);
            listUIItems.Add(ingPot.GetComponent<ItemUIPot>());
        
            
            ingPot.GetComponent<ItemUIPot>().showWhenIsEmpty = ItemPot.ShowSlotsIngEmpty;
            ingPot.GetComponent<ItemUIPot>().setDefault();
            ingPot.transform.SetParent(ListIng.transform);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        RotateTOCam();
    }
   
    public void SetItemOnUISlot(int num,Item item)
    {
        listUIItems[num].SetSpriteFromImgredient(item.GetComponent<Renderer>().material);       
    }
    public void ResetUI()
    {
        
        foreach (var item in listUIItems)
        {
            item.setDefault();
        }
   
        
    }
    public void RotateTOCam()
    {
        Vector3 dir = Camera.main.transform.position - transform.position;
        dir.x = 0;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }
}