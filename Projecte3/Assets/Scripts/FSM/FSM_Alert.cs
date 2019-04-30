using UnityEngine;
using System.Collections;
namespace FSM
{
    public class FSM_Alert : FiniteStateMachine
    {
        public enum States { INITIAL, ALERT,PAUSE, END }
        public States currentState;
        public States lastState;
        public AlertBlackBoard AlertBlackBoard;
        public bool isPauseAlert;
        public override void Exit()
        {
            base.Exit();
        }
        public override void ReEnter()
        {

            base.ReEnter();
            currentState = States.INITIAL;
        }
        public void Start()
        {
            AlertBlackBoard = GetComponent<AlertBlackBoard>();
        
            //AlertBlackBoard.FSM_ShowHideImage.image = AlertBlackBoard.ImageCookingAlert;
            //AlertBlackBoard.FSM_ShowHideImage.timeHideImage = 0.0f;
            //AlertBlackBoard.FSM_ShowHideImage.timeShowImage = AlertBlackBoard.TimeShowImageDone;
            //AlertBlackBoard.FSM_ShowHideImage.timeWaitShowImage = AlertBlackBoard.timeWaitShowImageDone;
        }
        private void OnEnable()
        {
            //AlertBlackBoard = GetComponent<AlertBlackBoard>();
        }
        // Use this for initialization
      

        // Update is called once per frame
        void Update()
        {
            // SURTIR DEL VELL ESTAT
            switch (currentState)
            {
                case States.INITIAL:
                    ChangeState(States.ALERT);
                    break;
                case States.ALERT:
                    if (isPauseAlert)
                    {
                        lastState = currentState;
                        ChangeState(States.PAUSE);
                    }
                    else
                    {
                        if (AlertBlackBoard.FSM_ShowHideImage.currentState == FSM_ShowHideImage.States.HIDE)
                        {
                            ChangeState(States.END);
                        }
                        
                    }
                    break;
                case States.END:
                    break;
                case States.PAUSE:
                    
                    if(isPauseAlert)
                    {
                        ChangeState(lastState);
                    }
                    break;
                default:
                    break;
            }
        }
        // ENTRAR L NO¡OU ESTAT
        public void ChangeState(States newState)
        {
            switch (currentState)
            {
                case States.INITIAL:
                    break;
                case States.ALERT:
                  
               
                    break;
                case States.PAUSE:
                    Debug.Log("exit Paus00");
                    AlertBlackBoard.FSM_ShowHideImage.isPaused = false;
                    break;
                case States.END:
                    
                    break;
                default:
                    break;
            }
            switch (newState)
            {
                case States.INITIAL:
                    break;
                case States.ALERT:
                    AlertBlackBoard.FSM_ShowHideImage.ReEnter();
                    break;
                case States.END:
                    break;
                case States.PAUSE:
                    AlertBlackBoard.FSM_ShowHideImage.isPaused = true;
                    break;

                default:

                    break;
            }
            currentState = newState;
        }
    }
}