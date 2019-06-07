using System.Collections;
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
    public LayerMask portalLayerMask;
    public Transform raycastTransform;
    public HabilityesController habilityesController;
    public float throwForce = 600f;
    private Slot slot;
    private Item item;

    public GameObject attachedObject;
    public Animator animator;

    //Portal Habiliti
    public GameObject portal;
    private bool movePortalA = true;
    public bool canMovePortals = true;
    private GameObject portalA;
    private GameObject portalB;
    private Portal pa;
    private Portal pb;
    public bool canUseHability;
    private float fovAngle = 5f;

    public Slot activeSlot;
    public bool HasItem = false;

    private void Start()
    {
        habilityesController = GetComponent<HabilityesController>();
        playerInput = GetComponent<PlayerInput>();
        
        if(habilityesController.habilityType == HabilityType.Portal)
        {
            portalA = Instantiate(portal, new Vector3(200, 0, 0), Quaternion.identity);
            portalB = Instantiate(portal, new Vector3(200, 0, 0), Quaternion.identity);

            pa = portalA.GetComponent<Portal>();
            pb = portalB.GetComponent<Portal>();

            pa.otherPortal = pb;
            pb.otherPortal = pa;
        }
    }

    void Update()
    {
        HabilityAction();
        SlotAction();
        ActiveSlot();
    }
  
    private void HabilityAction()
    {
        if (habilityesController.habilityType == HabilityType.LevitationItems)
        {
            if (attachedObject != null)
            {
                if (habilityesController.hability.habilityHabailable) ;
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
                
                if(habilityesController.hability.habilityHabailable);
                habilityesController.hability.UseHability();
            }
        } 
        else if(habilityesController.habilityType == HabilityType.Throw)
        {
            if(playerInput.squareBtn.Down)
                ThrowObj();
        } else if(habilityesController.habilityType == HabilityType.Portal)
        {
            if(playerInput.squareBtn.Down)
                PutPortal();    
        }
    }

    void SlotAction()
    {
        if (playerInput.triangleBtn.Up)
        {
            animator.SetBool("toIdle", true);
            animator.SetBool("toMoler", false);
        }

        if (attachedObject == null)
        {
            if (playerInput.XBtn.Down)
                Catch();

            if (playerInput.triangleBtn.Hold)
            {
                Action();
            }          
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
            HasItem = true;
        }
        else if(Physics.Raycast(raycastTransform.position, transform.forward + new Vector3(0, 0.5f, 0), out hit, 1, itemsLayerMask))
        {
            item = hit.collider.GetComponent<Item>();
            item.transform.eulerAngles = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.Catch(this);
            HasItem = true;
        }
        else if (Physics.Raycast(raycastTransform.position, raycastTransform.forward, out hit, 1, tablesLayerMask))
        {          
            slot = hit.collider.GetComponent<Slot>();
            slot.Catch(this);
        }
        
    }

    public void LeaveObjOn()
    {
        if (attachedObject != null)
        {
            animator.SetBool("toLlevar", false);
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
            HasItem = false;
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

    public void PutPortal()
    {
        RaycastHit hit;

        Debug.Log("Can Move Portals: " + canMovePortals);
        if (!Physics.Raycast(raycastTransform.position, transform.forward, out hit, 1.6f, portalLayerMask) && canMovePortals)
        {
            Vector3 _portalPosition = new Vector3(transform.position.x + transform.forward.x, 1.5f, transform.position.z + transform.forward.z);
            if (movePortalA)
            {              
                portalA.transform.position = _portalPosition;
                movePortalA = !movePortalA;
                pa.tpPoint.transform.position = transform.position;
            }
            else
            {
                portalB.transform.position = _portalPosition;
                movePortalA = !movePortalA;
                pb.tpPoint.transform.position = transform.position;
                canMovePortals = false;
            }
        }
    }

    public void EndPortal()
    {
        portalA.transform.position = new Vector3(200, 0, 0);
        portalB.transform.position = new Vector3(200, 0, 0);
        canMovePortals = true;
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
            if(slot.GetComponent<CuttingSlot>() != null)
            {
                if (playerInput.triangleBtn.Down)
                {
                    animator.SetBool("toMoler", true);
                    animator.SetBool("toMove", false);
                    animator.SetBool("toIdle", false);
                }
            }
        }
    }

    private void ActiveSlot()
    {
        RaycastHit slotHit;
        if (Physics.Raycast(raycastTransform.position, transform.forward, out slotHit, 1, tablesLayerMask) /*&& slotHit.collider.GetComponent<Slot>() != activeSlot*/)
        {
            if (activeSlot != null)
                activeSlot.ChangeMaterialIni();
            activeSlot = slotHit.collider.GetComponent<Slot>();
            activeSlot.ChangeMaterialSelected();
        }

        if (activeSlot != null)
        {
            if ((activeSlot.gameObject.transform.position - transform.position).magnitude >= 1.9)
            {
                activeSlot.ChangeMaterialIni();
                activeSlot = null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(raycastTransform.position, transform.forward * 1f);
    }

}
