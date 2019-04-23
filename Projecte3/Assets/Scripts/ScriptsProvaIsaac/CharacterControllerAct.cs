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
    public Animator animator;

    private Slot slot;
    private Item item;

    public GameObject attachedObject;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
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
                Catch();
            if (playerInput.triangleBtn.Hold)
                Action();

            //Animation to Idle
            if (playerInput.triangleBtn.Up)
                animator.SetTrigger("Idle");
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

    private void LeaveObjOn()
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

    private void Action()
    {
     
        RaycastHit hit;
        if (Physics.Raycast(raycastTransform.position, raycastTransform.forward, out hit, 2, tablesLayerMask))
        {
            if (playerInput.triangleBtn.Down)
                animator.SetTrigger("Action");
            slot = hit.collider.GetComponent<Slot>();
            slot.Action(this);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(raycastTransform.position, transform.forward * 1f);
    }
}
