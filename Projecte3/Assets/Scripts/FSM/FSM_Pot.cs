using UnityEngine;
using System.Collections;
namespace FSM {
    public class FSM_Pot : FiniteStateMachine
    {
        public enum States { INITIAL, EMPTY, COOKING, ALERT, BURN }
        public States currentState;
        public ItemPotFSM itemPot;
        public GameObject CookingFSMGO;
        private FSM_Cooking FSM_Cooking;
        public PotBlackboard potBlackBoard;
        
            // Use this for initialization
            void Start()
        {
            potBlackBoard = GetComponent<PotBlackboard>();
            FSM_Cooking = CookingFSMGO.AddComponent<FSM_Cooking>();
            
            currentState = States.INITIAL;
    
            FSM_Cooking.enabled = false;

        }
        public override void Exit()
        {
            base.Exit();
        }
        public override void ReEnter()
        {
            base.ReEnter();
        }
        // Update is called once per frame
        void Update()
        {
            Debug.Log(itemPot);
            if (itemPot.hasStoveUnder) {
                potBlackBoard.journey += Time.deltaTime;
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
                         if (potBlackBoard.journey < itemPot.totalduration)
                        {
                            ChangeState(States.ALERT);
                        }
                        break;
                    case States.ALERT:
                        if (potBlackBoard.journey >= itemPot.totalduration + potBlackBoard.timeToAlert)
                            ChangeState(States.BURN);
                        else if (itemPot.currentSlotList != itemPot.oldSlot && potBlackBoard.journey < itemPot.totalduration + potBlackBoard.timeToAlert)
                            ChangeState(States.COOKING);

                        break;
                    case States.BURN:
                        break;
                    default:
                        break;
                }
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
                case States.COOKING:
                    FSM_Cooking.Exit();
                    
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
                case States.COOKING:
                    Debug.Log("ssss");
                   
                    FSM_Cooking.ReEnter();
                    FSM_Cooking.cookingBlackbloard.duration = itemPot.totalduration;
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