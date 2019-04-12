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

    private Slot slot;
    private Item item;

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
                if (Physics.Raycast(raycastTransform.position, transform.forward, out hit, 1, tablesLayerMask))
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
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(raycastTransform.position, transform.forward * 1f);
    }
}
