using Assets.Scripts.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    CharacterController characterController;
    Camera m_MainCamera;

    [Header("Move Settings")]
    public float m_MaxSpeed = 10.0f;
    public float m_Acceleration = 1.0f;
    float l_Speed = 0.0f;
    public KeyCode m_UpKeyCode = KeyCode.W;
    public KeyCode m_DownKeyCode = KeyCode.S;
    public KeyCode m_LeftKeyCode = KeyCode.A;
    public KeyCode m_RightKeyCode = KeyCode.D;
    Vector3 l_Movement;
    Vector3 l_Forward;
    Vector3 l_Right;
    public PlayerInput playerInput;
    [Header("Gravity Settings")]
    public float m_GravityMultiplier = 3.7f;
    float m_VerticalSpeed = 0.0f;
    bool m_OnGround = false;
    float l_SpeedMultiplier = 1.0f;
    public float m_FastSpeedMultiplier = 1.6f;
    public float movementSpeed;
    public float rotationSpeed;
    private Vector3 Direction { get; set; }
    public int playercontroller;
   public CollisionFlags l_CollisionFlags;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        m_MainCamera = Camera.main;
        l_Forward = gameObject.transform.forward;
        l_Right = gameObject.transform.right;
        playerInput = GetComponent<PlayerInput>();
        playerInput.SetControllerNumber(playercontroller, "PS4");
        foreach (var item in Input.GetJoystickNames())
        {
          //  Debug.Log(item );
        } 
    }
    public bool dd = true;
    void Update()
    {

        // requires you to set up axes "Joy0X" - "Joy3X" and "Joy0Y" - "Joy3Y" in the Input Manger
     

        //  Debug.Log("j2 x" + Input.GetAxis("J2LeftStickHorizontalPS4"));
        if (playerInput.settingsBtn.Down)
        {
            Debug.Log("setting btn down");
        }
        MovePS4Controller();
        //Move();
     //   ColliderFlags();
        GravityController();
    }

    //Solo para provar sin mando
    private void Move()
    {
        bool l_IsMove = false;
        l_Movement = Vector3.zero;

        if (Input.GetKey(m_UpKeyCode))
        {
            l_Movement = l_Forward;
            l_IsMove = true;
        }
        else if (Input.GetKey(m_DownKeyCode))
        {
            l_Movement = -l_Forward;
            l_IsMove = true;
        }

        if (Input.GetKey(m_RightKeyCode))
        {
            l_Movement += l_Right;
            l_Movement.Normalize();
            l_IsMove = true;
        }
        else if (Input.GetKey(m_LeftKeyCode))
        {
            l_Movement += -l_Right;
            l_Movement.Normalize();
            l_IsMove = true;
        }

        if(l_IsMove)
        {
            l_Speed += m_Acceleration * Time.deltaTime;
            l_Speed = Mathf.Clamp(l_Speed, m_Acceleration, m_MaxSpeed);
            l_Movement.Normalize();
            l_Movement *= Time.deltaTime * l_Speed;
            //transform.forward = l_Movement;
        }
        else
            l_Speed = 0.0f;

         l_CollisionFlags = characterController.Move(l_Movement);
     
    }

    private void MovePS4Controller()
    {
        Direction = new Vector3(playerInput.LeftStick.Horizontal, 0, playerInput.LeftStick.Vertical);
        if (!IsMoving) return;
        transform.rotation = Rotation;
  //      l_CollisionFlags= characterController.Move(Direction * movementSpeed * Time.deltaTime);
    }

    void GravityController()
    {
        m_VerticalSpeed += (Physics.gravity.y * m_GravityMultiplier) * Time.deltaTime;
        l_Movement.y = m_VerticalSpeed * Time.deltaTime;

        l_CollisionFlags= characterController.Move(l_Movement);

        if ((l_CollisionFlags & CollisionFlags.Below) != 0)
        {
            m_OnGround = true;
            m_VerticalSpeed = 0.0f;
        }
        else
            m_OnGround = false;

        if ((l_CollisionFlags & CollisionFlags.Above) != 0 && m_VerticalSpeed > 0.0f)
            m_VerticalSpeed = 0.0f;
    }
    private bool IsMoving => Direction != Vector3.zero;

    private Quaternion Rotation => Quaternion.LookRotation(RotationDirection);

    private Vector3 RotationDirection =>
        Vector3.RotateTowards(
            transform.forward,
            Direction,
            rotationSpeed * Time.deltaTime,
            0);
    public void ColliderFlags()
    {
        if (characterController.collisionFlags == CollisionFlags.None)
            print("Free floating!");

        if ((characterController.collisionFlags & CollisionFlags.Sides) != 0)
            print("Touching sides!");

        if (characterController.collisionFlags == CollisionFlags.Sides)
            print("Only touching sides, nothing else!");

        if ((characterController.collisionFlags & CollisionFlags.Above) != 0)
            print("Touching sides!");

        if (characterController.collisionFlags == CollisionFlags.Above)
            print("Only touching Ceiling, nothing else!");

        if ((characterController.collisionFlags & CollisionFlags.Below) != 0)
            print("Touching ground!");

        if (characterController.collisionFlags == CollisionFlags.Below)
            print("Only touching ground, nothing else!");
    }

}
