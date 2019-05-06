﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.InputSystem;
using Assets.Scripts.ObjPooler;
using System;

public class CharacterControllerAct : MonoBehaviour
{

    public Transform attachTransform;
    PlayerInput playerInput;
    public LayerMask tablesLayerMask;
    public LayerMask itemsLayerMask;
    public Transform raycastTransform;
    //public Animator animator;
    public HabilityesController habilityesController;
    public float throwForce = 600f;
    private Slot slot;
    private Item item;

    public GameObject attachedObject;

    private void Start()
    {
        habilityesController = GetComponent<HabilityesController>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        HabilityAction();
        SlotAction();
    }
    public bool canUseHability;
    private void HabilityAction()
    {
        if (habilityesController.habilityType == HabilityType.LevitationItems)
        {
            if (attachedObject != null)
            {
                habilityesController.hability.SetHabilityAvalableFalse();
                if (playerInput.squareBtn.Down)
                {
                    habilityesController.hability.UseHability();
                }
                if (habilityesController.hability.usingHability)
                {
                    if (playerInput.XBtn.Down)
                    {
                        habilityesController.hability.StopHability();
                    }
                }
            }
        }
        else if(habilityesController.habilityType==HabilityType.SpeedTheFire)
        {
            if (playerInput.squareBtn.Down)
            {
                habilityesController.hability.SetHabilityAvalableFalse();
                habilityesController.hability.UseHability();
            }
        } 
        else if(habilityesController.habilityType == HabilityType.Throw)
        {
            if(playerInput.squareBtn.Down)
            {
                ThrowObj();
            }
        }
    }

    void SlotAction()
    {
        if (attachedObject == null)
        {
            if (playerInput.XBtn.Down)
            {
                Catch();
            }
            if (playerInput.triangleBtn.Hold)
                Action();
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

        if (Physics.Raycast(raycastTransform.position, transform.forward, out hit, 1, itemsLayerMask))
        {
            item = hit.collider.GetComponent<Item>();
            item.transform.eulerAngles = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.Catch(this);
        }
        else if(Physics.Raycast(raycastTransform.position, transform.forward + new Vector3(0, 0.5f, 0), out hit, 1, itemsLayerMask))
        {
            item = hit.collider.GetComponent<Item>();
            item.transform.eulerAngles = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.Catch(this);
        }
        else if (Physics.Raycast(raycastTransform.position, raycastTransform.forward, out hit, 2, tablesLayerMask))
        {
            slot = hit.collider.GetComponent<Slot>();
            slot.Catch(this);
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

    public void ThrowObj()
    {
        if(attachedObject != null)
        {
            attachedObject.GetComponent<RigidbodyController>().ActiveRigidbody(true);
            attachedObject.transform.parent = null;
            attachedObject.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
            attachedObject = null;
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
            slot = hit.collider.GetComponent<Slot>();
            slot.Action(this);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(raycastTransform.position, transform.forward * 1f);
    }

}
