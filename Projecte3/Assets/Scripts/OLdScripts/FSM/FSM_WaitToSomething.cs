
using UnityEngine;
using System.Collections;

public class FSM_WaitToSomething : MonoBehaviour
{

    public enum States { INITIAL, WAITING, END,RESET,PAUSE }
    public States currentState;
    public float Timer;
    public float TimeToWaitToDo;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case States.INITIAL:
                ChangeState(States.WAITING);
                break;
            case States.WAITING:
                Timer += Time.deltaTime;
                if (Timer >= TimeToWaitToDo)
                    ChangeState(States.END);
                break;
            case States.END:
                break;
            case States.RESET:
                break;
            case States.PAUSE:
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
            case States.WAITING:
                break;
            case States.END:
                break;
            case States.RESET:
                break;
            case States.PAUSE:
                break;
            default:
                break;
        }
        switch (newState)
        {
            case States.INITIAL:
                break;
            case States.WAITING:
                Timer = 0;
                break;
            case States.END:
                break;
            case States.RESET:
                break;
            case States.PAUSE:
                break;
            default:
                break;
               
        }
        currentState = newState;
    }
}
