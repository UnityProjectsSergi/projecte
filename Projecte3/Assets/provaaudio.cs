using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class provaaudio : MonoBehaviour
{
    // Start is called before the first frame update
    private EventInstance eventInstance;

    // Start is called before the first frame update
    void Start()
    {
        eventInstance = SoundManager.Instance.CreateEventInstaceAttached("event:/Sounds/Cook/Pot/PotIdle", this.gameObject);
        eventInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
       //if (Input.GetKeyDown(KeyCode.A))
          
    }
}
