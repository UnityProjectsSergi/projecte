﻿using System;
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

    public bool isStarted = false;
    
    public float timeShowAlertBurning = 2.5f;
    public float timeBurning = 1.0f;
    public PotUI PotUI;

    public float percentCook;
    public float journey;
    public bool speedUp;
  
    public float timeBetweenCookDoneAndShowOK;
    public float timeShowingOK;
    public float timeBetweenShowOkAndAlert;
    public float timeShowingAlert;
    public float timeBetweenAlertAndBurn;
    



    void Start()
    {
        PotUI = gameObject.transform.parent.GetComponent<PotUI>();
        ProgressBar.gameObject.SetActive(false);
    }

    void Update()
    {
        //// q tu aqui li dones un valor 
        if (StartCookingBool)
        {
            if (speedUp)
                journey += Time.deltaTime * 2f;
            else
               journey += Time.deltaTime;
            if (journey < totalduration + 0.1f)
            {
                ProgressBar.gameObject.SetActive(true);
                percentCook = Mathf.Clamp01(journey / totalduration);

                ProgressBar.fillAmount = percentCook;
                if (ProgressBar.fillAmount >= 0.999f)
                {
                    ProgressBar.gameObject.SetActive(false);
                    PotUI.SetItemPotState(ItemPotStateIngredients.CookedDone);
                    StartCoroutine(ShowImageOK(timeBetweenCookDoneAndShowOK,timeShowingOK,0, CookedOk));               
                }
            }
            //else
            //{
            //    //if (journey <= (totalduration + timeAlertBurning))
            //    //{
            //    //    if (StartTimerAlrert)
            //    //    {
            //    //        alertTimer -= Time.deltaTime;
            //    //        if (alertTimer >= 0.0f)
            //    //        {
            //    //            StartCoroutine(ShowImageAlert(3f, AlertBurn));
            //    //            PotUI.SetItemPotState(ItemPotStateIngredients.Alert);
            //    //        }
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    if (journey <= (totalduration + timeShowAlertBurning + alertTimer))
            //    //    {

            //    //                PotUI.SetItemPotState(ItemPotStateIngredients.Burning);
            //    //                StartCoroutine(ShowImageFire(4f, Fire));


            //    //    }
            //    //}
            //}
        }
    }

    internal void Reset()
    {
        journey = 0;
        StartCookingBool = false;
        BurnAfterFire.gameObject.SetActive(false);
        totalduration = 0;
        ProgressBar.fillAmount = 0;
    }

    public void StartCooking()
    {
        if (!isStarted)
        {
            isStarted = true;
            StartCookingBool = true;
            Debug.Log("start cooking");
            PotUI.SetItemPotState(ItemPotStateIngredients.Cooking);
        }
    }
   
    public void StopCooking()
    {
        StartCookingBool = false;     
    }

    public IEnumerator ShowImageOK(float waitBefore,float waitDuring,float waitAfter,Image image)
    {
        yield return new WaitForSeconds(waitBefore);
        image.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitDuring);
       
        image.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitAfter);
        StartCoroutine(ShowImageAlert(timeBetweenShowOkAndAlert,timeShowingAlert,0, AlertBurn));
        
        
    }

    public IEnumerator ShowImageBurn(float waitBefore, Image image)
    {
        yield return new WaitForSeconds(waitBefore);
        image.gameObject.SetActive(true);
        PotUI.SetItemPotState(ItemPotStateIngredients.BurnedToTrash);



    }

    public IEnumerator ShowImageAlert(float waitBefore, float waitDuring, float waitAfter, Image image)
    {
        yield return new WaitForSeconds(waitBefore);
        PotUI.SetItemPotState(ItemPotStateIngredients.Alert);
        image.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitDuring);

        image.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitAfter);
        StartCoroutine(ShowImageBurn(0.1f, BurnAfterFire));

    }

   
}
