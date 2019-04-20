using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotUIState : MonoBehaviour
{
    public float progresSpeed = 1;
    public Image ProgressBar;
    public Image AlertBurn;
    public Image BurnAfterFire;
    public Image CookedOk;
    public float fillAmount = 0;
    public float totalduration = 0;
    public bool StartCookingBool;
    public bool StartBuringBool;
    
    public float timeShowAlertBurning = 2.5f;
    public float timeBurning = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        ProgressBar.gameObject.SetActive(false);
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
                ProgressBar.gameObject.SetActive(true);
                percentCook = Mathf.Clamp01(journey / totalduration);
                Debug.Log(percentCook + "percent   fillamount: "+ProgressBar.fillAmount+" juourney " + journey);
                ProgressBar.fillAmount = percentCook;
                if (ProgressBar.fillAmount >= 0.99f)
                {
                    ProgressBar.gameObject.SetActive(false);
                    Debug.Log("buen ththe stove");
                    StartCoroutine(ShowImageOK(3f));
                }
            }
            else
            {
                if(journey<=(totalduration + timeShowAlertBurning))
                {
                    Debug.Log("show alert to burn");


                    
                }
                else if(journey<= (totalduration+timeShowAlertBurning+timeBurning))
                {
                 //   AlertShowed = true;
                    
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
        StartCookingBool = true;
       
        // co=StartCoroutine(UIBarCooking());
    }
   
   public void StopCooking()
    {
        StartCookingBool = false;
        
      
    }
    public IEnumerator ShowImageOK(float wait)
    {
        CookedOk.gameObject.SetActive(true);
        yield return new WaitForSeconds(wait);
        CookedOk.gameObject.SetActive(false);
          
    }

    public void StartBurning()
    {
        StartBuringBool = true;
    }
    public void StopBurning()
    {
        StartBuringBool = false;
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
