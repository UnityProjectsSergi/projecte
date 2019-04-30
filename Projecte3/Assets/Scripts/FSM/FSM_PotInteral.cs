using UnityEngine;
using System.Collections;
namespace FSM {
    public class FSM_PotInteral : FiniteStateMachine
    {
       
        public enum States { INITIAL, COOKING, ALERT,PAUSE,END }
        public States currentState;
        public ItemPotFSM itemPot;
        public GameObject CookingFSMGO;
        private FSM_Cooking FSM_Cooking;
        public PotBlackboard potBlackBoard;
        public CookingBlackbloard cookingBlackbloard;
        public States lastState;
        public FSM_Alert FSM_Alert;
        public AlertBlackBoard alertBlackBoard;
        public float lastJourney;
        
        // Use this for initialization
        void Start()
        { 
            itemPot = GetComponent<ItemPotFSM>();
            potBlackBoard = GetComponent<PotBlackboard>();
            cookingBlackbloard = GetComponent<CookingBlackbloard>();
            alertBlackBoard = GetComponent<AlertBlackBoard>();

            FSM_Cooking = gameObject.AddComponent<FSM_Cooking>();
            FSM_Alert = gameObject.AddComponent<FSM_Alert>();
            FSM_Alert.enabled = false;
            FSM_Cooking.enabled = false;
        }
        public bool Enter = false;
        public override void Exit()
        {
            //if (currentState != States.END)
            //{
            //    isPaused = true;
            //    lastJourney = potBlackBoard.journey;
            //}
            //else
                base.Exit();
        }
        public override void ReEnter()
        {
            Debug.Log("enterpotinerna");
            //if (isPaused)
            //{
            //    Debug.Log("ssss");
                base.ReEnter();
            //    Enter = true;
               currentState = States.INITIAL;
            //}
            //else
            //{
            //    Debug.Log("wwwwwww");
            //    potBlackBoard.journey = lastJourney;
            //    isPaused = false;
               
            //}
        }
        public void SetPaused(bool pasuse)
        {
            isPaused = pasuse;
        }
       // Update is called once per frame
        void Update()
        {
      
            cookingBlackbloard.duration = itemPot.totalduration;
            switch (currentState)
            {

                case States.INITIAL:
                    ChangeState(States.COOKING);
                    break;
               
                case States.COOKING:
                    if (!isPaused)
                    {
                        potBlackBoard.journey += Time.deltaTime;
                        //if (FSM_Cooking.currentState == FSM_Cooking.States.END)
                        //    ChangeState(States.ALERT);
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
                    if (!isPaused)
                    {
                        potBlackBoard.journey += Time.deltaTime;
                        if (potBlackBoard.journey >= itemPot.totalduration + potBlackBoard.timeToAlert)
                            ChangeState(States.END);
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
                    if(!isPaused)
                    {
                        Debug.Log("exir pase"+currentState+" " +lastState);
                        ChangeState(lastState);
                    }
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
              
                 

                case States.COOKING:
                    //if (newState == States.ALERT)
                    //    FSM_Cooking.Exit();
                    //else
                    //    FSM_Cooking.isPaused = false;
                    //break;
                case States.ALERT:

                    ///     FSM_Alert.Exit();
                    break;
                case States.PAUSE:
                    Debug.Log("Exit Pause state"+currentState);
                    FSM_Alert.isPaused = false;
                    FSM_Cooking.isPaused = false;
                    break;


                default:
                    break;
            }

            switch (newState)
            {
                case States.INITIAL:
                    break;
               
                case States.COOKING:
                    if (currentState==States.INITIAL)
                    //{
                    //    cookingBlackbloard.duration = itemPot.totalduration;
                      FSM_Cooking.ReEnter();
                    //}
                    break;
                case States.ALERT:
                    //if (!isPaused){
                    //    FSM_Alert.ReEnter();
                    //}
                    break;
                case States.PAUSE:

                    FSM_Alert.isPaused = true;
                    FSM_Cooking.isPaused = true;
                    break;
                case States.END:

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