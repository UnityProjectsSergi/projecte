using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;
namespace NewSysemInput
{
    public class PlayerSI : MonoBehaviour//,IPlayerActions
    {
        public MasterInputs controls;
        //public Keyactions keyactions;
        [SerializeField] private float movementSpeed = 3;
        [SerializeField] private float rotationSpeed = 10;
        //public InputAction movement;
        public void Awake()
        {
            //controls.Player.SetCallbacks(this);
            // movement.performed += OnMovChanged;
            Debug.Log("sssssss");
            //keyactions.keyboard.fire.performed += ctd=> Fire();
            //keyactions.keyboard.fire.started.cancelled += ctd => Fire();
            //controls.Player.shoot.performed += ctxs => Shoot();
            controls.GamePlay.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
            // controls.GamePlay.btn.performed += ctx => btn();
        }

        private void btn()
        {
            Debug.Log("btn");
        }

        private void OnMovChanged(InputAction.CallbackContext context)
        {
            Debug.Log("sss");
        }


        void Fire()
        {
            Debug.Log("fire");
        }

        public void Shoot()
        {
            Debug.Log("shhot");
        }

        public void Move(Vector2 val)
        {
            Debug.Log("playr wats move" + val);
        }
        public void OnEnable()
        {
            Debug.Log("sssa");
            controls.Enable();
            //  Debug.Log(controls.Player.Movement);
        }

        public void OnDisable()
        {
            controls.Disable();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            Debug.Log("ssss");
            var direction = context.ReadValue<Vector2>();

            Direction = new Vector3(direction.x, 0, direction.y);

        }
        private void Update()
        {
            //_animator.SetBool(IsMovingParameterId, IsMoving);

            if (!IsMoving) return;

            transform.position += Direction * movementSpeed * Time.deltaTime;
            transform.rotation = Rotation;
        }

        public bool IsMoving => Direction != Vector3.zero;

        public Vector3 Direction { get; set; }

        public Quaternion Rotation => Quaternion.LookRotation(RotationDirection);

        public Vector3 RotationDirection =>
            Vector3.RotateTowards(
                transform.forward,
                Direction,
                rotationSpeed * Time.deltaTime,
                0);
    }
}