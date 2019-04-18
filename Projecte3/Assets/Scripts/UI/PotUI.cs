using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotUI : MonoBehaviour
{
    public PotUIBar potUIBar;
    public List<ItemUIPot> listUIItems= new List<ItemUIPot>();
    public GameObject ListIng;
    public GameObject ItemPotUIPrefab;
    private ItemPot ItemPot;
    private int currentSoltUi=0;
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
        
    }
    public void SetItemOnUISlot(Item item)
    {
        listUIItems[currentSoltUi].SetSpriteFromImgredient(item.GetComponent<Renderer>().material);
        currentSoltUi++;
    }
    public void ResetUI()
    {
        currentSoltUi = 0;
        foreach (var item in listUIItems)
        {
            item.setDefault();
        }
    }
}
