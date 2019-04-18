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
    public bool StartCookingBool;
    Coroutine co;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        if (StartCookingBool)
        {
            fillAmount += totalduration * Time.deltaTime;
            ProgressBar.fillAmount = fillAmount;
        }
    }
    public void StartCooking()
    {
        
        StartCookingBool = true;
       // co=StartCoroutine(Cooking(totalduration));
    }
   public void StopCooking()
    {
        StartCookingBool = false;
        if (co != null)
        {
            Debug.Log("stop cok");
            StopCoroutine(co);
            
        }
    }
    IEnumerator Cooking(float duration)
    {
        ProgressBar.gameObject.SetActive(true);
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
