using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int m_NumPlayer = 1;
    CharacterController m_CharacterController;
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
    private PlayerInput playerInput;
    [Header("Gravity Settings")]
    public float m_GravityMultiplier = 3.7f;
    float m_VerticalSpeed = 0.0f;
    bool m_OnGround = false;
    float l_SpeedMultiplier = 1.0f;
    public float m_FastSpeedMultiplier = 1.6f;
    public float movementSpeed;
    public float rotationSpeed;
    private Vector3 Direction { get; set; }
    private void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_MainCamera = Camera.main;
        l_Forward = gameObject.transform.forward;
        l_Right = gameObject.transform.right;
        playerInput = GetComponent<PlayerInput>();
        playerInput.SetControllerNumber(1, "PS4");
    }

    void Update()
    {
        MovePS4Controller();
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

        if (l_IsMove)
        {
            l_Speed += m_Acceleration * Time.deltaTime;
            l_Speed = Mathf.Clamp(l_Speed, m_Acceleration, m_MaxSpeed);
            l_Movement.Normalize();
            l_Movement *= Time.deltaTime * l_Speed;
            //transform.forward = l_Movement;
        }
        else
            l_Speed = 0.0f;

        CollisionFlags l_CollisionFlags = m_CharacterController.Move(l_Movement);
    }

    private void MovePS4Controller()
    {
        Direction = new Vector3(playerInput.leftHorizontal, 0, playerInput.leftVertical);
        if (!IsMoving) return;
        transform.rotation = Rotation;
        m_CharacterController.Move(Direction * movementSpeed * Time.deltaTime);
    }

    void GravityController()
    {
        m_VerticalSpeed += (Physics.gravity.y * m_GravityMultiplier) * Time.deltaTime;
        l_Movement.y = m_VerticalSpeed * Time.deltaTime;

        CollisionFlags l_CollisionFlags = m_CharacterController.Move(l_Movement);

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
}
