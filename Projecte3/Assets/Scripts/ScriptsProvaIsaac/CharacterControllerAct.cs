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
    public Transform raycastTransform;
    public HabilityesController habilityesController;
    public float throwForce = 600f;
    private Slot slot;
    private Item item;

    public GameObject attachedObject;

    //Portal Habiliti
    public GameObject portal;
    private bool movePortalA = true;
    public bool canMovePortals = true;
    private GameObject portalA;
    private GameObject portalB;
    private Portal pa;
    private Portal pb;

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
    }
    public bool canUseHability;
    private float fovAngle=5f;

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
                ThrowObj();
        } else if(habilityesController.habilityType == HabilityType.Portal)
        {
            if(playerInput.squareBtn.Down)
            {
                habilityesController.hability.SetHabilityAvalableFalse();
                habilityesController.hability.UseHability();
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
        }
        else
        {
            if (playerInput.XBtn.Down)
                LeaveObjOn();
        }
        HightLightSlot();
    }
    Vector3 leftRayRotation;
    Vector3 rightRayRotation;
   
    private void HightLightSlot()
    {
      
         leftRayRotation = Quaternion.AngleAxis(-fovAngle, transform.up) * transform.forward;
         rightRayRotation = Quaternion.AngleAxis(fovAngle, transform.up) * transform.forward;
        RaycastHit Hit, LHit, RHit;
        bool Front = Physics.Raycast(raycastTransform.position, transform.forward, out Hit, 1, tablesLayerMask);
        bool LFront = Physics.Raycast(raycastTransform.position, leftRayRotation, out LHit, 1, tablesLayerMask);
        bool RFront = Physics.Raycast(raycastTransform.position, rightRayRotation, out RHit, 1, tablesLayerMask);
        if (Front)
        {
            
        }
        if (LFront)
        {
            Debug.Log("Left");
        }
        if (RFront)
        {
            Debug.Log("Right");
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

    public void PutPortal()
    {
        RaycastHit hit;
        if (!Physics.Raycast(raycastTransform.position, transform.forward, out hit, 1.6f, tablesLayerMask) && canMovePortals)
        {
            Vector3 _portalPosition = new Vector3(transform.position.x + transform.forward.x, 1, transform.position.z + transform.forward.z);
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
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(raycastTransform.position, transform.forward * 1f);
        Gizmos.DrawRay(raycastTransform.position, leftRayRotation * 1);
        Gizmos.DrawRay(raycastTransform.position, rightRayRotation * 1f);
    }

}
