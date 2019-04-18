using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotUI : MonoBehaviour
{
    public PotUIBar potUIBar;
    public List<ItemUIPot> listuI;
    public GameObject ListIng;
    public GameObject ItemPotUIPrefab;
    private ItemPot ItemPot;
    public int currentSoltUi=0;
    // Start is called before the first frame update
    void Start()
    {
        listuI = new List<ItemUIPot>();
    }
    public void StartUiPot()
    {
        ItemPot = transform.parent.GetComponent<ItemPot>();
        for (int i = 0; i < ItemPot.NumIngedientsOfPot; i++)
        {
            GameObject ingPot = Instantiate(ItemPotUIPrefab);
            listuI.Add(ingPot.GetComponent<ItemUIPot>());
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
        listuI[currentSoltUi].SetSpriteFromImgredient(item.GetComponent<Renderer>().material);
        currentSoltUi++;
    }
    public void Reset()
    {
        currentSoltUi = 0;
    }
}
