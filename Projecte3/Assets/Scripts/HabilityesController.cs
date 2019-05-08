using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.InputSystem;
public class HabilityesController : MonoBehaviour
{
    public HabilityType habilityType;
    public Hability hability;
    public CharacterControllerAct CharacterControllerAct;
    public GameObject HabilityRadi;
    public LayerMask layerMaskOverLapOlles;
    public bool 
        CookHability;
    // Start is called before the first frame update
    void Start()
    {
        hability = gameObject.AddComponent<Hability>();
        if (habilityType == HabilityType.LevitationItems)
            hability.set(3, 4, ActivateLevitation, DeactivateLevitation);
        else if (habilityType == HabilityType.SpeedTheFire)
            hability.set(13, 4, ActivateHabilitySpeedFire, DeactivateHabilitySpeedFire);
        else if (habilityType == HabilityType.Throw)
            hability.set(0, 0, null, null);
        else if (habilityType == HabilityType.Portal)
            hability.set(12, 15, ActiveHabilityPortal, DeactivateHabilityPortal);

    }

    // Update is called once per frame
    void Update()
    {
       if(hability.usingHability)
        DetectOlla();
    }
    public Collider[] ollesDetected;

    public void ActivateLevitation()
    {
        CharacterControllerAct.attachedObject.GetComponent<Item>().ActivateDeactivateItemPlayerControler(true, GetComponent<Character>().playercontroller, GetComponent<PlayerInput>());
        GetComponent<CharacterController>().enabled = false;
        GetComponent<Character>().enabled = false;
    }
    public void DeactivateLevitation()
    {
        CharacterControllerAct.attachedObject.GetComponent<Item>().ActivateDeactivateItemPlayerControler(false, 0, null);
        GetComponent<CharacterController>().enabled = true;
        GetComponent<Character>().enabled = true;
    }
    public void ActivateHabilitySpeedFire()
    {
        speedUpCookHability = true;
        HabilityRadi.gameObject.SetActive(true);
    }
    public void DeactivateHabilitySpeedFire()
    {
        speedUpCookHability = false;
        HabilityRadi.gameObject.SetActive(false);
    }
    public void ActiveHabilityPortal()
    {
        Debug.Log("Active Portals");
        CharacterControllerAct.PutPortal();
    }
    public void DeactivateHabilityPortal()
    {
        Debug.Log("End Portals");
        CharacterControllerAct.EndPortal();
    }
    public void DetectOlla()
    {
        Debug.Log("sss");
        
        ollesDetected = Physics.OverlapSphere(transform.position, 3,layerMaskOverLapOlles);
        if (ollesDetected.Length > 1)
            Debug.Log("sssssss");
        for (int i = 0; i < ollesDetected.Length; i++)
        {
            StoveSlotFSM stove = ollesDetected[i].GetComponent<StoveSlotFSM>();
            if(stove!=null && stove.item!=null && stove.item.itemType==ItemType.Pot)
            {
                ItemPotFSM itemPot = stove.item.GetComponent<ItemPotFSM>();
                if(itemPot!=null)
                {
                    if (itemPot.FSM_Pot.currentState == FSM.FSM_Pot.States.PAUSERUNNING)
                    {
                        if (itemPot.FSM_Pot.FSM_PauseStart.currentState == FSM.FSM_PauseStart.States.RUNNING)

                            itemPot.FSM_Pot.FSM_PauseStart.FSM_PotInteral.speedUpCook = true;
                        else
                            itemPot.FSM_Pot.FSM_PauseStart.FSM_PotInteral.speedUpCook = false;
                    }
                }
               

            }
            else
            {
                StoveSlot stoveNotF = ollesDetected[i].GetComponent<StoveSlot>();
                if(stoveNotF!=null && stoveNotF.item!=null && stoveNotF.item.itemType==ItemType.Pot)
                {
                    ItemPot pot = stoveNotF.item.GetComponent<ItemPot>();
                    if(pot!=null)
                    {
                        if (pot.currentStatePot == ItemPotStateIngredients.Cooking || pot.currentStatePot == ItemPotStateIngredients.Alert)
                        {
                            pot.potUi.potUIState.speedUp = true;
                        }
                        else
                            pot.potUi.potUIState.speedUp = false;
                    }
                }

            }

        }
    }
    public Collider[] hitColliders;

    public bool speedUpCookHability { get; private set; }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 3);
    }

}
