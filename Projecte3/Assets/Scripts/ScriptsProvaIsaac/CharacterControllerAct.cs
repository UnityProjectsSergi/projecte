using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.InputSystem;

public class CharacterControllerAct : MonoBehaviour
{
    public Transform attachTransform;
    PlayerInput playerInput;

    private Slot slot;
    private bool inSlot;

    private GameObject attachedObject;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (inSlot)
            Action();
    }

    void Action()
    {
        if (attachedObject == null)
        {
            if (playerInput.XBtn.Down)
                slot.Catch(attachTransform, ref attachedObject);
        }     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Slot")
        {
            inSlot = true;
            slot = other.gameObject.GetComponent<Slot>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Slot")
        {
            inSlot = false;
            slot = null;
        }
    }
}
