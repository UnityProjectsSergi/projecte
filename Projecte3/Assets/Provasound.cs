using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class Provasound : MonoBehaviour
{
    private EventInstance eventInstance;

    // Start is called before the first frame update
    void Start()
    {
        eventInstance = SoundManager.Instance.CreateEventInstaceAttached("event:/Sounds/Cook/Pot/PotIdle", this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            eventInstance.start();
    }
}
