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
    public bool speedUpCookHability;
    // Start is called before the first frame update
    void Start()
    {
        hability = gameObject.AddComponent<Hability>();
        if (habilityType == HabilityType.LevitationItems)
            hability.set(3, 4, ActivateLevitation, DeactivateLevitation);
        else if (habilityType == HabilityType.SpeedTheFire)
            hability.set(13, 4, ActivateHabilitySpeedFire, DeactivateHabilitySpeedFire);
    }

    // Update is called once per frame
    void Update()
    {
       // if(habilityType == HabilityType.SpeedTheFire)
        DetectOlla();
    }
    public Collider[] ollesDetected;
    public void ActivateLevitation()
    {
       CharacterControllerAct. attachedObject.GetComponent<Item>().ActivateDeactivateItemPlayerControler(true, GetComponent<Character>().playercontroller, GetComponent<PlayerInput>());
        GetComponent<CharacterController>().enabled = false;

        GetComponent<Character>().enabled = false;
    }
    public void DeactivateLevitation()
    {
        CharacterControllerAct. attachedObject.GetComponent<Item>().ActivateDeactivateItemPlayerControler(false, 0, null);
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
            
        }
        //} (Collider item in ollesDetected)
        //{
        //    Debug.Log("aaa");

        //    if (item.GetComponent<Item>().itemType == ItemType.Pot)
        //    {
        //        Debug.Log("Olla edetecd");
        //        ItemPotFSM potItem = item.GetComponent<ItemPotFSM>();

        //        if (potItem.FSM_Pot.currentState == FSM.FSM_Pot.States.PAUSERUNNING)
        //        {
        //            if (potItem.FSM_Pot.FSM_PauseStart.currentState == FSM.FSM_PauseStart.States.RUNNING )
        //            {
        //                if (speedUpCookHability)
        //                    potItem.FSM_Pot.FSM_PauseStart.FSM_PotInteral.speedUpCook = true;
        //                else
        //                    potItem.FSM_Pot.FSM_PauseStart.FSM_PotInteral.speedUpCook = false;

        //            }

        //            else
        //            {
        //                potItem.FSM_Pot.FSM_PauseStart.FSM_PotInteral.speedUpCook = false;
        //            }
        //        }
        //    }
        //}
        //hitColliders = Physics.OverlapSphere(transform.position, 5,layerMaskOverLapOlles);
        //int i = 0;
        //while (i < hitColliders.Length)
        //{
        //    Debug.Log("ssssssssssss"); ;
        // //   hitColliders[i].SendMessage("AddDamage");
        //    i++;
        //}
    }
    public Collider[] hitColliders;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 3);
    }
}
