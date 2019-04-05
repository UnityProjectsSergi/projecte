using NewSysemInput;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public ControlerLayout ControlerLayout;
    private string horitzontalAxis;
    private string verticalAxis;
    // buttons for player 
    public string settingsBtn;
    public bool settingBtn;
    private string Button_2;
    public string platformCtrl;
    private int controllerNumber=1;

    internal void SetPlatformController(string platform)
    {
        Debug.Log(platform);
        platformCtrl = platform;
        Debug.Log(platformCtrl);
    }

    public float Horizontal { get; set; }
    public float Vertical { get; set; }
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
       // ControlerLayout = new ControlerLayout();
    }
    public void setControlerLayout(ControlerLayout controlerLayout)
    {
        ControlerLayout = controlerLayout;
    }
    internal void SetControllerNumber(int number)
    {
       // ControlerLayout.HorizontalMovimentAxis = "s";
        controllerNumber = number;
        horitzontalAxis = "J" + controllerNumber + "Horizontal"+platformCtrl;
        verticalAxis = "J" + controllerNumber + "Vertical"+platformCtrl;
        settingsBtn = "J" + controllerNumber + "Settings" + platformCtrl;

        // jo he seperat els inputs del player 
    }
    // Update is called once per frame
    private void Update()

    { // assigno el  nummero de player 1 o 2  
        if(controllerNumber>0)
        {

            Horizontal =Mathf.Ceil(InputManager.Instance.GetAxis(horitzontalAxis));
            
            Vertical =Mathf.Ceil( InputManager.Instance.GetAxis(verticalAxis));
            settingBtn = InputManager.Instance.GetButtonOnHold(settingsBtn);
        }
    }
}
