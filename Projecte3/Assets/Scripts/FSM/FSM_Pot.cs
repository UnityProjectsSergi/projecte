using UnityEngine;
using System.Collections;
namespace FSM {
    public class FSM_Pot : FiniteStateMachine
    {
       
        public enum States { INITIAL, EMPTY,PAUSERUNNING, BURN }
        public States currentState;
        public ItemPotFSM itemPot;
        public GameObject CookingFSMGO;
    
        public PotBlackboard potBlackBoard;
        public CookingBlackbloard cookingBlackbloard;
        public States lastState;
        public FSM_Alert FSM_Alert;
        
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
        public  void Update()
        {
            //si currentState IS
                switch (currentState)
                {
                    //initial
                    case States.INITIAL:
                           //Chage Current State To Empty State
                        ChangeState(States.EMPTY);
                        break;
                    //Empty
                    case States.EMPTY:
                        // Si list item Of Pot has 1 o + elements
                        if (itemPot.listItem.Count == itemPot.potUi.listUIItems.Count)
                            // Changestate to Cooking FSMInteral
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
                   
                    break;
                case States.BURN:

                    break;
                   
                    
                    
                default:
                    break;
            }

            switch (newState)
            {
                case States.INITIAL:
                    if(currentState==States.PAUSERUNNING)
                                         
                            FSM_PauseStart.ReEnter();
                            
                  
                     
                    if(currentState==States.BURN)
                        potBlackBoard.fSM_IMAGE.ReEnter();
                    break;
                case States.EMPTY:
                    break;
                case States.PAUSERUNNING:
                    FSM_PauseStart.ReEnter();
                    break;
                case States.BURN:
                    potBlackBoard.fSM_IMAGE.ReEnter();
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
        public void ResetF()
        {
            potBlackBoard.journey = 0;
            if(FSM_Alert)
            FSM_Alert.ResetFSM();
            if(FSM_PauseStart)
            FSM_PauseStart.ResetFSM();
            currentState = States.INITIAL;
           
            
        }
    }
}