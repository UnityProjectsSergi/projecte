using UnityEngine;
using System.Collections;

namespace FSM
{
    public class FSM_Cooking : FiniteStateMachine
    {
        public enum States { INITIAL,COOKING,SHOWOKIMG,END}
      
        public CookingBlackbloard cookingBlackbloard;
        public States currentState;
     
        public override void Exit()
        {
            base.Exit();
        }
        public override void ReEnter()
        {
           
            base.ReEnter();
            currentState = States.INITIAL;
        }
        // Use this for initialization
        void Start()
        {
            cookingBlackbloard = GetComponent<CookingBlackbloard>();
            cookingBlackbloard.FSM_ShowHideImage.enabled = false;
           cookingBlackbloard.progressBar.enabled = false;

            //FSM_ShowHideImage.image = cookingBlackbloard.ImageCookingDone;
            //FSM_ShowHideImage.timeShowImage = cookingBlackbloard.TimeShowImageDone;
            //FSM_ShowHideImage.timeHideImage = cookingBlackbloard.timeHideImageDone;
            currentState = States.INITIAL;
        }

        // Update is called once per frame
        void Update()
        {
            switch (currentState)
            {
                case States.INITIAL:
                    ChangeState(States.COOKING);
                    break;
                case States.COOKING:
                    if (cookingBlackbloard.progressBar.currentState == FSM_ProgressBar.States.DONE)
                    {
                        ChangeState(States.SHOWOKIMG);
                    }
                    break;
                case States.SHOWOKIMG:
                    if (cookingBlackbloard.FSM_ShowHideImage.currentState == FSM_ShowHideImage.States.HIDE)
                    {
                        ChangeState(States.END);
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
                   cookingBlackbloard.progressBar.Exit();
                    break;
                case States.SHOWOKIMG:
                   cookingBlackbloard.FSM_ShowHideImage.Exit();
                    break;
                default:
                    break;
            }
            switch (newState)
            {
                case States.INITIAL:
                    break;
                case States.COOKING:
                   cookingBlackbloard.progressBar.ReEnter();
                    break;
                case States.SHOWOKIMG:
                   cookingBlackbloard.FSM_ShowHideImage.ReEnter();
                    break;
                default:
                    break;
            }
            currentState = newState;
        }
    }
}
