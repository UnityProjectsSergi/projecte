using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.InputSystem;
using Assets.Scripts.ObjPooler;
using System;

public class CharacterControllerAct : MonoBehaviour
{
    public HabilityType habilityType;
    public Transform attachTransform;
    PlayerInput playerInput;
    public LayerMask tablesLayerMask;
    public LayerMask itemsLayerMask;
    public Transform raycastTransform;
    //public Animator animator;
    public Hability hability;
    private Slot slot;
    private Item item;

    public GameObject attachedObject;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        hability = gameObject.AddComponent<Hability>();
        if(habilityType==HabilityType.LevitationItems)
        hability.set(3, 4, ActivateLevitation,DeactivateLevitation);
       // else if(habilityType==HabilityType.SpeedTheFire)
            //hability.set(3,4,)
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        HabilityAction();
        SlotAction();
     
    }
    public bool canUseHability;
    private void HabilityAction()
    {
        if(attachedObject!=null)
        {
            
                hability.SetHabilityAvalableFalse();
                if (playerInput.squareBtn.Down)
                {
                    hability.UseHability();
                    // to hability trigger
                }
            if (hability.usingHability)
            {
                if (playerInput.XBtn.Down)
                {
                    hability.StopHability();
                    
                }
            }
        }
    }

    void SlotAction()
    {
        if (attachedObject == null)
        {
            if (playerInput.XBtn.Down)
                Catch();
            if (playerInput.triangleBtn.Hold)
                Action();

                //animator.SetTrigger("Idle");
        }
        else
        {
            if (playerInput.XBtn.Down)
                LeaveObjOn();
        }
    }
    
    private void Catch()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastTransform.position, raycastTransform.forward, out hit, 2, tablesLayerMask))
        {
            slot = hit.collider.GetComponent<Slot>();
            slot.Catch(this);
        }
        if (Physics.Raycast(raycastTransform.position, transform.forward, out hit, 1, itemsLayerMask))
        {
            item = hit.collider.GetComponent<Item>();
            item.transform.eulerAngles = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.Catch(this);
        }
    }

    public void LeaveObjOn()
    {
        if (attachedObject != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(raycastTransform.position, transform.forward, out hit, 1, tablesLayerMask))
            {
                slot = hit.collider.GetComponent<Slot>();
                slot.LeaveObjOn(this);
            }
            else
            {
                attachedObject.GetComponent<RigidbodyController>().ActiveRigidbody(true);
                attachedObject.transform.parent = null;
                attachedObject = null;
            }
        }
    }
    public void LeaveObj()
    {
        if (attachedObject != null)
        {
            attachedObject.GetComponent<RigidbodyController>().ActiveRigidbody(true);
            attachedObject.transform.parent = null;
            attachedObject = null;
        }
    }
    private void Action()
    {

        RaycastHit hit;
        if (Physics.Raycast(raycastTransform.position, raycastTransform.forward, out hit, 2, tablesLayerMask))
        {
            
                //animator.SetTrigger("Action");
            slot = hit.collider.GetComponent<Slot>();
            slot.Action(this);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(raycastTransform.position, transform.forward * 1f);
    }
    public void ActivateLevitation()
    {
        attachedObject.GetComponent<Item>().ActivateDeactivateItemPlayerControler(true, GetComponent<Character>().playercontroller, GetComponent<PlayerInput>());
        GetComponent<CharacterController>().enabled = false;
        
        GetComponent<Character>().enabled = false;
    }
    public void DeactivateLevitation()
    {
        attachedObject.GetComponent<Item>().ActivateDeactivateItemPlayerControler(false, 0, null);
        GetComponent<CharacterController>().enabled = true;
        GetComponent<Character>().enabled = true;
    }
    
}
