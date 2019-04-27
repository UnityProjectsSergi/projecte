using UnityEngine;
using System.Collections;
namespace FSM {
    public class FSM_Pot : FiniteStateMachine
    {
        public enum States { INITIAL, EMPTY,PAUSE, COOKING, ALERT, BURN }
        public States currentState;
        public ItemPotFSM itemPot;
        public GameObject CookingFSMGO;
        private FSM_Cooking FSM_Cooking;
        public PotBlackboard potBlackBoard;
        public CookingBlackbloard cookingBlackbloard;
        public States lastState;
        
            // Use this for initialization
            void Start()
        {

            itemPot = GetComponent<ItemPotFSM>();
            potBlackBoard = GetComponent<PotBlackboard>();
            cookingBlackbloard = GetComponent<CookingBlackbloard>();
            FSM_Cooking = gameObject.AddComponent<FSM_Cooking>();
            FSM_Cooking.enabled = false;
        

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
            Debug.Log(itemPot);
          
                
                switch (currentState)
                {
                    case States.INITIAL:
                        ChangeState(States.EMPTY);
                        break;
                    case States.EMPTY:
                        Debug.Log(itemPot.listItem.Count);
                        if (itemPot.listItem.Count > 0)
                            ChangeState(States.COOKING);
                        break;
                    case States.COOKING:
                        if (itemPot.hasStoveUnder)
                        {
                            potBlackBoard.journey += Time.deltaTime;
                            if (potBlackBoard.journey > itemPot.totalduration)
                            {
                                ChangeState(States.ALERT);
                            }
                        }
                        else
                        {
                             lastState = currentState;
                            ChangeState(States.PAUSE);
                        }
                        break;
                    case States.ALERT:
                        if (itemPot.hasStoveUnder)
                        {
                            potBlackBoard.journey += Time.deltaTime;
                            if (potBlackBoard.journey >= itemPot.totalduration + potBlackBoard.timeToAlert)
                                ChangeState(States.BURN);
                            else if (itemPot.currentSlotList != itemPot.oldSlot && potBlackBoard.journey < itemPot.totalduration + potBlackBoard.timeToAlert)
                                ChangeState(States.COOKING);
                        }
                        else
                        {
                            lastState = currentState;
                            ChangeState(States.PAUSE);
                        }
                        break;
                case States.PAUSE:
                    if(itemPot.hasStoveUnder)
                    {
                        ChangeState(lastState);
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
                case States.PAUSE:
                    FSM_Cooking.isPaused = false;
                    break;
                
                case States.COOKING:
                    if(itemPot.hasStoveUnder)
                    {
                        FSM_Cooking.Exit();
                    }
                                     
                    
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
                case States.PAUSE:
                    FSM_Cooking.isPaused = true;
                    break;
                case States.COOKING:
                    Debug.Log("ssss");
                    cookingBlackbloard.duration = itemPot.totalduration;
                    FSM_Cooking.ReEnter();
                    
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