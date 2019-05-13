using UnityEngine;
using System.Collections;
namespace FSM
{
    public class FSM_Pot : FiniteStateMachine
    {

        public enum States { INITIAL, EMPTY, PAUSERUNNING, BURN, RESETT }
        public States currentState;
        public ItemPotFSM itemPot;
        public GameObject CookingFSMGO;

        public PotBlackboard potBlackBoard;
        public CookingBlackbloard cookingBlackbloard;
        public States lastState;
        public FSM_Alert FSM_Alert;

        public FSM_PauseStart FSM_PauseStart;
        public bool resetFSM;

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
        public void Update()
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
                    if (resetFSM)
                    {
                        ChangeState(States.RESETT);
                    }


                    break;
                case States.BURN:
                    if (resetFSM)
                        ChangeState(States.RESETT);
                    break;
                case States.RESETT:
                    ChangeState(States.INITIAL);
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
                    if(newState!=States.RESETT )
                    FSM_PauseStart.Exit();
                    break;
                case States.BURN:
                    if(newState!=States.RESETT)
                    potBlackBoard.fSM_IMAGE.Exit();
                    break;
                case States.RESETT:
                    resetFSM = false;
                    FSM_PauseStart.ResetFSM = false;
                  //  currentState = States.INITIAL;
                    break;


                default:
                    break;
            }

            switch (newState)
            {
                case States.INITIAL:
                 //   FSM_PauseStart.ResetFSM = false;
                    //if (currentState == States.PAUSERUNNING)
                    //    FSM_PauseStart.ReEnter(); 
                    //if(currentState==States.BURN)
                    //    potBlackBoard.fSM_IMAGE.ReEnter();
                    break;
                case States.EMPTY:
                    break;
                case States.PAUSERUNNING:
                    FSM_PauseStart.ReEnter();
                    break;
                case States.BURN:

                    potBlackBoard.fSM_IMAGE.isPaused = false;
                    potBlackBoard.fSM_IMAGE.ReEnter();
                    potBlackBoard.fSM_IMAGE.ISHBackBoard.mustStay = true;
                    break;
                case States.RESETT:
                    if (FSM_PauseStart.enabled)
                    {
                        FSM_PauseStart.ResetFSM = true;
                        potBlackBoard.journey = 0;
                        itemPot.totalDurationOfCooking = 0;

                    }
                    if (potBlackBoard.fSM_IMAGE.enabled)
                    {
                        potBlackBoard.fSM_IMAGE.ResetFSMImage = true;
                        potBlackBoard.fSM_IMAGE.ISHBackBoard.count = 0;
                        potBlackBoard.fSM_IMAGE.ISHBackBoard.timer = 0;
                        potBlackBoard.fSM_IMAGE.ISHBackBoard.image.enabled = false;
                    }
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

            resetFSM = true;
           


        }
    }
}