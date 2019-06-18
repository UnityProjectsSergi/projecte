using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusicLevel : MonoBehaviour
{

    FMOD.Studio.EventInstance SoundLevel;
    // Start is called before the first frame update
    void Start()
    {

        SoundLevel = SoundManager.Instance.CreateEventInstaceAttached("event:/Music/MUSICLEVEL", this.gameObject);
        SoundLevel.start();
    }
    public void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDisable()
    {
        SoundLevel.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
