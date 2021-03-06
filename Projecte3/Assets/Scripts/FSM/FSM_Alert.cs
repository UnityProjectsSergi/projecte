﻿using UnityEngine;
using System.Collections;
namespace FSM
{
    public class FSM_Alert : FiniteStateMachine
    {
        public enum States { INITIAL, ALERT, END }
        public States currentState;
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
        public void Awake()
        {
            AlertBlackBoard = GetComponent<AlertBlackBoard>();
            AlertBlackBoard.FSM_ShowHideImage.enabled = false;
            AlertBlackBoard.FSM_ShowHideImage.image = AlertBlackBoard.ImageCookingAlert;
            AlertBlackBoard.FSM_ShowHideImage.timeHideImage = 0.0f;
            AlertBlackBoard.FSM_ShowHideImage.timeShowImage = AlertBlackBoard.TimeShowImageDone;
            AlertBlackBoard.FSM_ShowHideImage.timeWaitShowImage = AlertBlackBoard.timeWaitShowImageDone;
        }
        private void OnEnable()
        {
            AlertBlackBoard = GetComponent<AlertBlackBoard>();
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            switch (currentState)
            {
                case States.INITIAL:
                    ChangeState(States.ALERT);
                    break;
                case States.ALERT:
                    if (AlertBlackBoard.FSM_ShowHideImage.currentState == FSM_ShowHideImage.States.HIDE)
                    {
                        ChangeState(States.END);
                    }
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
                case States.ALERT:
                    AlertBlackBoard.FSM_ShowHideImage.Exit();
                    AlertBlackBoard.HideShowGO.SetActive(false);
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
                    AlertBlackBoard.HideShowGO.gameObject.SetActive(true);
                    AlertBlackBoard.FSM_ShowHideImage.ReEnter();
                    break;
                case States.END:
                    break;
                default:
                    break;
            }
            currentState = newState;
        }
    }
}