using UnityEngine;
using System.Collections;
using System;

namespace FSM
{
    public class FSM_Alert : FiniteStateMachine
    {
        public enum States { INITIAL, SLOW, NORMAL, FAST, PAUSE, END }
        public States currentState;
        public States lastState;
        //public enum States { INITIAL, ALERT,PAUSE, END }
        //public States currentState;
        //public States lastState;
        public AlertBlackBoard AlertBlackBoard;
     
        
      
        public override void Exit()
        {
            base.Exit();
        }
        public override void ReEnter()
        {

            base.ReEnter();
            currentState = States.INITIAL;
            AlertBlackBoard = GetComponent<AlertBlackBoard>();
        }
        public void Start()
        {
            
            // FSM_AlertStates = GetComponent<FSM_AlertStates>();
        }

        // Use this for initialization


        // Update is called once per frame
        void Update()
        {
            switch (currentState)
            {
                case States.INITIAL:
                    ChangeState(States.SLOW);
                    break;
                case States.SLOW:
                    if (!isPaused)
                    {

                        if (AlertBlackBoard.FSM_ShowHideImage.currentState == FSM_ShowHideImage.States.ENDREPEAT)
                        ChangeState(States.NORMAL);
                    }
                    else
                    {
                        lastState = currentState;
                        ChangeState(States.PAUSE);
                    }
                    break;
                case States.NORMAL:
                    if (!isPaused)
                    {
                        if (AlertBlackBoard.FSM_ShowHideImage.currentState == FSM_ShowHideImage.States.ENDREPEAT)
                            ChangeState(States.FAST);
                    }
                    else
                    {
                        lastState = currentState;
                        ChangeState(States.PAUSE);
                    }
                    break;
                case States.FAST:
                    if (!isPaused)
                    {
                        if (AlertBlackBoard.FSM_ShowHideImage.currentState == FSM_ShowHideImage.States.ENDREPEAT)
                            ChangeState(States.END);
                    }
                    else
                    {
                        lastState = currentState;
                        ChangeState(States.PAUSE);
                    }
                    break;
                case States.PAUSE:
                    if (!isPaused)
                        ChangeState(lastState);
                    break;
                case States.END:
                    break;
                default:
                    break;
            }
        }
        public void ChangeState(States newState)
        {
            switch (currentState)
            {
                case States.INITIAL:
                    break;
                case States.SLOW:
                    if (newState == States.NORMAL)
                        AlertBlackBoard.FSM_ShowHideImage.Exit();
                    break;
                case States.NORMAL:
                    
                    if (newState == States.FAST)
                        AlertBlackBoard.FSM_ShowHideImage.Exit();
                    break;
                case States.FAST:
                    if (newState == States.END)
                        AlertBlackBoard.FSM_ShowHideImage.Exit();
                    break;
                case States.PAUSE:
                    AlertBlackBoard.FSM_ShowHideImage.isPaused = false;
                    break;
                case States.END:
                    if(currentState==States.FAST)
                    AlertBlackBoard.FSM_ShowHideImage.Exit();
                    break;
                default:
                    break;
            }
            switch (newState)
            {
                case States.INITIAL:
                    break;
                case States.SLOW:
                    if (currentState == States.INITIAL)
                    {
                        AlertBlackBoard.FSM_ShowHideImage.ReEnter();
                        AlertBlackBoard.FSM_ShowHideImage.ISHBackBoard.SetTimers(AlertBlackBoard.timerShowSlow, AlertBlackBoard.timerHideSlow,
                                                                                       AlertBlackBoard.timeWaitShowSlow, AlertBlackBoard.numRepetitionsSlow);
                        AlertBlackBoard.FSM_ShowHideImage.SetStateInitial();
                    }
                    break;
                case States.NORMAL:
                    if (currentState == States.SLOW)
                    {
                        AlertBlackBoard.FSM_ShowHideImage.ReEnter();
                        AlertBlackBoard.FSM_ShowHideImage.ISHBackBoard.SetTimers(AlertBlackBoard.timerShowNormal, AlertBlackBoard.timerHideNormal,
                                                                                       AlertBlackBoard.timeWaitShowNormal, AlertBlackBoard.numRepetitionsNormal);
                        AlertBlackBoard.FSM_ShowHideImage.SetStateInitial();
                    }
                    break;
                case States.FAST:
                    if (currentState == States.NORMAL)
                    {
                        AlertBlackBoard.FSM_ShowHideImage.ReEnter();
                        AlertBlackBoard.FSM_ShowHideImage.ISHBackBoard.SetTimers(AlertBlackBoard.timerShowFast, AlertBlackBoard.timerHideFast,
                                                                                       AlertBlackBoard.timeWaitShowFast, AlertBlackBoard.numRepetitionsFast);
                        AlertBlackBoard.FSM_ShowHideImage.SetStateInitial();
                    }
                    break;
                case States.PAUSE:
                    AlertBlackBoard.FSM_ShowHideImage.isPaused = true;
                    break;
                case States.END:
                    break;
                default:
                    break;
            }
            currentState = newState;
        }
        //public void Update()
        //{
        //    SURTIR DEL VELL ESTAT
        //    switch (currentState)
        //    {
        //        case States.INITIAL:
        //            ChangeState(States.ALERT);
        //            break;
        //        case States.ALERT:
        //            if (!isPaused)
        //            {
        //                if (FSM_AlertStates.currentState == FSM_AlertStates.States.END)
        //                {
        //                    ChangeState(States.END);
        //                }
        //            }
        //            else
        //            {
        //                lastState = currentState;
        //                ChangeState(States.PAUSE);
        //            }
        //            break;
        //        case States.END:
        //            break;
        //        case States.PAUSE:
        //            if (!isPaused)
        //            {
        //                ChangeState(States.ALERT);
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}
        //ENTRAR L NO¡OU ESTAT
        //public void ChangeState(States newState)
        //{
        //    switch (currentState)
        //    {
        //        case States.INITIAL:
        //            break;
        //        case States.ALERT:
        //            if (newState == States.END)
        //                FSM_AlertStates.Exit();


        //            break;
        //        case States.PAUSE:
        //            FSM_AlertStates.isPaused = false;

        //            break;
        //        case States.END:

        //            break;
        //        default:
        //            break;
        //    }
        //    switch (newState)
        //    {
        //        case States.INITIAL:
        //            break;
        //        case States.ALERT:
        //            if (currentState == States.INITIAL)
        //                FSM_AlertStates.ReEnter();
        //            break;
        //        case States.END:
        //            break;
        //        case States.PAUSE:
        //            FSM_AlertStates.isPaused = true;
        //            break;

        //        default:

        //            break;
        //    }
        //    currentState = newState;
        //}

        internal void Reset()
        {
            AlertBlackBoard.FSM_ShowHideImage.Reset();
        }
    }
}