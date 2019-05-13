using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossRotation : MonoBehaviour
{
    public float iCoolDownRotation;
    public float increaseYawRotation;
    private float coolDownRotation;

    private bool isMoving = false;
    private Quaternion nextRotation;

    private void Start()
    {
        coolDownRotation = iCoolDownRotation;
        nextRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, increaseYawRotation, 0));
    }

    private void Update()
    {      
        
        if (coolDownRotation <= 0 && !isMoving)
        {
            isMoving = true;
            coolDownRotation = iCoolDownRotation;
        }
        else if(!isMoving)
            coolDownRotation -= Time.deltaTime;

        isMoving = RotateCross();
    }

    private bool RotateCross()
    {
        if (!isMoving)
            return false;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, nextRotation, 45 * Time.deltaTime);

        if (transform.rotation == nextRotation)
        {
            nextRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, increaseYawRotation, 0));
            return false;
        }

        return true;
    }
}
