using UnityEngine;
using System.Collections;
using FSM;
using System;

namespace FSM
{
    public class FSM_ShowHideImage : FiniteStateMachine
    {
        public enum States { INITIAL, SHOW, PAUSE, HIDE, END,ENDREPEAT }
        public States currentState;
        public States lastState;
        
       
      
        public ImageShowHideBlackboard ISHBackBoard;
        public float speed=1;

        // Use this for initialization
        //xo tin varies images diferents
        private void Awake()
        {
        
        }
        void Start()
        {
            ISHBackBoard = GetComponent<ImageShowHideBlackboard>();


        }
        public override void ReEnter()
        {
            ISHBackBoard = GetComponent<ImageShowHideBlackboard>();
            base.ReEnter();
        }
        public void SetStateInitial()
        {
            currentState = States.INITIAL;
        }
        public override void Exit()
        {
            base.Exit();
        }
        // Update is called once per frame
        void Update()
        {
            UpdateProgress();
            switch (currentState)
            {
                case States.INITIAL:
                    if (ISHBackBoard.mustStay)
                        ChangeState(States.SHOW);
                    if (!isPaused)
                    {
                        if (ISHBackBoard.timer > ISHBackBoard.timeWaitShowImage)
                        {
                            ChangeState(States.SHOW);
                            ISHBackBoard.timer = 0F;
                        }
                    }
                    else
                    {
                        lastState = currentState;
                        ChangeState(States.PAUSE);
                    }
                    break;
                case States.SHOW:
                    if (ISHBackBoard.mustStay)
                    {
                        ChangeState(States.SHOW);
                    }
                    if (!isPaused)
                    {
                        
                        if (ISHBackBoard.timer > ISHBackBoard.timeShowImage)
                        {
                            ChangeState(States.HIDE);
                            ISHBackBoard.timer = 0;
                        }
                        
                    }
                    else
                    {
                        lastState = currentState;
                        ChangeState(States.PAUSE);
                    }
                    break;
                case States.HIDE:
                    if (!isPaused)
                    {
                        if (!ISHBackBoard.hasRepetition)
                            ChangeState(States.END);
                        else if (ISHBackBoard.hasRepetition && ISHBackBoard.count > ISHBackBoard.numRepetitions)
                        {
                            ChangeState(States.ENDREPEAT);
                        }
                        else if (ISHBackBoard.hasRepetition && ISHBackBoard.timer > ISHBackBoard.timeHideImage)
                        {
                            ISHBackBoard.count++;
                            ChangeState(States.SHOW);
                            ISHBackBoard.timer = 0;
                        }
                       
                    }
                    else
                    {
                        lastState = currentState;
                        ChangeState(States.PAUSE);
                    }
                    break;
                case States.ENDREPEAT:
                   
                    break;

                case States.PAUSE:
                    if (!isPaused)
                        ChangeState(lastState);
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
                case States.SHOW:
                    break;
                case States.PAUSE:
                    ISHBackBoard.image.enabled = true;
                    break;
                case States.HIDE:

                    break;
                default:
                    break;
            }

            switch (newState)
            {
                case States.INITIAL:
                    if(currentState==States.PAUSE)
                        ISHBackBoard.image.enabled = false;
                    break;
                case States.SHOW:
                    ISHBackBoard.image.enabled = true;
                    break;
                case States.HIDE:
                    ISHBackBoard.image.enabled = false;
                    break;
                case States.PAUSE:
                    ISHBackBoard.image.enabled = false;
                    break;
                case States.ENDREPEAT:
                    currentState = States.INITIAL;
                    break;
                default:
                    break;
            }
            currentState = newState;
        }
        public void UpdateProgress()
        {
            if (!ISHBackBoard.mustStay)
            {
                if (!isPaused)
                    ISHBackBoard.timer +=speed* Time.deltaTime;
            }
        }

        internal void ResetFSM()
        {

          //  ChangeState(States.INITIAL);
           
            ISHBackBoard.timer = 0;
            ISHBackBoard.count = 0;
            Exit();
           
        }

    }
    
}