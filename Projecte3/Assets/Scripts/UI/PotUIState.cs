using System;
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
    public Image Fire;
    public Image CookedOk;
    public float fillAmount = 0;
    public float totalduration = 0;
    public bool StartCookingBool;
    public bool StartBuringBool;
    
    public float timeShowAlertBurning = 2.5f;
    public float timeBurning = 1.0f;
    public PotUI PotUI;
    // Start is called before the first frame update
    void Start()
    {
        PotUI = gameObject.transform.parent.GetComponent<PotUI>();
        ProgressBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public bool StartTimerAlrert;
    void Update()
    {
        //// q tu aqui li dones un valor 
        if (StartCookingBool)
        {

            journey += Time.deltaTime;
            if (journey < totalduration + 0.1f)
            {
                ProgressBar.gameObject.SetActive(true);
                percentCook = Mathf.Clamp01(journey / totalduration);
                Debug.Log(percentCook + "percent   fillamount: " + ProgressBar.fillAmount + " juourney " + journey);
                ProgressBar.fillAmount = percentCook;
                if (ProgressBar.fillAmount >= 0.999f)
                {
                    ProgressBar.gameObject.SetActive(false);
                    Debug.Log("buen ththe stove");
                    PotUI.SetItemPotState(ItemPotStateIngredients.CookedDone);
                    StartCoroutine(ShowImageOK(3f, CookedOk));
                 
                }
            }
            else
            {
                if (journey <= (totalduration + timeShowAlertBurning))
                {

                    float alertTimer = 3;
                    if (StartTimerAlrert)
                    {
                        alertTimer -= Time.deltaTime;
                        if (alertTimer >= 0.0f)
                        {
                            Debug.Log("show image alert");
                            StartCoroutine(ShowImageAlert(3f, AlertBurn));
                            PotUI.SetItemPotState(ItemPotStateIngredients.Alert);
                        }
                    }
                }
                else
                {
                    if (journey <= (totalduration + timeShowAlertBurning + timeBurning))
                    {
                        float BurnTimer = 4f;
                        if (StartBuringBool)
                        {
                            BurnTimer -= Time.deltaTime;
                            if (BurnTimer >= 0.0f)
                            {
                                StartCoroutine(ShowImageFire(4f, Fire));
                                PotUI.SetItemPotState(ItemPotStateIngredients.Burning);

                            }
                        }
                    }
                }
            }
        }
    }

    internal void Reset()
    {
        journey = 0;
        StartCookingBool = false;
        StartBuringBool = false;
        StartTimerAlrert = false;
        BurnAfterFire.gameObject.SetActive(false);
        totalduration = 0;
        ProgressBar.fillAmount = 0;
    }

    public void StartCooking()
    {
        // pk sempre es true
        StartCookingBool = true;
        
        PotUI.SetItemPotState(ItemPotStateIngredients.Cooking);
       
        // co=StartCoroutine(UIBarCooking());
    }
   
   public void StopCooking()
    {
        StartCookingBool = false;
    
      
    }
    public IEnumerator ShowImageOK(float wait,Image image)
    {
        image.gameObject.SetActive(true);
        yield return new WaitForSeconds(wait);
        StartTimerAlrert = true;    
        image.gameObject.SetActive(false);
        
       


    }
    public IEnumerator ShowImageFire(float wait, Image image)
    {
        image.gameObject.SetActive(true);
        yield return new WaitForSeconds(wait);
        
        image.gameObject.SetActive(false);
        BurnAfterFire.gameObject.SetActive(true);
        PotUI.SetItemPotState(ItemPotStateIngredients.BurnedToTrash);   
    }
    public IEnumerator ShowImageAlert(float wait, Image image)
    {
        image.gameObject.SetActive(true);
        yield return new WaitForSeconds(wait);
        StartBuringBool = true; 
        image.gameObject.SetActive(false);



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
