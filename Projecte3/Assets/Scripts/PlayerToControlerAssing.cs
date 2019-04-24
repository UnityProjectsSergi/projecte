using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerToControlerAssing : MonoBehaviour
{
    private List<int> assignedControllers = new List<int>();
    private playerPanel[] playerPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Awake()
    {
        playerPanel = FindObjectsOfType<playerPanel>().OrderBy(t => t.PlayerNumber).ToArray();
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i < 3; i++)
        {
            if (assignedControllers.Contains(i))
                continue;
            if (Input.GetButtonDown("J" + i + "StartButtonPS4"))
            {
                AddPlayerController(i);
                break;
            }
        }
    }

    private object  AddPlayerController(int num)
    {
        assignedControllers.Add(num);
       for (int i = 1; i < playerPanel.Length+1; i++)
        {
            if(playerPanel[i].hasControllerAssigned==false)
            {
                return playerPanel[i].AssignController(num);
            }
        }
        return null;
    }
}
