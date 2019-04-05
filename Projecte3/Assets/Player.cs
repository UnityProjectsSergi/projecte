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
        playerInput.SetControllerNumber(1,"PS");
    //    playerInput.SetPlatformController("PS");
    }

    // Update is called once per frame
    void Update()
    {
        /// cada pplaayer te el seu player input
        Debug.Log(playerInput.settingBtn);
        // aixo va 
        // asi no hay que tener el num de jugador
        Direction = new Vector3(playerInput.Horizontal, 0, playerInput.Vertical);
  //      Debug.Log(Direction);
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