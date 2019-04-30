using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBarBlackboard : MonoBehaviour
{
    public Image image;
    
    public float percent;
    public PotBlackboard potBlackboard;
    // Use this for initialization
    void Start()
    {
       // gameObject.AddComponent<FSM.FSM_ProgressBar>();
        image=GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
    
        image.fillAmount = percent;
    }
}
