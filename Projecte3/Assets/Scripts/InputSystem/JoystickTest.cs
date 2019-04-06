using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class JoystickTest : MonoBehaviour
{
   public string[] temp;
    // Use this for initialization
    void Awake()
    {
        string[] names = Input.GetJoystickNames();
        Debug.Log("Connected Joysticks:");
        for (int i = 0; i < names.Length; i++)
        {
            Debug.Log("Joystick" + (i + 1) + " = " + names[i]);

        }
        temp = Input.GetJoystickNames();
    }
    
 
 //Check whether array contains anything
 
 
    // Update is called once per frame, (if any joystick was connected during gameplay
    void Update()
    {
        Debug.Log(Input.GetJoystickNames().Length);
        temp = Input.GetJoystickNames();
        if (temp.Length > 0)
        {
            //Iterate over every element
            for (int i = 0; i < temp.Length; ++i)
            {
                //Check if the string is empty or not
                if (!string.IsNullOrEmpty(temp[i]))
                {
                    //Not empty, controller temp[i] is connected
                    Debug.Log("Controller " + (i+1) + " is connected using: " + temp[i]);

                }
                else
                {
                    //If it is empty, controller i is disconnected
                    //where i indicates the controller number
                    Debug.Log("Controller: " + (i+1) + " is disconnected.");

                }
            }
        }
    }
}
