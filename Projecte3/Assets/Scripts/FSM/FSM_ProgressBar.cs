using UnityEngine;
using System.Collections;
using System;

namespace FSM
{
    public class FSM_ProgressBar : FiniteStateMachine
    {
        public enum States { INITIAL, PROGRESS,PAUSE, DONE }
        public States currentState;
        public States lastState;
        public ProgressBarBlackboard ProgressBarBB;
        public float totalDuration;
        // Use this for initialization
        void Awake()
        {
           
            ProgressBarBB = GetComponent<ProgressBarBlackboard>();
            ProgressBarBB.image.enabled = false;
        }

        public override void ReEnter()
        {
            
            ProgressBarBB.image.enabled=true;
            currentState = States.INITIAL;
          
            base.ReEnter();
        }
        public override void Exit()
        {
            ProgressBarBB.image.enabled=false;
            base.Exit();
        }
        public bool isPausedProgressBar;
        // Update is called once per frame
        void Update()
        {
            UpdateProgress();
            switch (currentState)
            {
                case States.INITIAL:
                    ChangeState(States.PROGRESS);
                    break;
                case States.PROGRESS:

                    if(!isPaused)
                    {
                        // ProgressBarBB.itemPot.totalduration
                        
                       // ProgressBarBB.percent += 0.1f * Time.deltaTime;
                        if (ProgressBarBB.percent >= 0.99f)
                        {
                            ChangeState(States.DONE);
                        }
                    }
                    else
                    {
                        ChangeState(States.PAUSE);
                    }
                    break;
                case States.PAUSE:
                    if (!isPaused)
                        ChangeState(States.PROGRESS);
                    break;
                case States.DONE:
                    ProgressBarBB.percent = 0;
                    break;
                default:
                    break;
            }
        }
        // puc rer
        public void ChangeState(States newState)
        {
            switch (currentState)
            {
                case States.INITIAL:
                    break;
                case States.PROGRESS:
                    break;
                case States.DONE:
                    break;
                case States.PAUSE:
                    ProgressBarBB.image.enabled = true;
                    break;
                 
                default:
                    break;
            }

            switch (newState)
            {
                case States.INITIAL:
                    break;
                case States.PROGRESS:
                    break;
                case States.DONE:
                    break;
                case States.PAUSE:
                    ProgressBarBB.image.enabled = false;
                    break;
                default:
                    break;
            }
            currentState = newState;
        }
        public void UpdateProgress()
        { 
            
        }

        internal void Reset()
        {
            ProgressBarBB.percent = 0;
            currentState = States.INITIAL;
        }
    }
}