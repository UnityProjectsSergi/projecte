using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicMenu : MonoBehaviour
{
    FMOD.Studio.EventInstance EventInstance;
    // Start is called before the first frame update
    void Start()
    {
        EventInstance = SoundManager.Instance.CreateEventInstaceAttached("event:/Music/Menu", this.gameObject);
        EventInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        EventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
