using UnityEngine;
using System.Collections;
namespace FSM {
    public class FSM_PotInteral : FiniteStateMachine
    {
       
        public enum States { INITIAL, COOKING,COOKINGADDING, ALERT,PAUSE,END }
        public States currentState;
        public ItemPotFSM itemPot;
        public GameObject CookingFSMGO;
        private FSM_Cooking FSM_Cooking;
        public PotBlackboard potBlackBoard;
        public CookingBlackbloard cookingBlackbloard;
        public States lastState;
        public FSM_Alert FSM_Alert;
     
        public float lastJourney;
        
        // Use this for initialization
        void Start()
        { 
            itemPot = GetComponent<ItemPotFSM>();
            potBlackBoard = GetComponent<PotBlackboard>();
            cookingBlackbloard = GetComponent<CookingBlackbloard>();
           

            FSM_Cooking = gameObject.AddComponent<FSM_Cooking>();
            FSM_Alert = gameObject.AddComponent<FSM_Alert>();
            FSM_Alert.enabled = false;
            FSM_Cooking.enabled = false;
        }
        public bool Enter = false;
        public bool speedUpCook;

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
            UpdateProgress();
            cookingBlackbloard.duration = itemPot.totalDurationOfCooking;
            switch (currentState)
            {

                case States.INITIAL:
                    ChangeState(States.COOKING);
                    break;
               
                case States.COOKING:
                    if (!isPaused)
                    {
                        
                        if (FSM_Cooking.currentState == FSM_Cooking.States.END)
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
                        if (FSM_Alert.currentState==FSM_Alert.States.END)

                            ChangeState(States.END);

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
                    if (newState == States.ALERT)
                        FSM_Cooking.Exit();
                    else
                        FSM_Cooking.isPaused = false;
                    break;
                case States.ALERT:
                    if (newState == States.END)
                        FSM_Alert.Exit();
                    else
                        FSM_Alert.isPaused = false;

                    break;

                case States.PAUSE:
            
                    FSM_Alert.isPaused = false;
                    FSM_Cooking.isPaused = false;
                    break;


                default:
                    break;
            }

            switch (newState)
            {
                case States.INITIAL:
                   if(currentState==States.PAUSE)
                    {
                       // FSM_Cooking.Reset();
                        //FSM_Alert.Reset();
                    }
                    break;
               
                case States.COOKING:
                    if (currentState==States.INITIAL || currentState==States.ALERT)
                    {
                        cookingBlackbloard.duration = itemPot.totalDurationOfCooking;
                      FSM_Cooking.ReEnter();
                    }
                    break;
                case States.ALERT:
                    if (currentState == States.COOKING) { 
                        FSM_Alert.ReEnter();
                    }
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
            if (!isPaused)
            { 
                if(FSM_Cooking.enabled && FSM_Cooking.cookingBlackbloard.progressBar.enabled)
                if(FSM_Cooking.cookingBlackbloard.progressBar.currentState==FSM_ProgressBar.States.PROGRESS)
                     FSM_Cooking.cookingBlackbloard.progressBar.ProgressBarBB.percent = 1* Mathf.Clamp01(potBlackBoard.journey / itemPot.totalDurationOfCooking);
              
                if(speedUpCook)
                    potBlackBoard.journey += Time.deltaTime*2f;
                else
                    potBlackBoard.journey += Time.deltaTime;
            }
            // ProgressBarBB.fillAmount=
        }
        public void ResetFSM()
        {
            if(FSM_Alert)
            FSM_Alert.ResetFSM();
            if(FSM_Cooking)
            FSM_Cooking.ResetFSM();
            Exit();

            //ChangeState(States.INITIAL);
            
           
        }
    }
}