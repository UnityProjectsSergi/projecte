using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.InputSystem;

public class Character : MonoBehaviour
{
    public PlayerInput playerInput;
    public float Speed = 5f;
  
    public float Gravity = -9.81f;
    public float GroundDistance = 0.1f;
    public float DashDistance = 5f;
    public LayerMask Ground;
    public Vector3 Drag;
    public int playercontroller;

    private CharacterController _controller;
    private CharacterControllerAct ccAct;
    private Vector3 _velocity;
    public bool _isGrounded = true;
    private Transform _groundChecker;
    private bool isAwake = false;
    

    void Awake()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.CheckPlayerActive(playercontroller, this.gameObject);
            ccAct = GetComponent<CharacterControllerAct>();
            _controller = GetComponent<CharacterController>();
            _groundChecker = transform.GetChild(transform.childCount - 1);
            playerInput = GetComponent<PlayerInput>();
            playerInput.SetControllerNumber(playercontroller, "PS4");
            isAwake = true;
        }
    }

    void Start()
    {
        if (!isAwake)
        {
            GameManager.Instance.CheckPlayerActive(playercontroller, this.gameObject);

            ccAct = GetComponent<CharacterControllerAct>();
            _controller = GetComponent<CharacterController>();
            _groundChecker = transform.GetChild(transform.childCount - 1);
            playerInput = GetComponent<PlayerInput>();
            playerInput.SetControllerNumber(playercontroller, "PS4");
        }
    }

    void Update()
    {    
        _isGrounded = Physics.Raycast(transform.position, -transform.up, 2, Ground);

        if (_isGrounded)
            _velocity.y = 0f;
        
        Vector3 move = new Vector3(playerInput.LeftStick.Horizontal, 0, playerInput.LeftStick.Vertical);

        _controller.Move(move * Time.deltaTime * Speed);

        AnimationControll(move);

        if (move != Vector3.zero)
        {            
            transform.forward = move;
        }


        if (playerInput.OBtn.Down)
        {
            SoundManager.Instance.OneShotEvent("event:/MOVIMIENTO PERSONAJE/DASH", transform.position);
           Vector3 dash= Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Drag.x + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * Drag.z + 1)) / -Time.deltaTime)));
            _velocity += dash;           
        }

        _velocity.y += Gravity * Time.deltaTime;

        _velocity.x /= 1 + Drag.x * Time.deltaTime;
        _velocity.y /= 1 + Drag.y * Time.deltaTime;
        _velocity.z /= 1 + Drag.z * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);
    }
    public void OnControllerColliderHit( ControllerColliderHit hit)
    {
        var v3 = hit.transform.position - transform.position;
        var angle = Vector3.Angle(v3, transform.forward);

        if (angle > 45.0 && angle < 135.0)
            Debug.Log("Side hit");
    }

    private void AnimationControll(Vector3 move)
    {
        if (move.magnitude >= 0.1)
        {
            Debug.Log("asdsadsa = " + ccAct.HasItem);
            if (!ccAct.HasItem)
            {
                ccAct.animator.SetBool("toMove", true);
                ccAct.animator.SetBool("toIdle", false);
                ccAct.animator.SetBool("toLlevarIdle", false);
            }
            else
            {
                ccAct.animator.SetBool("toLlevar", true);
                ccAct.animator.SetBool("toIdle", false);
                ccAct.animator.SetBool("toLlevarIdle", false);
            }
        }
        else
        {
            if (!ccAct.HasItem)
            {
                ccAct.animator.SetBool("toMove", false);
                ccAct.animator.SetBool("toLlevar", false);
                ccAct.animator.SetBool("toLlevarIdle", false);
                ccAct.animator.SetBool("toIdle", true);
            }
            else
            {
                ccAct.animator.SetBool("toMove", false);
                ccAct.animator.SetBool("toLlevar", false);
                ccAct.animator.SetBool("toIdle", false);
                ccAct.animator.SetBool("toLlevarIdle", true);
            }
        }
    }

    public void SetVelocityY(float value)
    {
        _velocity.y = value;
    }
}
