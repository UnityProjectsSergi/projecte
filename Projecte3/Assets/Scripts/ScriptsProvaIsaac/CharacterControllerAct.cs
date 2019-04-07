using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerAct : MonoBehaviour
{
    public Transform attachTransform;

    private ItemBox itemBox;

    bool canTakeItem = false;

    void Update()
    {
        Action();
    }

    void Action()
    {
        Debug.Log(Input.GetAxis("J1XButtonPS4"));
        if(canTakeItem)
        {           
            if(Input.GetAxis("J1XButtonPS4") > 0)
            {
                Debug.Log("instantiate");
                Instantiate(itemBox.item, attachTransform.position, Quaternion.identity, attachTransform);
            }       
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            canTakeItem = true;
            itemBox = other.gameObject.GetComponent<ItemBox>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            canTakeItem = false;
            itemBox = null;
        }
    }
}
