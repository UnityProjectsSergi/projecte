using UnityEngine;
using System.Collections;
using FSM;
using System;

namespace FSM
{
    public class FSM_ShowHideImage : FiniteStateMachine
    {
        public enum States { INITIAL, SHOW, PAUSE, HIDE, END }
        public States currentState;
        public States lastState;
        
       
      
        public ImageShowHideBlackboard ISHBackBoard;

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
            currentState = States.INITIAL;
            base.ReEnter();
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
                        else if (ISHBackBoard.hasRepetition && ISHBackBoard.timer > ISHBackBoard.timeHideImage)
                        {
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
                default:
                    break;
            }
            currentState = newState;
        }
        public void UpdateProgress()
        {
            if (!isPaused)
                ISHBackBoard.timer += Time.deltaTime;
        }

        internal void Reset()
        {
            currentState = States.INITIAL;
            ISHBackBoard.timer = 0;
        }
    }
    
}