using UnityEngine;
using System.Collections;
namespace FSM
{
    public class FSM_PauseStart : FiniteStateMachine
    {
        public enum States { INITIAL, RUNNING, PAUSE, END }
        public FSM_Pot fSM_pot;
        public States currentState;
        public ItemPotFSM itemPot;
        public FSM_PotInteral FSM_PotInteral;
        public PotBlackboard PotBlackboard;
        // Use this for initialization
        void Start()
        {
            itemPot = GetComponent<ItemPotFSM>();
            PotBlackboard = GetComponent<PotBlackboard>();
            FSM_PotInteral = gameObject.AddComponent<FSM_PotInteral>();
            FSM_PotInteral.enabled = false;
        }
        public override void Exit()
        {
            base.Exit();
        }
        public override void ReEnter()
        {
            currentState = States.INITIAL;
            base.ReEnter();
        }

        // Update is called once per frame
     public  override void  Update()
        {
           
            switch (currentState)
            {
                case States.INITIAL:
                    ChangeState(States.RUNNING);
                    break;
                case States.RUNNING:
                    if (!itemPot.hasStoveUnder)
                    {
                        ChangeState(States.PAUSE);
                    }
                    if(FSM_PotInteral.currentState==FSM_PotInteral.States.END)
                    {
                        ChangeState(States.END);
                    }
                    break;
                case States.PAUSE:
                    if(itemPot.hasStoveUnder)
                    {
                        ChangeState(States.RUNNING);
                    }
                    break;
                default:
                    break;
            }
            //jo tinc unprojecte q he fet al primer trimestre qe hi ha com una demo
        }
        public void ChangeState(States newState)
        {
            switch (currentState)
            {
                case States.INITIAL:
                    break;
                case States.RUNNING:
                 
                    break;
                case States.PAUSE:
                    FSM_PotInteral.isPaused = false;
                    break;
                case States.END:
                   // FSM_PotInteral.Exit();
                    break;
                default:
                    break;
            }
            switch (newState)
            {
                case States.INITIAL:
                    break;
                case States.RUNNING:
                    if(currentState==States.INITIAL)
                    FSM_PotInteral.ReEnter();
                    break;
                case States.PAUSE:
                    FSM_PotInteral.isPaused = true;
                    break;
                case States.END:
                    FSM_PotInteral.Exit();
                    break;
                default:
                    break;
            }
            currentState = newState;
        }
    }
}