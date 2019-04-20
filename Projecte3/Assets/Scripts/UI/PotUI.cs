﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotUI : MonoBehaviour
{
    public PotUIBar potUIBar;
    public List<ItemUIPot> listUIItems= new List<ItemUIPot>();
    public GameObject ListIng;
    public GameObject ItemPotUIPrefab;
    private ItemPot ItemPot;
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
        ItemPot = transform.parent.GetComponent<ItemPot>();
        Debug.Log(ItemPot.NumIngedientsOfPot);
        for (int i = 0; i < ItemPot.NumIngedientsOfPot; i++)
        {
            
            GameObject ingPot = Instantiate(ItemPotUIPrefab);
            listUIItems.Add(ingPot.GetComponent<ItemUIPot>());
            Debug.Log("Add UI item");
            if (ItemPot.ShowSlotsIngEmpty)
                ingPot.GetComponent<ItemUIPot>().showWhenIsEmpty = true;
            ingPot.GetComponent<ItemUIPot>().setDefault();
            ingPot.transform.SetParent(ListIng.transform);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (currentSoltUi != oldSlot)
        {
            potUIBar.totalduration += duration;
            // totalduration = duration;
            Debug.Log("percenkCook before " + potUIBar.percentCook + "totalduration " + potUIBar.totalduration);
         //   potUIBar.percentCook = (float)Mathf.Round((100f * potUIBar.percentCook) / potUIBar.totalduration);
            Debug.Log("percenkCook after " + potUIBar.percentCook + "totalduration " + potUIBar.totalduration);
        }  
        
        // on assingre sfillampit 
        if (hasStoveUnder)
        {
            potUIBar.StartCooking();
        }
        else
        {
            potUIBar.StopCooking();
        }
        oldSlot = currentSoltUi;
        RotateTOCam();
    }
    public void SetItemOnUISlot(Item item)
    {
        if (currentSoltUi < listUIItems.Count)
        {
            listUIItems[currentSoltUi].SetSpriteFromImgredient(item.GetComponent<Renderer>().material);
            currentSoltUi++;
            duration = item.duration;
        }
    }
    public void ResetUI()
    {
        currentSoltUi = 0;
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
