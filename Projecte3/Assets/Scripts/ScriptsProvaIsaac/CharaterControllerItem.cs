using Assets.Scripts.InputSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterControllerItem : MonoBehaviour
{
   [HideInInspector]
  public  CharacterController characterController;
     
    public PlayerInput playerInput;
     
    public float amplitud, frequenia;
   
    public Vector3 Direction;
    public int playercontroller;
   

 
    public float speed;

    /// <summary>
    /// says if isMoving or not
    /// </summary>
    private bool IsMoving => Direction != Vector3.zero;
    /// <summary>
    /// 
    /// </summary>
    private Quaternion Rotation => Quaternion.LookRotation(RotationDirection);

    private Vector3 RotationDirection =>
        Vector3.RotateTowards(
            transform.forward,
            Direction,
            speed* Time.deltaTime,
            0);

    private void Start()
    {
        if(gameObject.tag != "Item")
            GameManager.Instance.CheckPlayerActive(playercontroller, this.gameObject);

        characterController = GetComponent<CharacterController>();
       
       
    }
  
    public void setplayerinptu()
    {
        playerInput.SetControllerNumber(playercontroller, "PS4");
    }
    void Update()
    {
     if(playerInput!=null)
        Move();

       
   
    }

   
  

    public void Move()
    {
        //GravityController();
        MovementHorizontal();

  
        
        //l_CollisionFlags = characterController.Move(Direction *Parameters.currentVelocity* Time.deltaTime);
    }
    private void OnEnable()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }
    private void MovementHorizontal()
    {
        Direction = new Vector3(playerInput.LeftStick.Horizontal, Mathf.Sin(Time.fixedTime * Mathf.PI * frequenia) * amplitud, playerInput.LeftStick.Vertical);
     //   Direction += graity;
        if (!IsMoving) {  return; }
        Direction.Normalize();
      //  transform.rotation = Rotation;
        characterController.Move(Direction * speed* Time.deltaTime);
    }

    //void GravityController()
    //{
    //    m_VerticalSpeed += (Physics.gravity.y * m_GravityMultiplier) * Time.deltaTime;
    //    Direction.y = m_VerticalSpeed * Time.deltaTime;

    //    if ((l_CollisionFlags & CollisionFlags.Below) != 0)
    //    {
    //        onGround = true;
    //        m_VerticalSpeed = 0.0f;
    //    }
    //    else
    //        onGround = false;

    //    if ((l_CollisionFlags & CollisionFlags.Above) != 0 && m_VerticalSpeed > 0.0f)
    //        m_VerticalSpeed = 0.0f;
    //}

    //public void ColliderFlags()
    //{
    //    if (characterController.collisionFlags == CollisionFlags.None)
    //        print("Free floating!");

    //    if ((characterController.collisionFlags & CollisionFlags.Sides) != 0)
    //        print("Touching sides!");

    //    if (characterController.collisionFlags == CollisionFlags.Sides)
    //        print("Only touching sides, nothing else!");

    //    if ((characterController.collisionFlags & CollisionFlags.Above) != 0)
    //        print("Touching sides!");

    //    if (characterController.collisionFlags == CollisionFlags.Above)
    //        print("Only touching Ceiling, nothing else!");

    //    if ((characterController.collisionFlags & CollisionFlags.Below) != 0)
    //        print("Touching ground!");

    //    if (characterController.collisionFlags == CollisionFlags.Below)
    //        print("Only touching ground, nothing else!");
    //}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
    } 
}
