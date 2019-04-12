using System;
using System.Collections.Generic;
using UnityEngine;

public class PushRigidbody : MonoBehaviour
{
    // this script pushes all rigidbodies that the character touches
    float pushPower = 2.5f;
    public CharacterControllerAct ccAct;

    private void Start()
    {
        ccAct = GetComponent<CharacterControllerAct>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3)
            return;

        // Calculate push direction from move direction,
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z) * pushPower;

        // Apply the push      
        RaycastHit rayHit;

        if (!Physics.Raycast(ccAct.raycastTransform.position, transform.forward, out rayHit, 2, ccAct.tablesLayerMask))
            body.velocity = new Vector3(pushDir.x, body.velocity.y, pushDir.z);
    }
}
