﻿using UnityEngine;
using System.Collections;
using FSM;
using System;

namespace FSM
{
    public class FSM_ShowImage : FiniteStateMachine
    {
        public enum States { INITIAL, SHOW, RESET,WH, WAITTOSHOW }
        public States currentState;
        public States lastState;



        public PotBlackboard ISHBackBoard;
        public float speed = 1;
        public FSM_WaitToSomething FSM_WaitToSomething;
        // Use this for initialization
        //xo tin varies images diferents
        private void Awake()
        {

        }
        void Start()
        {



        }
        public override void ReEnter()
        {

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
        //void Update()
        //{
        //    UpdateProgress();
        //        switch (currentState)
        //        {
        //            case States.INITIAL:

        //                if (ISHBackBoard.ItemPotFSM.listItem.Count == ISHBackBoard.ItemPotFSM.potUi.listUIItems.Count)
        //                    if (ISHBackBoard.mustStay)
        //                        ChangeState(States.SHOW);
        //                    else 
        //                        ChangeState(States.WAITTOSHOW);

        //                break;
        //            case States.WAITTOSHOW:
        //                if (ISHBackBoard.mustStay)
        //                    ChangeState(States.SHOW);
        //                if (!isPaused)
        //                {

        //                    if (ISHBackBoard.timer > ISHBackBoard.timeWaitShowImage)
        //                    {
        //                        ChangeState(States.SHOW);
        //                        ISHBackBoard.timer = 0F;
        //                    }
        //                }
        //                else
        //                {
        //                    lastState = currentState;
        //                    ChangeState(States.PAUSE);
        //                }

        //                break;

        //            case States.SHOW:
        //                if (ResetFSMImage)
        //                {
        //                    ChangeState(States.RESET);

        //                }

        //                if (ISHBackBoard.mustStay)
        //                {
        //                    ChangeState(States.SHOW);
        //                }
        //                if (!isPaused)
        //                {
        //                    if (ISHBackBoard.timer > ISHBackBoard.timeShowImage)
        //                    {
        //                        ChangeState(States.HIDE);
        //                        ISHBackBoard.timer = 0;
        //                    }
        //                }
        //                else
        //                {
        //                    lastState = currentState;
        //                    ChangeState(States.PAUSE);
        //                }
        //                break;
        //            case States.HIDE:
        //                if (ResetFSMImage)
        //                    ChangeState(States.RESET);
        //                if (!isPaused)
        //                {
        //                    if (!ISHBackBoard.hasRepetition)
        //                        ChangeState(States.END);
        //                    else if (ISHBackBoard.hasRepetition && ISHBackBoard.count > ISHBackBoard.numRepetitions)
        //                    {
        //                        ChangeState(States.ENDREPEAT);
        //                    }
        //                    else if (ISHBackBoard.hasRepetition && ISHBackBoard.timer > ISHBackBoard.timeHideImage)
        //                    {
        //                        ISHBackBoard.count++;
        //                        ChangeState(States.SHOW);
        //                        ISHBackBoard.timer = 0;
        //                    }

        //                }
        //                else
        //                {
        //                    lastState = currentState;
        //                    ChangeState(States.PAUSE);
        //                }
        //                break;
        //            case States.ENDREPEAT:

        //                break;

        //            case States.PAUSE:
        //                if (ResetFSMImage)
        //                    ChangeState(States.RESET);
        //                if (!isPaused)
        //                    ChangeState(lastState);
        //                break;
        //            case States.RESET:

        //                ChangeState(States.INITIAL);
        //                break;
        //            case States.END:
        //                if (ResetFSMImage)
        //                    ChangeState(States.RESET);
        //                break;
        //            default:
        //                break;
        //        }

        //    }
        //    public void ChangeState(States newState)
        //    {
        //        switch (currentState)
        //        {
        //            case States.INITIAL:
        //                break;
        //            case States.SHOW:
        //                break;
        //            case States.PAUSE:

        //                ISHBackBoard.image.enabled = true;
        //                break;
        //            case States.HIDE:

        //                break;
        //            case States.RESET:
        //                ISHBackBoard.mustStay = false;
        //                ISHBackBoard.image.enabled = false;
        //                ISHBackBoard.timer = 0;
        //                ISHBackBoard.count = 0;
        //                ResetFSMImage = false;
        //                break;
        //            default:
        //                break;
        //        }

        //        switch (newState)
        //        {
        //            case States.INITIAL:
        //                //if(currentState==States.PAUSE)
        //                //    ISHBackBoard.image.enabled = false;
        //                break;
        //            case States.SHOW:
        //                ISHBackBoard.image.enabled = true;
        //                break;
        //            case States.WAITTOSHOW:
        //                ISHBackBoard.image.enabled = false;
        //                break;
        //            case States.HIDE:
        //                ISHBackBoard.image.enabled = false;
        //                break;
        //            case States.PAUSE:
        //                ISHBackBoard.image.enabled = false;
        //                break;
        //            case States.ENDREPEAT:
        //                currentState = States.INITIAL;
        //                break;
        //            case States.RESET:
        //                ISHBackBoard.mustStay = false;
        //                ISHBackBoard.image.enabled = false;
        //                break;
        //            case States.END:
        //                ISHBackBoard.count = 0;
        //                ISHBackBoard.timer = 0;

        //                break;
        //            default:
        //                break;
        //        }
        //        currentState = newState;
        //    }
        //    public void UpdateProgress()
        //    {
        //        if (!ISHBackBoard.mustStay)
        //        {
        //            if (!isPaused)
        //                if(currentState==States.SHOW || currentState==States.HIDE || currentState==States.WAITTOSHOW)
        //                ISHBackBoard.timer +=speed* Time.deltaTime;
        //        }
        //    }

        //    public bool ResetFSMImage;

        //}
    }
}