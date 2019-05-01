using UnityEngine;
using System.Collections;

public class AlertStatesBlackBoard : MonoBehaviour
{
    [Header("Alert States")]
    [Header("Slow")]
    public float timerHideSlow;
    public float timerShowSlow;
    public float numRepetitionsSlow;
    [Header("Normal")]
    public float timerHideNormal;
    public float timerShowNormal;
    public float numRepetitionsNormal;
    [Header("Fast")]
    public float timerHideFast;
    public float timerShowFast;
    public float numRepetitionsFast;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
