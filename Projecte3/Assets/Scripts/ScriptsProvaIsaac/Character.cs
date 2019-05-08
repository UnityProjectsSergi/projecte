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
    private Vector3 _velocity;
    public bool _isGrounded = true;
    private Transform _groundChecker;
    

    void Start()
    {

        _controller = GetComponent<CharacterController>();
        _groundChecker = transform.GetChild(transform.childCount-1);
        playerInput = GetComponent<PlayerInput>();
        playerInput.SetControllerNumber(playercontroller, "PS4");
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0.0f)
            _velocity.y = 0f;
        
        Vector3 move = new Vector3(playerInput.LeftStick.Horizontal, 0, playerInput.LeftStick.Vertical);
        _controller.Move(move * Time.deltaTime * Speed);

        if (move != Vector3.zero)
            transform.forward = move;

        if (playerInput.OBtn.Down)
            _velocity += Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Drag.x + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * Drag.z + 1)) / -Time.deltaTime)));


        _velocity.y += Gravity * Time.deltaTime;

        _velocity.x /= 1 + Drag.x * Time.deltaTime;
        _velocity.y /= 1 + Drag.y * Time.deltaTime;
        _velocity.z /= 1 + Drag.z * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);

    }
}
