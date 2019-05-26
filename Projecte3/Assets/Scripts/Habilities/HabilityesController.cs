using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.InputSystem;
public class HabilityesController : MonoBehaviour
{
    public HabilityType habilityType;
    public Hability hability;
    public CharacterControllerAct CharacterControllerAct;
    public GameObject HabilityRadi;
    public LayerMask layerMaskOverLapOlles;
    public bool CookHability;
  
    public bool cCookHability;
    public Image CoolDown;
    public bool HabilityInCoolDown;
   
    MeshRenderer meshRenderer;
    public GameObject[] typePlayer;
    [Header("Habilitys params")]
    public float coolDownTimerHability;
    public float durationHabilityTime;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        hability = gameObject.AddComponent<Hability>();
        if (habilityType == HabilityType.LevitationItems)
        {
            ChangeMesh(0);
            hability.set(durationHabilityTime, coolDownTimerHability, ActivateLevitation, DeactivateLevitation,CoolDown);
        }
        else if (habilityType == HabilityType.SpeedTheFire)
        {
            ChangeMesh(1);
            hability.set(durationHabilityTime, coolDownTimerHability, ActivateHabilitySpeedFire, DeactivateHabilitySpeedFire,CoolDown);
        }
        else if (habilityType == HabilityType.Throw)
        {
            ChangeMesh(2);
            hability.set(0, 0, null, null,CoolDown);
        }
        else if (habilityType == HabilityType.Portal)
        {
            ChangeMesh(3);
            hability.set(durationHabilityTime, coolDownTimerHability, ActiveHabilityPortal, DeactivateHabilityPortal,CoolDown);
        }

    }

    // Update is called once per frame
    void Update()
    {
       if(speedUpCookHability && hability.usingHability )
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
        HabilityInCoolDown = true;
        
    }
   
    public void ActivateHabilitySpeedFire()
    {

      
            HabilityRadi.gameObject.SetActive(true);
            speedUpCookHability = true;
        
    }
    public void DeactivateHabilitySpeedFire()
    {
        speedUpCookHability = false;
        HabilityRadi.gameObject.SetActive(false);
        HabilityInCoolDown = true;
      
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
        HabilityInCoolDown = true;
    }
    public void DetectOlla()
    {
        Debug.Log("sss");
        
        ollesDetected = Physics.OverlapSphere(transform.position,HabilityRadi.transform.localScale.x/2,layerMaskOverLapOlles);
        if (ollesDetected.Length > 1)
            Debug.Log("sssssss");
        for (int i = 0; i < ollesDetected.Length; i++)
        {
            //StoveSlotFSM stove = ollesDetected[i].GetComponent<StoveSlotFSM>();
            //if(stove!=null && stove.item!=null && stove.item.itemType==ItemType.Pot)
            //{
            //    ItemPotFSM itemPot = stove.item.GetComponent<ItemPotFSM>();
            //    if(itemPot!=null)
            //    {
            //        if (itemPot.FSM_Pot.currentState == FSM.FSM_Pot.States.PAUSERUNNING)
            //        {
            //            if (itemPot.FSM_Pot.FSM_PauseStart.currentState == FSM.FSM_PauseStart.States.RUNNING)

            //                itemPot.FSM_Pot.FSM_PauseStart.FSM_PotInteral.speedUpCook = true;
            //            else
            //                itemPot.FSM_Pot.FSM_PauseStart.FSM_PotInteral.speedUpCook = false;
            //        }
            //    }
               

            //}
            //else
            //{
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
                    {
                        pot.potUi.potUIState.speedUp = false;
                        pot.potUi.potUIState.hasSpeedUp = false;
                    }
                    }
                }

            //}
            //q si modifiqueu prefabs heu dfer ovverride apply allxq sino 
        }
    }
    public Collider[] hitColliders;
    public void ChangeMesh(int value)
    {
        meshRenderer.enabled = false;
        GameObject go = Instantiate(typePlayer[value], transform.position, Quaternion.identity);
        go.transform.position = transform.position;
        go.transform.parent = transform;
    }

    public bool speedUpCookHability { get; private set; }

    private void OnDrawGizmos()
    {
    //    Gizmos.DrawWireSphere(transform.position, HabilityRadi.transform.localScale.x/2);
    }

}
