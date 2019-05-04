using UnityEngine;
using System.Collections;

public class PotBlackboard : MonoBehaviour
{
    public float journey;
    public float timeToAlert;
    public GameObject GOIMGBURN;
    public FSM.FSM_ShowHideImage fSM_IMAGE;
    // Use this for initialization
    void Awake()
    {
        fSM_IMAGE = GOIMGBURN.AddComponent<FSM.FSM_ShowHideImage>();
        fSM_IMAGE.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
