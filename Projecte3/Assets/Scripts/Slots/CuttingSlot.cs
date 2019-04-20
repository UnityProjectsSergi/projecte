using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CuttingSlot : Slot
{
    private float fillAmount = 0;
    public float timerToAction;
    private float progresSpeed;
    public GameObject barCanvas;
    public Image progresBar;

    private void Start()
    {
        progresSpeed = 1 / timerToAction;
    }

    public override void LeaveObjOn(CharacterControllerAct player)
    {
        Item i = player.attachedObject.GetComponent<Item>();

        if (i.itemType == ItemType.Ing)
        {
            base.LeaveObjOn(player);
            if (i.stateIngredient == StateIngredient.raw)
            {
                barCanvas.SetActive(true);
                progresBar.fillAmount = 0;
            }
        }
    }

    public override void Catch(CharacterControllerAct player)
    {
        // The player just can catch items cutted or raw
        if (item != null)
        {
            if (item.stateIngredient == StateIngredient.cutted || item.stateIngredient == StateIngredient.raw)
                base.Catch(player);
        }
    }

    public override void Action(CharacterControllerAct player)
    {
        if (item != null)
        {
            if (item.stateIngredient == StateIngredient.raw 
             || item.stateIngredient == StateIngredient.cutting)
            {
                item.stateIngredient = StateIngredient.cutting;
                fillAmount += progresSpeed * Time.deltaTime;
                progresBar.fillAmount = fillAmount;

                if (fillAmount >= 1)
                {
                    fillAmount = 0;
                    barCanvas.SetActive(false);
                    item.transform.localScale = new Vector3(0.7f, 0.4f, 0.7f);
                    item.stateIngredient = StateIngredient.cutted;
                }
            }              
        }
    }
}
