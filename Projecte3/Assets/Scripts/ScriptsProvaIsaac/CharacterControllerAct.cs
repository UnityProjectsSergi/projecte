using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.InputSystem;

public class CharacterControllerAct : MonoBehaviour
{
    public Transform attachTransform;
    PlayerInput playerInput;
    public LayerMask tablesLayerMask;
    public Transform raycastTransform;

    private Slot slot;
    private bool inSlot;

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
                    inSlot = true;
                    slot = hit.collider.GetComponent<Slot>();
                    slot.Catch(this);
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
                    inSlot = true;
                    slot = hit.collider.GetComponent<Slot>();
                    slot.LeaveObjOn(this);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * 1f);
    }
}
