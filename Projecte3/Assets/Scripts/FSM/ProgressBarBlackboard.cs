using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBarBlackboard : MonoBehaviour
{
    public Image image;
    public float fillAmount;
    public float percent;
    // Use this for initialization
    void Awake()
    {
        image=GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = fillAmount;
    }
}
