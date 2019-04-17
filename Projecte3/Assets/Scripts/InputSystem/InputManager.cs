using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance = null;
    // Start is called before the first frame update
    public static InputManager Instance
    {
        get { return _instance; }
    } 

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
    }
    
    public bool GetButtonOnHold(string btn)
    {
        return Input.GetButton(btn);
    }
    public bool GetButtonDown(string btn)
    {
        return Input.GetButtonDown(btn);
    }
    public bool GetButtonUp(string btn)
    {
        return Input.GetButtonUp(btn);
    }
    public float GetAxis(string axis)
    {
        return Input.GetAxis(axis);
    }
    public bool GetKey(KeyCode code)
    {
        return Input.GetKey(code);
    }
    public bool GetKeyUp(KeyCode code)
    {
        return Input.GetKeyUp(code);
    }
    public bool GetKeyDown(KeyCode code)
    {
        return Input.GetKeyDown(code);
    }
    public float GetAxisRaw(string axisraw)
    {
        return Input.GetAxisRaw(axisraw);
    }

    

}
