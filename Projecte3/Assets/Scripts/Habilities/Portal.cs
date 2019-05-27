using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject tpPoint;
    public Portal otherPortal;

    public bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (!other.gameObject.GetComponent<CharacterControllerAct>().canMovePortals && canTeleport)
            {
                otherPortal.canTeleport = false;
                other.gameObject.GetComponent<CharacterController>().enabled = false;
                other.gameObject.transform.position = new Vector3(otherPortal.transform.position.x, gameObject.transform.position.y, otherPortal.transform.position.z);               
                other.gameObject.GetComponent<CharacterController>().enabled = true;
                Debug.Log(other.gameObject.transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
            canTeleport = true;
    }
}
