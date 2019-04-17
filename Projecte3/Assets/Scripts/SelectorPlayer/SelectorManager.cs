using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorManager : MonoBehaviour
{  
    public GameObject j1PressCricle;
    public GameObject j2PressCricle;
    public GameObject j1ConnectedText;
    public GameObject j2ConnectedText;
    public GameObject pressStartText;

    private bool j1Connected = false;
    private bool j2Connected = false;

    private bool isPressStart = false;

    private void Update()
    {
        if (!j1Connected)
        {
            if (Input.GetAxis("J1OButtonPS4") > 0)
            {
                j1Connected = true;
                j1PressCricle.SetActive(false);
                j1ConnectedText.SetActive(true);

                if (!isPressStart)
                    pressStartText.SetActive(true);

            }
        }

        if (!j2Connected)
        {
            if (Input.GetAxis("J2OButtonPS4") > 0)
            {
                j2Connected = true;
                j2PressCricle.SetActive(false);
                j2ConnectedText.SetActive(true);

                if (!isPressStart)
                    pressStartText.SetActive(true);
            }
        }
    }
}
