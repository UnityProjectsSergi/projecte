using UnityEngine;
using System.Collections;
namespace FSM {
    public class FSM_Pot : FiniteStateMachine
    {
       
        public enum States { INITIAL, EMPTY,PAUSERUNNING, BURN }
        public States currentState;
        public ItemPotFSM itemPot;
        public GameObject CookingFSMGO;
        private FSM_Cooking FSM_Cooking;
        public PotBlackboard potBlackBoard;
        public CookingBlackbloard cookingBlackbloard;
        public States lastState;
        public FSM_Alert FSM_Alert;
        public AlertBlackBoard alertBlackBoard;
        public FSM_PauseStart FSM_PauseStart;

        // Use this for initialization
        void Start()
        { 
            itemPot = GetComponent<ItemPotFSM>();
            potBlackBoard = GetComponent<PotBlackboard>();
            FSM_PauseStart = gameObject.AddComponent<FSM_PauseStart>();
            FSM_PauseStart.enabled = false;
           
        }
        public override void Exit()
        {
            base.Exit();
        }
        public override void ReEnter()
        {
            base.ReEnter();
            currentState = States.INITIAL;
        }
        // Update is called once per frame
        void Update()
        {
           
                switch (currentState)
                {
                    
                    case States.INITIAL:
                        ChangeState(States.EMPTY);
                        break;
                    case States.EMPTY:
                        Debug.Log(itemPot.listItem.Count);
                        if (itemPot.listItem.Count > 0)
                            ChangeState(States.PAUSERUNNING);
                        break;
                    case States.PAUSERUNNING:
                    if (FSM_PauseStart.currentState == FSM.FSM_PauseStart.States.END)
                    {
                        ChangeState(States.BURN);
                    }

                        break;
                    case States.BURN:
                      
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
                case States.EMPTY:
                    break;
                case States.PAUSERUNNING:
                    FSM_PauseStart.Exit();
                    break;
           
                   
                    
                    
                default:
                    break;
            }

            switch (newState)
            {
                case States.INITIAL:
                    break;
                case States.EMPTY:
                    break;
                case States.PAUSERUNNING:
                    FSM_PauseStart.ReEnter();
                    break;
                default:
                    break;
            }
            currentState = newState;
        }
        public void UpdateProgress()
        {

            // ProgressBarBB.fillAmount=
        }
        public void Reset()
        {
            potBlackBoard.journey = 0;
        }
    }
}