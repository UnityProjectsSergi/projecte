using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerInput playerInput;
    public float rotationSpeed;
    public float movementSpeed;
    public string PlatformCrl="PS";
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.SetControllerNumber(1);
        playerInput.SetPlatformController(PlatformCrl);
    }

    // Update is called once per frame
    void Update()
    {

        Direction = new Vector3(playerInput.Horizontal, 0, playerInput.Vertical);
        Debug.Log(Direction);
        if (!IsMoving) return;

        transform.position += Direction * movementSpeed * Time.deltaTime;
        transform.rotation = Rotation;
        
    }
    private bool IsMoving => Direction != Vector3.zero;

    private Vector3 Direction { get; set; }

    private Quaternion Rotation => Quaternion.LookRotation(RotationDirection);

    private Vector3 RotationDirection =>
        Vector3.RotateTowards(
            transform.forward,
            Direction,
            rotationSpeed * Time.deltaTime,
            0);
}
// a player faig q es mogui amb les 