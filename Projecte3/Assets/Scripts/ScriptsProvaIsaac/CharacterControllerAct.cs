using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.InputSystem;
using Assets.Scripts.ObjPooler;

public class CharacterControllerAct : MonoBehaviour
{
    public Transform attachTransform;
    PlayerInput playerInput;
    public LayerMask tablesLayerMask;
    public LayerMask itemsLayerMask;
    public Transform raycastTransform;

<<<<<<< HEAD
    private Slot slot;
    private Item item;
/*
    public Slot slot;
    public bool inSlot;
    */
>>>>>>> 8df6cffc3668857d3bb36c2965ef337adcbbd45c

    public GameObject attachedObject;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        SlotAction();        
    }

    void SlotAction()
    {
        if (attachedObject == null)
        {
            if (playerInput.XBtn.Down)
            {
                RaycastHit hit;
                if (Physics.Raycast(raycastTransform.position, raycastTransform.forward, out hit, 2 , tablesLayerMask))
                {
                    slot = hit.collider.GetComponent<Slot>();
                    slot.Catch(this);
                }
                if (Physics.Raycast(raycastTransform.position, transform.forward, out hit, 1, itemsLayerMask))
                {
                    item = hit.collider.GetComponent<Item>();
                    item.Catch(this);
                }
            }
        }
        else
        {
            if (playerInput.XBtn.Down)
            {

                RaycastHit hit;
<<<<<<< HEAD
                if (Physics.Raycast(raycastTransform.position, transform.forward, out hit, 1, tablesLayerMask))
                {                  
=======
                if (Physics.Raycast(raycastTransform.position, raycastTransform.forward, out hit, 2, tablesLayerMask))
                {
                    inSlot = true;
>>>>>>> 8df6cffc3668857d3bb36c2965ef337adcbbd45c
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
    }

    private void OnDrawGizmos()
    {
<<<<<<< HEAD
        Gizmos.DrawRay(raycastTransform.position, transform.forward * 1f);
=======
        Gizmos.DrawRay(transform.position, transform.forward * 2f);
>>>>>>> 8df6cffc3668857d3bb36c2965ef337adcbbd45c
    }
}
