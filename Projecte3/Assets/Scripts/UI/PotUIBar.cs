using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotUIBar : MonoBehaviour
{
    public float progresSpeed = 1;
    public Image ProgressBar;
    private float fillAmount = 0;
    public float totalduration = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Cooking(float duration)
    {
        ProgressBar.gameObject.SetActive(true);
        float startTime = Time.realtimeSinceStartup;
        float journey = 0f;
        while (journey <= duration)
        {
            journey += Time.deltaTime;
            float percent = Mathf.Clamp01(journey / duration);

            ProgressBar.fillAmount = Mathf.Lerp(0, 1.0f, percent);
            if (ProgressBar.fillAmount >= 1.0)
                ProgressBar.gameObject.SetActive(false);
            yield return null;

        }
    }
}
