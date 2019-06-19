using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusicTuto : MonoBehaviour
{
    public FMOD.Studio.EventInstance Tuto;
    // Start is called before the first frame update
    public void Start()
    {
        Tuto = SoundManager.Instance.CreateEventInstaceAttached("event:/Music/Tutorial", this.gameObject);
        Tuto.start();
    }
  
    public void OnEnable()
    {
       
    }
    public void OnExit()
    {
        Tuto.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    // Update is called once per frame
  
}
