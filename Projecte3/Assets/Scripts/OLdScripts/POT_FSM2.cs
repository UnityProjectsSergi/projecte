using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POT_FSM2 : FSM.FiniteStateMachine
{
    public enum States {INITIAL, EMPTY,COOKING,ALERT,OK,BURN,PAUSE,RESET}
    public States currentState;
    public States lastState;
    public ItemPotFSM itemPotFSM;
    public bool resetFSM;
    public FSM.FSM_Cooking FSM_Cooking;
    public FSM.FSM_Alert FSM_Alert;
    public FSM.FSM_Burn FSM_Burn;
    public PotBlackboard potBlackBoard;

    // Start is called before the first frame update
    public override void ReEnter()
    {

        base.ReEnter(); 
    }
    void Start()
    {
       itemPotFSM = GetComponent<ItemPotFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case States.INITIAL:
                ChangeState(States.EMPTY);
                break;
            case States.EMPTY:
                if (itemPotFSM.listItem.Count == itemPotFSM.potUi.listUIItems.Count)
                    ChangeState(States.COOKING);
                break;
            case States.COOKING:
                if (resetFSM)
                    ChangeState(States.RESET);
                if (itemPotFSM.hasStoveUnder)
                {
                    potBlackBoard.journey += Time.deltaTime;
                    potBlackBoard.percent = Mathf.Clamp01(potBlackBoard.journey / itemPotFSM.totalDurationOfCooking);
                    if (potBlackBoard.percent >= 0.99f)
                    {
                        //ChangeState(States.OK);
                    }
                }
                else
                {
                    lastState = currentState;
                    ChangeState(States.PAUSE);
                }
                break;
            case States.OK:
                if (itemPotFSM.hasStoveUnder)
                {
                    

                       

                }
                else
                {
                    lastState = currentState;
                    ChangeState(States.PAUSE);
                }
                if (resetFSM)
                    ChangeState(States.RESET);
                
                break;
            case States.ALERT:
                if (itemPotFSM.hasStoveUnder)
                {
                  

                }
                else
                {
                    lastState = currentState;
                    ChangeState(States.PAUSE);
                }
                if (resetFSM)
                    ChangeState(States.RESET);
                break;
            case States.BURN:
                // show ImageBurn
                if (resetFSM)
                    ChangeState(States.RESET);
                break;
            case States.PAUSE:
                if (resetFSM)
                    ChangeState(States.INITIAL);
                if (itemPotFSM.hasStoveUnder)
                    ChangeState(lastState);
                break;
            case States.RESET:
                ChangeState(States.INITIAL);
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
            case States.EMPTY:
                break;
            case States.COOKING:
                potBlackBoard.imageProgBar.enabled = false;
                break;
            case States.OK:
                break;
            case States.ALERT:
                break;
            case States.BURN:
                break;
            case States.PAUSE:
                break;
            case States.RESET:
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
                potBlackBoard.imageProgBar.enabled = true;
                potBlackBoard.percent = 1.0f;
                potBlackBoard.journey = 0;
                break;
            case States.OK:
                break;
            case States.ALERT:
                potBlackBoard.imageOk.enabled = false;
                break;
            case States.BURN:

                break;
            case States.PAUSE:
                break;
            case States.RESET:
                potBlackBoard.journey = 0;
                potBlackBoard.percent = 1;
                potBlackBoard.imageOk.enabled = false;
                potBlackBoard.imageAlert.enabled = false;
                break;
            default:
                break;
        }
        currentState = newState;
    }
    
}
