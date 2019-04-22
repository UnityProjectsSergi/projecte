using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBarBB : MonoBehaviour
{
    public Image image;
    public float fillAmount;
    public float joureney;
    public float percent;
    // Use this for initialization
    void Start()
    {
        image=GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = fillAmount;
    }
}
