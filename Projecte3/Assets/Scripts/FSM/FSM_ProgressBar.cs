using UnityEngine;
using System.Collections;
namespace FSM
{
    public class FSM_ProgressBar : FiniteStateMachine
    {
        public enum States { INITIAL, PROGRESS, DONE }
        public States currentState;
        public ProgressBarBlackboard ProgressBarBB;
        public float totalDuration;
        // Use this for initialization
        void Start()
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
                    ProgressBarBB.percent += Time.deltaTime;
                    if (ProgressBarBB.percent>=0.99f)
                    {
                        ChangeState(States.DONE);
                    }
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
                default:
                    break;
            }
            currentState = newState;
        }
        public void UpdateProgress()
        { 
            
        }
    }
}