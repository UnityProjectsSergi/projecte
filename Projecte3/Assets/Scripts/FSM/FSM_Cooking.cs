using UnityEngine;
using System.Collections;
using System;

namespace FSM
{
    public class FSM_Cooking : FiniteStateMachine
    {
        public enum States { INITIAL,COOKING,PAUSE,DONEOK,END}
        [HideInInspector]
        public CookingBlackbloard cookingBlackbloard;
        public States currentState;
        public States lastState;
        
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

        private void Update()
        {
           // cookingBlackbloard.progressBar.isPaused = isPaused;
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
                            ChangeState(States.DONEOK);
                        }
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
                case States.DONEOK:
                    if(!isPaused)
                    {

                        if (cookingBlackbloard.FSM_ShowHideImage.currentState==FSM_ShowHideImage.States.END)
                        {
                                ChangeState(States.END);
                        }
                    }
                    else
                    {
                        lastState = currentState;
                        ChangeState(States.PAUSE);
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
                    if (newState == States.DONEOK)
                        cookingBlackbloard.progressBar.Exit();
                    break;
                case States.END:
             
                    break;
                case States.DONEOK:
                    if (newState == States.END)
                        cookingBlackbloard.FSM_ShowHideImage.Exit();
                    break;
                case States.PAUSE:
                    cookingBlackbloard.FSM_ShowHideImage.isPaused = false;
                    cookingBlackbloard.progressBar.isPaused = false;
                    break;
                    
                
                default:
                    break;
            }
            // es noe esttatb 
            switch (newState)
            {
                case States.INITIAL:
                    if (currentState == States.INITIAL)
                    {
                      //  if(cookingBlackbloard.progressBar.enabled)
                       // cookingBlackbloard.progressBar.Reset();
                   ///     if(cookingBlackbloard.FSM_ShowHideImage.enabled)
                     //  cookingBlackbloard.FSM_ShowHideImage.Reset();
                    }

                    break;
                case States.COOKING:
                    if (currentState == States.INITIAL) 
                   cookingBlackbloard.progressBar.ReEnter();
                    break;

                case States.PAUSE:
                    cookingBlackbloard.FSM_ShowHideImage.isPaused = true;
                    cookingBlackbloard.progressBar.isPaused = true;
                    break;
                case States.DONEOK:
                    if (currentState == States.COOKING)

                        cookingBlackbloard.FSM_ShowHideImage.ReEnter();


                    break;
                default:
                    break;
            }
            currentState = newState;
        }

        internal void ResetFSM()
        {
            cookingBlackbloard.progressBar.ResetFSM();
            cookingBlackbloard.FSM_ShowHideImage.ResetFSM();
            Exit();
            
            
        }
    }
}
