using UnityEngine;
using System.Collections;
namespace FSM
{
    public class FSM_ProgressBar : FiniteStateMachine
    {
        public enum States { INITIAL, PROGRESS, DONE }
        public States currentState;
        public ProgressBarBB ProgressBarBB;
        public float totalDuration;
        // Use this for initialization
        void Start()
        {
            ProgressBarBB.image.gameObject.SetActive(true);
            ProgressBarBB = GetComponent<ProgressBarBB>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateProgress();
            switch (currentState)
            {
                case States.INITIAL:
                    ProgressBarBB.image.gameObject.SetActive(true);
                    ChangeState(States.PROGRESS);
                    break;
                case States.PROGRESS:
                    if(ProgressBarBB.fillAmount>=0.99f)
                    {
                        ChangeState(States.DONE);
                    }
                    break;
                case States.DONE:

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
                case States.PROGRESS:
                    break;
                case States.DONE:
                    break;
                default:
                    break;
            }

            switch (newState)
            {
                case States.INITIAL:
                    break;
                case States.PROGRESS:
                    break;
                case States.DONE:
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
    }
}