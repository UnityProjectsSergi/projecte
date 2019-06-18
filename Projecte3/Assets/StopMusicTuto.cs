using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusicTuto : MonoBehaviour
{

    // Start is called before the first frame update
    
    public void OnEnable()
    {
        SoundManager.Instance.StartMusicTuto();     
    }
    public void StopMusicTutoF()
    {
        SoundManager.Instance.StopMusicTuto();
    }
    // Update is called once per frame
  
}
