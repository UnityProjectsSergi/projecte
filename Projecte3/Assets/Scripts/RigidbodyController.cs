using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour
{
    Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        ActiveRigidbody(false);
    }

    public void ActiveRigidbody(bool active)
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.detectCollisions = active;
        rigidbody.useGravity = active;

        if (!active)
        {
            rigidbody.constraints = RigidbodyConstraints.None;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
    }  
}
