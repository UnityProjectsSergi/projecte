using UnityEngine;
using System.Collections;
namespace FSM {
    public class FSM_PotInteral : FiniteStateMachine
    {
       
        public enum States { INITIAL, COOKING,COOKINGADDING, ALERT,PAUSE,END ,RESET}
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

        public bool resetFSM;

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
                    if(!isPaused)
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
                    if (resetFSM)
                    {
                        ChangeState(States.RESET);
                    }
                    if(!isPaused)
                    {
                        ChangeState(lastState);
                    }
                    break;
                case States.RESET:
                    resetFSM = false;
                    ChangeState(States.INITIAL);
                    break;
                case States.END:
                    if (resetFSM)
                        ChangeState(States.RESET);
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
                    //else
                    //    FSM_Cooking.isPaused = false;
                    break;
                case States.ALERT:
                    //if (newState == States.END)
                    //    FSM_Alert.Exit();
                    //else
                    //    FSM_Alert.isPaused = false;

                    break;

                case States.PAUSE:
                    if (newState != States.RESET)
                    {
                        FSM_Alert.isPaused = false;
                        FSM_Cooking.isPaused = false;
                    }
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
                    {
                        cookingBlackbloard.duration = itemPot.totalDurationOfCooking;
                        FSM_Cooking.isPaused = false;
                        FSM_Cooking.ReEnter();


                    }
                    break;
                case States.ALERT:
                    if (currentState == States.COOKING) {
                        //FSM_Alert.isPaused = false;
                        //FSM_Alert.ReEnter();
                    }
                    break;
                case States.PAUSE:

                    //FSM_Alert.isPaused = true;
                    FSM_Cooking.isPaused = true;
                    break;
                case States.END:

                    break;
                case States.RESET:
                    FSM_Cooking.ResetFSM = true;
                   /// FSM_Alert.ResetFSMAlert = true;
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
                potBlackBoard.journey += Time.deltaTime;
                if (FSM_Cooking.enabled && FSM_Cooking.cookingBlackbloard.progressBar.enabled)
                    if(FSM_Cooking.cookingBlackbloard.progressBar.currentState==FSM_ProgressBar.States.PROGRESS)
                        if(speedUpCook)
                         FSM_Cooking.cookingBlackbloard.progressBar.ProgressBarBB.percent = 2F* Mathf.Clamp01(potBlackBoard.journey / itemPot.totalDurationOfCooking);
                     else
                         FSM_Cooking.cookingBlackbloard.progressBar.ProgressBarBB.percent = 1F * Mathf.Clamp01(potBlackBoard.journey / itemPot.totalDurationOfCooking);
                if (FSM_Alert.enabled && FSM_Alert.AlertBlackBoard.FSM_ShowHideImage.enabled)
                    if (FSM_Alert.AlertBlackBoard.FSM_ShowHideImage.currentState == FSM_ShowHideImage.States.SHOW || FSM_Alert.AlertBlackBoard.FSM_ShowHideImage.currentState == FSM_ShowHideImage.States.HIDE)
                        if (speedUpCook)
                            FSM_Alert.AlertBlackBoard.FSM_ShowHideImage.speed = 2f;
                        else
                            FSM_Alert.AlertBlackBoard.FSM_ShowHideImage.speed = 1f;
                if (FSM_Cooking.enabled && FSM_Cooking.cookingBlackbloard.FSM_ShowHideImage.enabled)
                    if (FSM_Cooking.cookingBlackbloard.FSM_ShowHideImage.currentState == FSM_ShowHideImage.States.SHOW || FSM_Cooking.cookingBlackbloard.FSM_ShowHideImage.currentState == FSM_ShowHideImage.States.HIDE)
                        if (speedUpCook)
                            FSM_Cooking.cookingBlackbloard.FSM_ShowHideImage.speed = 2f;
                        else
                            FSM_Cooking.cookingBlackbloard.FSM_ShowHideImage.speed = 1f;


            }
        
        }
        public void ResetFSM()
        {
      // h
            //ChangeState(States.INITIAL);
            
           
        }
    }
}