using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorManager : MonoBehaviour
{  
    public GameObject j1PressCricle;
    public GameObject j2PressCricle;
    public GameObject j3PressCricle;
    public GameObject j4PressCricle;

    public GameObject[] j1Character = new GameObject[4];
    public GameObject[] j2Character = new GameObject[4];
    public GameObject[] j3Character = new GameObject[4];
    public GameObject[] j4Character = new GameObject[4];

    private bool j1Connected = false;
    private bool j2Connected = false;
    private bool j3Connected = false;
    private bool j4Connected = false;

    private int j1PlayerNum = 0;
    private int j2PlayerNum = 1;
    private int j3PlayerNum = 2;
    private int j4PlayerNum = 3;

    public GameObject pressStartText;
    public string nextScaneName;
    public List<Image> ListPlayers;
    private GameManager gameManager;

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
                j1Character[j1PlayerNum].SetActive(true);
                gameManager.j1 = true;
                gameManager.j1c = j1PlayerNum;

                if (!isPressStart)
                {
                    isPressStart = true;
                    pressStartText.SetActive(true);                  
                }

            }
        } else
        {
            if(InputManager.Instance.GetAxisRaw("J1LeftStickHorizontalPS4") > 0)
            {
                j1Character[j1PlayerNum].SetActive(false);

                j1PlayerNum++;
                if(j1PlayerNum > 3)
                    j1PlayerNum = 0;

                j1Character[j1PlayerNum].SetActive(true);
                gameManager.j1c = j1PlayerNum;
            }
        }

        if (!j2Connected)
        {
            if (Input.GetAxis("J2OButtonPS4") > 0)
            {
                j2Connected = true;
                j2PressCricle.SetActive(false);
                j2Character[j2PlayerNum].SetActive(true);
                gameManager.j2 = true;
                gameManager.j2c = j2PlayerNum;

                if (!isPressStart)
                {
                    isPressStart = true;
                    pressStartText.SetActive(true);
                }
            }
        }
        else
        {
            if (InputManager.Instance.GetAxisRaw("J2LeftStickHorizontalPS4") > 0)
            {
                j2Character[j2PlayerNum].SetActive(false);

                j2PlayerNum++;
                if (j2PlayerNum > 3)
                    j2PlayerNum = 0;

                j2Character[j2PlayerNum].SetActive(true);
                gameManager.j2c = j2PlayerNum;
            }
        }

        if (!j3Connected)
        {
            if (Input.GetAxis("J3OButtonPS4") > 0)
            {
                j3Connected = true;
                j3PressCricle.SetActive(false);
                j3Character[j3PlayerNum].SetActive(true);
                gameManager.j3 = true;
                gameManager.j3c = j3PlayerNum;

                if (!isPressStart)
                {
                    isPressStart = true;
                    pressStartText.SetActive(true);
                }
            }
        }
        else
        {
            if (InputManager.Instance.GetAxisRaw("J3LeftStickHorizontalPS4") > 0)
            {
                j3Character[j3PlayerNum].SetActive(false);

                j3PlayerNum++;
                if (j3PlayerNum > 3)
                    j3PlayerNum = 0;

                j3Character[j3PlayerNum].SetActive(true);
                gameManager.j3c = j3PlayerNum;
            }
        }

        if (!j4Connected)
        {
            if (Input.GetAxis("J4OButtonPS4") > 0)
            {
                j4Connected = true;
                j4PressCricle.SetActive(false);
                j4Character[j4PlayerNum].SetActive(true);
                gameManager.j4 = true;
                gameManager.j4c = j4PlayerNum;

                if (!isPressStart)
                {
                    isPressStart = true;
                    pressStartText.SetActive(true);
                }
            }
        }
        else
        {
            if (InputManager.Instance.GetAxisRaw("J4LeftStickHorizontalPS4") > 0)
            {
                j4Character[j4PlayerNum].SetActive(false);

                j4PlayerNum++;
                if (j4PlayerNum > 3)
                    j4PlayerNum = 0;

                j4Character[j4PlayerNum].SetActive(true);
                gameManager.j4c = j4PlayerNum;
            }
        }

        if (isPressStart)
        {
            Debug.Log("Start");
            if(Input.GetAxis("J1SettingsButtonPS4") > 0 || Input.GetAxis("J2SettingsButtonPS4") > 0)
                gameManager.LoadScene(nextScaneName);
        }
    }
}
