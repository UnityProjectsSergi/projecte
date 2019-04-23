using UnityEngine;
using System.Collections;
namespace FSM {
    public class FSM_Pot : FiniteStateMachine
    {
        public enum States { INITIAL, EMPTY, COOKING, ALERT, BURN }
        public States currentState;
        public ItemPot itemPot;
        public GameObject CookingFSMGO;
        private FSM_Cooking FSM_Cooking;
            // Use this for initialization
            void Start()
        {
            FSM_Cooking = CookingFSMGO.AddComponent<FSM_Cooking>();
          //  currentState = States.INITIAL;
    
            FSM_Cooking.enabled = false;

        }
        public override void Exit()
        {
            base.Exit();
        }
        public override void ReEnter()
        {
            base.ReEnter();
        }
        // Update is called once per frame
        void Update()
        {
            if (itemPot.hasStoveUnder) {
                //UpdateProgress();
                switch (currentState)
                {
                    case States.INITIAL:
                        ChangeState(States.EMPTY);
                        break;
                    case States.EMPTY:
                        Debug.Log(itemPot.listItem.Count);
                        //if (itemPot.listItem.Count >0)
                        //    ChangeState(States.COOKING);
                        break;
                    case States.COOKING:
                        // if joureny< totalduration q
                        //Change State Alerrt
                        // Amb m
                        // estat progres iestat de surtt ok 
                        break;
                    case States.ALERT:

                        // si  (joreny >= temps limit alert + totalduratione)
                        //changeState brun
                        //els if(numActual != numCountVell && jornoet< timealert+totalduration) 
                        //statechange(cookig)

                        break;
                    case States.BURN:
                        break;
                    default:
                        break;
                }
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
                case States.COOKING:
                    FSM_Cooking.Exit();
                    
                    break;
                default:
                    break;
            }

            switch (newState)
            {
                case States.INITIAL:
                    break;
                case States.EMPTY:
                    break;
                case States.COOKING:
                    Debug.Log("ssss");
                    FSM_Cooking.ReEnter();
        
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