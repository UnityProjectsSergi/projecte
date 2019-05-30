using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.InputSystem;
public class HabilityesController : MonoBehaviour
{
    public HabilityType habilityType;
    public Hability hability;
    public CharacterControllerAct characterControllerAct;
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
        characterControllerAct = GetComponent<CharacterControllerAct>();
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
        characterControllerAct.attachedObject.GetComponent<Item>().ActivateDeactivateItemPlayerControler(true, GetComponent<Character>().playercontroller, GetComponent<PlayerInput>());
        GetComponent<CharacterController>().enabled = false;
        GetComponent<Character>().enabled = false;      
    }
    public void DeactivateLevitation()
    {
        characterControllerAct.attachedObject.GetComponent<Item>().ActivateDeactivateItemPlayerControler(false, 0, null);
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
        characterControllerAct.PutPortal();       
    }
    public void DeactivateHabilityPortal()
    {
        Debug.Log("End Portals");
        characterControllerAct.EndPortal();
        HabilityInCoolDown = true;
    }
    public void DetectOlla()
    {      
        ollesDetected = Physics.OverlapSphere(transform.position,HabilityRadi.transform.localScale.x/2,layerMaskOverLapOlles);
        if (ollesDetected.Length > 1)

        for (int i = 0; i < ollesDetected.Length; i++)
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
                    {
                        pot.potUi.potUIState.speedUp = false;
                        pot.potUi.potUIState.hasSpeedUp = false;
                    }
                }
            }
        }
    }
    public Collider[] hitColliders;
    public void ChangeMesh(int value)
    {
        meshRenderer.enabled = false;
        GameObject go = Instantiate(typePlayer[value], transform.position, Quaternion.identity);
        go.transform.position = transform.position;
        go.transform.parent = transform;
        characterControllerAct.animator = go.GetComponent<Animator>();
    }

    public bool speedUpCookHability { get; private set; }

    private void OnDrawGizmos()
    {
    //    Gizmos.DrawWireSphere(transform.position, HabilityRadi.transform.localScale.x/2);
    }

}
