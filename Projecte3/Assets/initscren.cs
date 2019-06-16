using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initscren : MonoBehaviour
{
    public UI_System system;
    public UI_Screen nextScreen;
    public SelectorManager selector;

    private bool move = false;
    public GameObject mainCamera;

    void Update()
    {
        if(InputManager.Instance.GetButtonDown("J1XButtonPS4") && !move)
        {
            system.SwitchScreen(nextScreen);
            selector.enabled = true;
            move = true;
        }

        if(move)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(-7, 14.4f, -42.5f), 20 * Time.deltaTime);

            if (mainCamera.transform.position == new Vector3(-7, 14.4f, -42.5f))
                move = false;
        }
    }
}
