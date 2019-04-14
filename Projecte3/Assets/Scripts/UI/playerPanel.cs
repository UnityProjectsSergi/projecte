using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPanel : MonoBehaviour
{
    public int PlayerNumber;
    public Character Playernum;
    public bool hasControllerAssigned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public object AssignController(int i)
    {
        Playernum.playerInput.SetControllerNumber(i,"PS4");
        hasControllerAssigned = true;
        return Playernum;
    }
}
