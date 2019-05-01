using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ImageShowHideBlackboard : MonoBehaviour
{
    public float timeShowImage, timeHideImage;
    public float timer;
    public Image image;
    public float timeWaitShowImage;
    public bool hasRepetition;
    public int numRepetitions;
    public int count;
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
