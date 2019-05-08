using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject tpPoint;
    public Portal otherPortal;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Portal Player Trigger Enter");
            Debug.Log(other.gameObject.transform.position);
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = otherPortal.tpPoint.transform.position;
            other.gameObject.GetComponent<CharacterController>().enabled = true;
            Debug.Log(other.gameObject.transform.position);
        }
    }
}
