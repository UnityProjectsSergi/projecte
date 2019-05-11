using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using FSM;
using System;

public class ImageShowHideBlackboard : MonoBehaviour
{
    public float timeShowImage, timeHideImage;
    public float timer;
    public Image image;
    public float timeWaitShowImage;
    public bool hasRepetition;
    public int numRepetitions;
    public int count;
    public bool mustStay;
    public ItemPotFSM ItemPotFSM;
    // Use this for initialization
    void Start()
    {
    
        image = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void SetTimers(float _timeShow,float _timeHide,float _timeWaitShow, int numReapeats)
    {
        timeShowImage = _timeShow;
        timeHideImage = _timeHide;
        timeWaitShowImage = _timeWaitShow;
        numRepetitions = numReapeats;
    }
}
