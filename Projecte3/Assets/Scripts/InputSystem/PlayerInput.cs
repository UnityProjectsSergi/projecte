using NewSysemInput;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.InputSystem
{
    public class PlayerInput : MonoBehaviour
    {
        #region Strings
        private string _leftHoritzontalAxis;
        public string _leftVerticalAxis;
        public string _rightHoritzontalAxis;
        public string _rightVerticalAxis;
        public string _platformCtrl;
        public string _settingsBtn;
        public string _startBtn;
        public string _shareBtn;
        public string _triangleBtn;
        public string _squareBtn;
        public string _XBtn;
        public string _OBtn;
        public string _touchpadBtn;
        public string _rightStickClick;
        public string _leftStickClick;
        public string _R2Btn, _R1Btn, _L1Btn, _L2Btn;

        internal void SetControllerNumber(object playercontroller, string v)
        {
            throw new NotImplementedException();
        }

        public string _L2Axis, _R2Axis;
        public string _dPadHorizontal, _dPadVertical;

        #endregion
        #region Vars
        // buttons for player 
        public ButtonInputPlayer settingsBtn=new ButtonInputPlayer();
        public ButtonInputPlayer startBtn = new ButtonInputPlayer();
        public ButtonInputPlayer shareBtn = new ButtonInputPlayer();
        public ButtonInputPlayer triangleBtn = new ButtonInputPlayer();
        public ButtonInputPlayer squareBtn = new ButtonInputPlayer();
        public ButtonInputPlayer XBtn = new ButtonInputPlayer();
        public ButtonInputPlayer OBtn = new ButtonInputPlayer();
        public ButtonInputPlayer touchPadBtn = new ButtonInputPlayer();
        public ButtonInputPlayer rightStickClick = new ButtonInputPlayer();
        public ButtonInputPlayer leftStickClick = new ButtonInputPlayer();
        public ButtonInputPlayer R2Btn = new ButtonInputPlayer();
        public ButtonInputPlayer L2Btn = new ButtonInputPlayer();
        public ButtonInputPlayer L1Btn = new ButtonInputPlayer();
        public ButtonInputPlayer R1Btn = new ButtonInputPlayer();
        public AxisInputPlayer DPadAxis = new AxisInputPlayer();
        public AxisInputPlayer L2Axis = new AxisInputPlayer();
        public AxisInputPlayer R2Axis = new AxisInputPlayer();
        public AxisInputPlayer RightStick = new AxisInputPlayer();
        public AxisInputPlayer LeftStick = new AxisInputPlayer();
        public DPadButton DPadButton = new DPadButton();
        public int controllerNumber = 1;
        private float lastBtnStateH;

        #endregion
        private void Awake()
        {

        }
        // Start is called before the first frame update
        void Start()
        {
            // ControlerLayout = new ControlerLayout();
        }
        internal void SetControllerNumber(int number, string platctr)
        {
            _platformCtrl = platctr;
            controllerNumber = number;
            _leftHoritzontalAxis = "J" + controllerNumber + "LeftStickHorizontal" + _platformCtrl;
            _leftVerticalAxis = "J" + controllerNumber + "LeftStickVertical" + _platformCtrl;
            _rightHoritzontalAxis = "J" + controllerNumber + "RightStickHorizontal" + _platformCtrl;
            _rightVerticalAxis = "J" + controllerNumber + "RightStickVertical" + _platformCtrl;
            _settingsBtn = "J" + controllerNumber + "SettingsButton" + _platformCtrl;
            _startBtn = "J" + controllerNumber + "StartButton" + _platformCtrl;
            _squareBtn = "J" + controllerNumber + "SquareButton" + _platformCtrl;
            _triangleBtn = "J" + controllerNumber + "TriangleButton" + _platformCtrl;
            _XBtn = "J" + controllerNumber + "XButton" + _platformCtrl;
            _OBtn = "J" + controllerNumber + "OButton" + _platformCtrl;
            _touchpadBtn = "J" + controllerNumber + "TouchpadButton" + _platformCtrl;
            _leftStickClick = "J" + controllerNumber + "LeftStickClick" + _platformCtrl;
            _rightStickClick = "J" + controllerNumber + "RightStickClick" + _platformCtrl;
            _R1Btn = "J" + controllerNumber + "R1Button" + _platformCtrl;
            _R2Btn = "J" + controllerNumber + "R2Button" + _platformCtrl;
            _L1Btn = "J" + controllerNumber + "L1Button" + _platformCtrl;
            _L2Btn = "J" + controllerNumber + "L2Button" + _platformCtrl;
            _L2Axis = "J" + controllerNumber + "L2Axis" + _platformCtrl;
            _R2Axis = "J" + controllerNumber + "R2Axis" + _platformCtrl;
            _dPadHorizontal = "J" + controllerNumber + "DPadHorizontal" + _platformCtrl;
            _dPadVertical = "J" + controllerNumber + "DPadVertical" + _platformCtrl;
            _shareBtn = "J" + controllerNumber + "ShareButton" + _platformCtrl;

            // jo he seperat els inputs del player 
        }
        // Update is called once per frame
        private void Update()
        { // assigno el  nummero de player 1 o 2

            //     Debug.Log("chec");
            //if (Input.GetJoystickNames().Length > 0)
            //{
            //    if (string.IsNullOrWhiteSpace(Input.GetJoystickNames()[controllerNumber]))
            //        Debug.Log("connect Controller " + Input.GetJoystickNames()[controllerNumber]);
            //}
            if (controllerNumber > 0)
            {
                //foreach (var item in Input.GetJoystickNames())
                //{
                //    Debug.Log(item.ToString());
                //}
              //  Debug.Log(Input.GetJoystickNames().Length + " is moved");
                //Left Stick
                LeftStick.Horizontal = Input.GetAxis(_leftHoritzontalAxis);
                LeftStick.Vertical = Input.GetAxis(_leftVerticalAxis);
             //   Debug.Log(LeftStick.Vertical +" "+ controllerNumber);
                //Right Stck
                RightStick.Horizontal = InputManager.Instance.GetAxis(_rightHoritzontalAxis);
                RightStick.Vertical = InputManager.Instance.GetAxis(_rightVerticalAxis);
                    // Dpad Axis
              
                    DPadAxis.Vertical = InputManager.Instance.GetAxis(_dPadVertical);
                    DPadAxis.Horizontal = InputManager.Instance.GetAxis(_dPadHorizontal);
              
                //R2  and L2 Axis
                R2Axis.Vertical = InputManager.Instance.GetAxis(_R2Axis);
                L2Axis.Vertical = InputManager.Instance.GetAxis(_L2Axis);
                // Settings btn
                settingsBtn.Hold = InputManager.Instance.GetButtonOnHold(_settingsBtn);
                settingsBtn.Down = InputManager.Instance.GetButtonDown(_settingsBtn);
                settingsBtn.Up = InputManager.Instance.GetButtonUp(_settingsBtn);
                // Share Btn
                shareBtn.Hold = InputManager.Instance.GetButtonOnHold(_shareBtn);
                shareBtn.Down = InputManager.Instance.GetButtonDown(_shareBtn);
                shareBtn.Up = InputManager.Instance.GetButtonUp(_shareBtn);
                //Start btn
                startBtn.Hold = InputManager.Instance.GetButtonOnHold(_startBtn);
                startBtn.Down = InputManager.Instance.GetButtonDown(_startBtn);
                startBtn.Up = InputManager.Instance.GetButtonUp(_startBtn);


                // L2 Btn
                L2Btn.Hold = InputManager.Instance.GetButtonOnHold(_L2Btn);
                L2Btn.Down = InputManager.Instance.GetButtonDown(_L2Btn);
                L2Btn.Up = InputManager.Instance.GetButtonUp(_L2Btn);
                // R2 Btn
                R2Btn.Hold = InputManager.Instance.GetButtonOnHold(_R2Btn);
                R2Btn.Down = InputManager.Instance.GetButtonDown(_R2Btn);
                R2Btn.Up = InputManager.Instance.GetButtonUp(_R2Btn);
                // R1 Btn
                R1Btn.Hold = InputManager.Instance.GetButtonOnHold(_R1Btn);
                R1Btn.Up = InputManager.Instance.GetButtonUp(_R1Btn);
                R1Btn.Down = InputManager.Instance.GetButtonDown(_R1Btn);
                // L1 Btn
                L1Btn.Hold = InputManager.Instance.GetButtonOnHold(_L1Btn);
                L1Btn.Down = InputManager.Instance.GetButtonDown(_L1Btn);
                L1Btn.Up = InputManager.Instance.GetButtonUp(_L1Btn);
                // Right Stick Click
                rightStickClick.Hold = InputManager.Instance.GetButtonOnHold(_rightStickClick);
                rightStickClick.Up = InputManager.Instance.GetButtonUp(_rightStickClick);
                rightStickClick.Down = InputManager.Instance.GetButtonDown(_rightStickClick);
                // Left Stick
                leftStickClick.Hold = InputManager.Instance.GetButtonOnHold(_leftStickClick);
                leftStickClick.Down = InputManager.Instance.GetButtonDown(_leftStickClick);
                leftStickClick.Up = InputManager.Instance.GetButtonUp(_leftStickClick);
                // Touckpd Btn
                touchPadBtn.Hold = InputManager.Instance.GetButtonOnHold(_touchpadBtn);
                touchPadBtn.Up = InputManager.Instance.GetButtonUp(_touchpadBtn);
                touchPadBtn.Down = InputManager.Instance.GetButtonDown(_touchpadBtn);
                // X Btn
                XBtn.Hold = InputManager.Instance.GetButtonOnHold(_XBtn);
                XBtn.Up = InputManager.Instance.GetButtonUp(_XBtn);
                XBtn.Down = InputManager.Instance.GetButtonDown(_XBtn);
                // OBtn
                OBtn.Hold = InputManager.Instance.GetButtonOnHold(_OBtn);
                OBtn.Up = InputManager.Instance.GetButtonUp(_OBtn);
                OBtn.Down = InputManager.Instance.GetButtonDown(_OBtn);
                //square Btn
                squareBtn.Hold = InputManager.Instance.GetButtonOnHold(_squareBtn);
                squareBtn.Up = InputManager.Instance.GetButtonUp(_squareBtn);
                squareBtn.Down = InputManager.Instance.GetButtonDown(_squareBtn);
                // triangle Btn
                triangleBtn.Hold = InputManager.Instance.GetButtonOnHold(_triangleBtn);
                triangleBtn.Up = InputManager.Instance.GetButtonUp(_triangleBtn);
                triangleBtn.Down = InputManager.Instance.GetButtonDown(_triangleBtn);

                //DPadButton.Down = (InputManager.Instance.GetAxisRaw(_dPadVertical) == -1);
                //DPadButton.Up = (InputManager.Instance.GetAxisRaw(_dPadVertical) == 1);
                //DPadButton.Left = (InputManager.Instance.GetAxisRaw(_dPadHorizontal) == -1);
                //DPadButton.Right = (InputManager.Instance.GetAxisRaw(_dPadHorizontal) == 1);

            }
        }
    }
}