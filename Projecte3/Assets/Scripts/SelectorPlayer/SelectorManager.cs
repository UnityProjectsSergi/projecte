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
    public string nextScaneName;

    private GameManager gameManager;

    private bool j1Connected = false;
    private bool j2Connected = false;

    private bool isPressStart = false;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (!j1Connected)
        {
            if (Input.GetAxis("J1OButtonPS4") > 0)
            {
                j1Connected = true;
                j1PressCricle.SetActive(false);
                j1ConnectedText.SetActive(true);
                gameManager.j1 = true;

                if (!isPressStart)
                {
                    isPressStart = true;
                    pressStartText.SetActive(true);                  
                }

            }
        }

        if (!j2Connected)
        {
            if (Input.GetAxis("J2OButtonPS4") > 0)
            {
                j2Connected = true;
                j2PressCricle.SetActive(false);
                j2ConnectedText.SetActive(true);
                gameManager.j2 = true;

                if (!isPressStart)
                {
                    isPressStart = true;
                    pressStartText.SetActive(true);
                }
            }
        }

        if(isPressStart)
        {
            Debug.Log("Start");
            if(Input.GetAxis("J1SettingsButtonPS4") > 0 || Input.GetAxis("J2SettingsButtonPS4") > 0)
                gameManager.LoadScene(nextScaneName);
        }
    }
}
