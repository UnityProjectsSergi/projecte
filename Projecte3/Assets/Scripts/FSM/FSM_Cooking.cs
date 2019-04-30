using UnityEngine;
using System.Collections;

namespace FSM
{
    public class FSM_Cooking : FiniteStateMachine
    {
        public enum States { INITIAL,COOKING,PAUSE,END}
        [HideInInspector]
        public CookingBlackbloard cookingBlackbloard;
        public States currentState;
        
        public override void Exit()
        {
            base.Exit();
        }
        public override void ReEnter()
        {
            currentState = States.INITIAL;
            base.ReEnter();
            
        }
        public void OnEnable()
        {
          
        }
        // Use this for initialization
        public void Start()
        {
            cookingBlackbloard = GetComponent<CookingBlackbloard>();
         //   cookingBlackbloard.FSM_ShowHideImage.enabled = false;
            cookingBlackbloard.progressBar.enabled = false;

            //cookingBlackbloard.FSM_ShowHideImage.image = cookingBlackbloard.ImageCookingDone;
            //cookingBlackbloard.FSM_ShowHideImage.timeShowImage = cookingBlackbloard.TimeShowImageDone;
            //cookingBlackbloard.FSM_ShowHideImage.timeHideImage = cookingBlackbloard.timeHideImageDone;
            //currentState = States.INITIAL;
        }

        // Update is called once per frame
        public bool isPausedCooking;
        void Update()
        {
            cookingBlackbloard.progressBar.isPaused = isPaused;
            cookingBlackbloard.progressBar.totalDuration = cookingBlackbloard.duration;
           
            switch (currentState)
            {
                case States.INITIAL:
                    ChangeState(States.COOKING);
                    break;
                case States.COOKING:
                    if (!isPaused)
                    {
                        if (cookingBlackbloard.progressBar.currentState == FSM_ProgressBar.States.DONE)
                        {
                            ChangeState(States.END);
                        }
                    }
                    else
                        ChangeState(States.PAUSE);
                    break;
                case States.PAUSE:
                    if(!isPaused)
                    {
                        ChangeState(States.COOKING);
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

                    break;
                case States.END:
             
                    break;
              
                    
                
                default:
                    break;
            }
            // es noe esttatb 
            switch (newState)
            {
                case States.INITIAL:
                    break;
                case States.COOKING:
                    if (currentState == States.INITIAL) 
                   cookingBlackbloard.progressBar.ReEnter();
                    break;
                

                case States.END:
                    cookingBlackbloard.progressBar.Exit();
                

                    break;
                default:
                    break;
            }
            currentState = newState;
        }
    }
}
