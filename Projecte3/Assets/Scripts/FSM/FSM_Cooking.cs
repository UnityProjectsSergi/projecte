using UnityEngine;
using System.Collections;

namespace FSM
{
    public class FSM_Cooking : FiniteStateMachine
    {
        public enum States { INITIAL,COOKING,PAUSE,SHOWOKIMG,END}
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
            Debug.Log("load cook bb");
            
        }
        // Use this for initialization
        public void Start()
        {
            Debug.Log("load cook bb");
            cookingBlackbloard = GetComponent<CookingBlackbloard>();
            cookingBlackbloard.FSM_ShowHideImage.enabled = false;
            cookingBlackbloard.progressBar.enabled = false;

            cookingBlackbloard.FSM_ShowHideImage.image = cookingBlackbloard.ImageCookingDone;
            cookingBlackbloard.FSM_ShowHideImage.timeShowImage = cookingBlackbloard.TimeShowImageDone;
            cookingBlackbloard.FSM_ShowHideImage.timeHideImage = cookingBlackbloard.timeHideImageDone;
            currentState = States.INITIAL;
        }

        // Update is called once per frame
        public bool isPaused;
        void Update()
        {
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
                            ChangeState(States.SHOWOKIMG);
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
        public void SetPauseState(States isPaused)
        {
            currentState = States.PAUSE;
        }
        public void ChangeState(States newState)
        {
            switch (currentState)
            {
                case States.INITIAL:
                    break;
                case States.COOKING:
                   cookingBlackbloard.progressBar.Exit();
                    cookingBlackbloard.ProgBarGO.gameObject.SetActive(false);
                    break;
                case States.SHOWOKIMG:
                   cookingBlackbloard.FSM_ShowHideImage.Exit();
                    cookingBlackbloard.HideShowGO.gameObject.SetActive(false);
                    break;
                case States.PAUSE:
                    cookingBlackbloard.progressBar.isPaused = false;

                    break;
                default:
                    break;
            }
            switch (newState)
            {
                case States.INITIAL:
                    break;
                case States.COOKING:
                    cookingBlackbloard.ProgBarGO.gameObject.SetActive(true);
                   cookingBlackbloard.progressBar.ReEnter();
                    break;
                case States.PAUSE:
                    cookingBlackbloard.progressBar.isPaused = true;
                    break;
                case States.SHOWOKIMG:
                    cookingBlackbloard.HideShowGO.gameObject.SetActive(true);
                   cookingBlackbloard.FSM_ShowHideImage.ReEnter();
                    
                    break;
                default:
                    break;
            }
            currentState = newState;
        }
    }
}
