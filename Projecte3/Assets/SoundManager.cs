﻿using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using FMODUnity;
public class SoundManager : MonoBehaviour
{
    public FMOD.Studio.EventInstance Music;
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } private set { } }
    public string FireEvent;
    // Start is 
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            //   listOrders = new List<Order>();
            DontDestroyOnLoad(this.gameObject);
        }
    }
    //called before the first frame update
    void Start()
    {
        Music = CreateEventInstaceAttached("event:/Music/Ambient/Ambient", this.gameObject);
        Music.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OneShotEvent(string nameEvent, Vector3 position = new Vector3())
    {
        RuntimeManager.PlayOneShot(nameEvent, position);
    }
    public void OneShotEventAttatchet(string nameEvent, GameObject gameObject)
    {
        RuntimeManager.PlayOneShotAttached(nameEvent, gameObject);
    }
    public FMOD.Studio.EventInstance CreateEventInstaceAttached(string name, GameObject gameObject)
    {
        FMOD.Studio.EventInstance instance = RuntimeManager.CreateInstance(name);
        RuntimeManager.AttachInstanceToGameObject(instance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
        return instance;
    }

}
