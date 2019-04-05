using NewSysemInput;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Strings
    public string _leftHoritzontalAxis;
    public string _leftVerticalAxis;
    public string _rightHoritzontalAxis;
    public string _rightVerticalAxis;
    public string _platformCtrl;
    public string _settingsBtn;
    public string _psBtn;
    public string _shareBtn;
    public string _triangleBtn;
    public string _squareBtn;
    public string _XBtn;
    public string _OBtn;
    public string _touchpadBtn;
    public string _rightStickClick;
    public string _leftStickClick;
    public string _R2Btn, _R1Btn, _L1Btn, _L2Btn;
    public string _L2Axis,_R2Axis;
    public string _dPadHorizontal, _dPadVertical;

    #endregion
    #region Vars
    // buttons for player 
    [SerializeField]
    public bool settingBtn;
    public bool psBtn;
    public bool shareBt;
    public bool triangleBtn;
    public bool squareBtn;
    public bool XBtn;
    public bool OBtn;
    public bool touchpadBtn;
    public bool rightStickClick;
    public bool leftStickClick;
    public bool R2Btn;
    public bool L2Btn;
    public bool L1Btn;
    public bool R1Btn;
    public float DPadHoriontal;
    public float DPadVertical;

    public float L2Axis;
    public float R2Axis;
    public int controllerNumber=1;
    public float rightHorizontal;
    public float rightVertical;
    public float leftHorizontal;
    public float leftVertical;
    #endregion
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
       // ControlerLayout = new ControlerLayout();
    }
    internal void SetControllerNumber(int number,string platctr)
    {
        _platformCtrl = platctr;
        controllerNumber = number;
        _leftHoritzontalAxis    = "J" + controllerNumber + "LeftStickHorizontal"+_platformCtrl;
        _leftVerticalAxis       = "J" + controllerNumber + "LeftStickVertical" + _platformCtrl;
        _rightHoritzontalAxis   = "J" + controllerNumber + "RightStickHorizontal" + _platformCtrl;
        _rightVerticalAxis      = "J" + controllerNumber + "RightStickVertical" + _platformCtrl;
        _settingsBtn            = "J" + controllerNumber + "SettingsButton" + _platformCtrl;
        _psBtn                  = "J" + controllerNumber + "StartButton" + _platformCtrl;
        _squareBtn              = "J" + controllerNumber + "SquareButton" + _platformCtrl;
        _triangleBtn            = "J" + controllerNumber + "TriangleButton" + _platformCtrl;
        _XBtn = "J" + controllerNumber + "XButton" + _platformCtrl;
        _OBtn = "J" + controllerNumber + "OButton" + _platformCtrl;
        _touchpadBtn = "J" + controllerNumber + "ToucchPadButton" + _platformCtrl;
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
        if(controllerNumber>0)
        {

            leftHorizontal =InputManager.Instance.GetAxis(_leftHoritzontalAxis);
            rightHorizontal = InputManager.Instance.GetAxis(_rightHoritzontalAxis);
            //  Debug.Log(Horizontal);
            leftVertical =InputManager.Instance.GetAxis(_leftVerticalAxis);
            rightVertical = InputManager.Instance.GetAxis(_rightVerticalAxis);
            // Debug.Log(Vertical);
            settingBtn = InputManager.Instance.GetButtonOnHold(_settingsBtn);
            shareBt = InputManager.Instance.GetButtonOnHold(_shareBtn);
            
            psBtn = InputManager.Instance.GetButtonOnHold(_psBtn);
            DPadHoriontal = InputManager.Instance.GetAxis(_dPadHorizontal);
            DPadVertical = InputManager.Instance.GetAxis(_dPadVertical);
            R2Axis = InputManager.Instance.GetAxis(_R2Axis);
            L2Axis = InputManager.Instance.GetAxis(_L2Axis);
        }
    }
}
