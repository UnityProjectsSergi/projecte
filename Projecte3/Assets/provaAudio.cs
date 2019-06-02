using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class provaAudio : MonoBehaviour
{
    FMOD.Studio.EventInstance EventInstance;
    // Start is called before the first frame update
    void Start()
    {
        EventInstance = SoundManager.Instance.CreateEventInstaceAttached("event:/Sounds/Cook/Pot/PotIdle", this.gameObject);
        EventInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
