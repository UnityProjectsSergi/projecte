using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ImageShowHideBlackboard : MonoBehaviour
{
    public float timeShowImage, timeHideImage;
    public float timer;
    public Image image;
    public float timeWaitShowImage;
    // Use this for initialization
    void Start()
    {
    
        image = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
