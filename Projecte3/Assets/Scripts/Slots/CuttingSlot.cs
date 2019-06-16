using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CuttingSlot : Slot
{
    public GameObject particlesEnd;
    private float fillAmount = 0;
    public float timerToAction;
    private float progresSpeed;
    public GameObject barCanvas;
    public Image progresBar;

    private void Start()
    {
        progresSpeed = 1 / timerToAction;
    }
    public void Update()
    {
        RotateTOCam();
    }
    public void RotateTOCam()
    {
        Vector3 dir = Camera.main.transform.position - progresBar.gameObject.transform.position;
        dir.x = 0;
        progresBar.gameObject.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
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
                    item.gameObject.transform.localEulerAngles = new Vector3(0, 180, 0);
                    item.stateIngredient = StateIngredient.cutted;
                    item.itemObject.SetActive(false);
                    item.itemMolido.SetActive(true);
                    particlesEnd.transform.localScale = new Vector3(2, 2, 2);
                    Instantiate(particlesEnd, transform.position, Quaternion.identity);
                }
            }              
        }
    }
}
