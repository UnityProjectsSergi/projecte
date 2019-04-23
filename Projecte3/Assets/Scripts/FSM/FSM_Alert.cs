using UnityEngine;
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