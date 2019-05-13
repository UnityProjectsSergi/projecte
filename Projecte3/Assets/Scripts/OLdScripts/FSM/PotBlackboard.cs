using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PotBlackboard : MonoBehaviour
{
    public float journey = 0,percent=1.0f;
    public float timeToAlert;
    public Image imageProgBar;
    public GameObject GOIMGBURN;
    public FSM.FSM_ShowHideImage fSM_IMAGE;
    public float timeToWaitShowOk,timeShowOK,timerOk,timerHideOk;
    public float timeToWaitShowAlert, timeShowAlert, timerAlert,timerHideAlert;
    public Image imageOk;
    public Image imageAlert;

    // Use this for initialization
    void Awake()
    {
        imageProgBar.fillAmount = 1;
        //fSM_IMAGE = GOIMGBURN.AddComponent<FSM.FSM_ShowHideImage>();
        //fSM_IMAGE.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
   
        imageProgBar.fillAmount = percent;
    }
}
