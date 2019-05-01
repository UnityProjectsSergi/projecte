using UnityEngine;
using System.Collections;
using System;

namespace FSM
{
    public class FSM_Alert : FiniteStateMachine
    {
        public enum States { INITIAL, ALERT,PAUSE, END }
        public States currentState;
        public States lastState;
        public AlertBlackBoard AlertBlackBoard;
      
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
        }
        
        // Use this for initialization
      

        // Update is called once per frame
       public  void Update()
        {
            // SURTIR DEL VELL ESTAT
            switch (currentState)
            {
                case States.INITIAL:
                    ChangeState(States.ALERT);
                    break;
                case States.ALERT:
                    if (!isPaused)
                    {
                        if (AlertBlackBoard.FSM_ShowHideImage.currentState == FSM_ShowHideImage.States.END)
                        {
                            ChangeState(States.END);
                        }
                    }
                    else
                    {
                        lastState = currentState;
                        ChangeState(States.PAUSE);
                    }
                    break;
                case States.END:
                    break;
                case States.PAUSE:
                    if(!isPaused)
                    {
                        ChangeState(States.ALERT);
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
                    if (newState == States.END)
                        AlertBlackBoard.FSM_ShowHideImage.Exit();

                    break;
                case States.PAUSE:
                 
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
                    if(currentState==States.INITIAL)
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

        internal void Reset()
        {
            
        }
    }
}