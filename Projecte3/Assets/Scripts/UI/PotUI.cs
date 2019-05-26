using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotUI : MonoBehaviour
{
    public PotUIState potUIState;
    public List<ItemUIPot> listUIItems= new List<ItemUIPot>();
    public GameObject ListIng;
    public GameObject ItemPotUIPrefab;
    private ItemPot ItemPot;
    public int currentSoltUi=0;
    public bool hasStoveUnder;
    public float duration;
    private int oldSlot;
    private bool enter;
    private bool enter2;

    public void StartUiPot()
    {
        ItemPot = transform.parent.GetComponent<ItemPot>();
       
        for (int i = 0; i < ItemPot.NumIngedientsOfPot; i++)
        {            
            GameObject ingPot = Instantiate(ItemPotUIPrefab);
            listUIItems.Add(ingPot.GetComponent<ItemUIPot>());
          
            if (ItemPot.ShowSlotsIngEmpty)
                ingPot.GetComponent<ItemUIPot>().showWhenIsEmpty = true;            
            ingPot.GetComponent<ItemUIPot>().setDefault();            
            ingPot.transform.SetParent(ListIng.transform);
        }
      
    }
    public void SetfireStates()
    {
        potUIState.SetFire();
    }
    void Update()
    {
        if (currentSoltUi != oldSlot)
        {
            potUIState.totalduration += duration;        
        }
        if (ItemPot.listItem.Count == listUIItems.Count)
        {
            if (potUIState.isStarted)
            {
                if (hasStoveUnder)
                {
                    if (enter)
                    {
                        potUIState.ResumeCooking();
                        enter = false;
                    }
                    enter2 = true;
                }
                else
                {

                    if (enter2)
                    {
                        potUIState.PauseCooking();
                        enter2 = false;
                    }
                    enter = true;
                }
            }
            else
            {
                potUIState.StartCooking();
            }
        }
        oldSlot = currentSoltUi;
        RotateTOCam();
    }

    public void SetItemPotState(ItemPotStateIngredients state)
    {
            ItemPot.currentStatePot = state;
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
        potUIState.Reset();
        duration = 0;
    }

    public void RotateTOCam()
    {
        Vector3 dir = Camera.main.transform.position - transform.position;
        dir.x = 0;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }
}
