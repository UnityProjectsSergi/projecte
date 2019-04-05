using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectorMenuManager : MonoBehaviour
{
    GameManager m_GameManager;

    public Text[] textConection;

    public bool m_PlayerOneConected = false;
    public bool m_PlayerTwoConected = false;
    public bool m_PlayerThreeConected = false;
    public bool m_PlayerFourConected = false;

    private void Start()
    {
        m_GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        ConnectGamepad("J1X");
        ConnectGamepad("J2X");

        if (Input.GetAxis("J1Options") > 0)
        {
            m_GameManager.LoadLvl(m_PlayerOneConected,
                                  m_PlayerTwoConected,
                                  m_PlayerThreeConected,
                                  m_PlayerFourConected,
                                  1);
        }
    }

    private void ConnectGamepad(string _xNameInput)
    {
        if (Input.GetAxis(_xNameInput) > 0 && !m_PlayerOneConected)
        {
            m_PlayerOneConected = true;
            textConection[0].text = "Player 1 Conected";
            textConection[0].color = Color.green;
        }
    }
}
