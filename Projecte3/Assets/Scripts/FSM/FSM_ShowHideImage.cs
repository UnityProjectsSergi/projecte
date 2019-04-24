using UnityEngine;
using System.Collections;
using FSM;
using UnityEngine.UI;
namespace FSM
{
    public class FSM_ShowHideImage : FiniteStateMachine
    {
        public enum States { INITIAL, SHOW, HIDE,END }
        public States currentState;
        public float timeShowImage, timeHideImage;
        public float timer;
        public Image image;
        public float timeWaitShowImage;
        // Use this for initialization
        //xo tin varies images diferents 
        void Start()
        {
            currentState = States.INITIAL;
        }
        public override void ReEnter()
        {
            currentState = States.INITIAL;
            base.ReEnter();
        }
        public override void Exit()
        {
            base.Exit();
        }
        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            switch (currentState)
            {
                case States.INITIAL:
                    if (timer > timeWaitShowImage)
                    {
                        ChangeState(States.SHOW);
                        timer = 0F;
                    }
                    break;
                case States.SHOW:
                    if (timer > timeShowImage)
                    {
                        ChangeState(States.HIDE);
                        timer = 0;
                    }
                    break;
                case States.HIDE:
                    if (timeHideImage == 0.0f)
                        ChangeState(States.END);
                    else if (timer > timeHideImage)
                    {
                        ChangeState(States.SHOW);
                        timer = 0;
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
                case States.SHOW:
                    break;
                case States.HIDE:
                    break;
                default:
                    break;
            }

            switch (newState)
            {
                case States.INITIAL:
                    break;
                case States.SHOW:
                    image.enabled=true;
                    break;
                case States.HIDE:
                    image.enabled=false;
                    break;
                default:
                    break;
            }
            currentState = newState;
        }
    }
}