using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotUIBar : MonoBehaviour
{
    public float progresSpeed = 1;
    public Image ProgressBar;
    public float fillAmount = 0;
    public float totalduration = 0;
    public bool StartCookingBool;
    public float timeShowAlertBurning = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
  
    // Update is called once per frame
    void Update()
    {
        // q tu aqui li dones un valor 
        if (StartCookingBool)
        {
            journey += Time.deltaTime;
            if (journey < totalduration)
            {
                
                percentCook = Mathf.Clamp01(journey / totalduration);
                Debug.Log(percentCook + "percent   fillamount: "+ProgressBar.fillAmount+" juourney " + journey);
                ProgressBar.fillAmount = percentCook;
                if (ProgressBar.fillAmount >= 1.0f)
                {
                    
                    Debug.Log("buen ththe stove");
                    
                    
                }
            }
            else
            {
                if(journey<=totalduration + timeShowAlertBurning)
                {
                    Debug.Log("show alert to burn");
                }
                else
                {
                    // cal 
                    Debug.Log("show icon ingredients burned");
                }
            }
            // fillAmount += progresSpeed * Time.deltaTime;
            //  ProgressBar.fillAmount = fillAmount;
            // fillAmount += percentCook * Time.deltaTime;
            // ProgressBar.fillAmount = fillAmount;
        }
    }
    public void StartCooking()
    {
        // pk sempre es true
        StartCookingBool = true; ProgressBar.gameObject.SetActive(true);
        // co=StartCoroutine(UIBarCooking());
    }
   
   public void StopCooking()
    {
        StartCookingBool = false;
        ProgressBar.gameObject.SetActive(false);
        if (co != null)
        {
            Debug.Log("stop cok");
         ///  StopCoroutine(co);
            
        }
    }
    public float percentCook;
    private float journey;
    //********* code for control the potui with correountine */
    /*
    Coroutine co;
    // xcom si fessim u altre cosa apart 
    IEnumerator UIBarCooking()
    {
        
        
        float journey = 0f;
        while (journey <= totalduration)
        {
            
                journey += Time.deltaTime;
                percentCook = Mathf.Clamp01(journey / totalduration);

                ProgressBar.fillAmount = Mathf.Lerp(0, 1.0f, percentCook);
                if (ProgressBar.fillAmount >= 1.0)
                {
                    ProgressBar.gameObject.SetActive(false);
                    StartCookingBool = false;
                }
                yield return null;
            
            

        }
    }*/

}
