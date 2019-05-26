using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Edelweiss.Coroutine;
public class PotUIStateCo : MonoBehaviour
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


    public PotUI PotUI;
    public ItemPot ItemPot;
    public float percentCook;
    public float journey;
    public bool speedUp;

    public float timeBetweenCookDoneAndShowOK;
    public float timeShowingOK;
    public float timeBetweenShowOkAndAlert;
    public float timeBetweenAlertAndBurn;
    public float SpeedUpReduccion;
    public float SpeedUpParticlesFireAmount;
    public ParticleSystem[] fires;
    public bool hasSpeedUp;
    
    public SafeCoroutine OK;
    public SafeCoroutine Alert;
    void Awake()
    {
        ItemPot = gameObject.transform.parent.parent.GetComponent<ItemPot>();
        PotUI = gameObject.transform.parent.GetComponent<PotUI>();

        ProgressBar.gameObject.SetActive(false);
    }

    public void SetFire()
    {
        fires = ItemPot.Fire.GetComponentsInChildren<ParticleSystem>();
        Debug.Log(fires);
        for (int i = 0; i < fires.Length; i++)
        {
            nums[i] = fires[i].emission.rateOverTimeMultiplier;
        }
    }
    float[] nums = new float[5];

    public bool IsPasedCooking;

    public bool IsPausedCooking { get; private set; }

    public void setSpeedUpParticles()
    {

        if (speedUp && !hasSpeedUp)
        {
            Debug.Log("speddUPoK");
            int i = 0;
            foreach (var item in fires)
            {
                var fire = item.emission;
                nums[i] = fire.rateOverTimeMultiplier;
                fire.rateOverTimeMultiplier *= SpeedUpParticlesFireAmount;
                i++;
            }
            hasSpeedUp = true;
        }
        else if(!speedUp)
        {
            Debug.Log("not speedup");
            int i = 0;
            foreach (var item in fires)
            {
                var fire = item.emission;
                fire.rateOverTimeMultiplier = nums[i];
                i++;
            }
        }

    }

    void Update()
    {
        setSpeedUpParticles();
        if (StartCookingBool)
        {
            if (!IsPasedCooking)
            {
                if (speedUp)
                {
                    journey += Time.deltaTime * SpeedUpReduccion;
                }
                else
                {
                    journey += Time.deltaTime;
                }
                if (journey < totalduration + 0.1f)
                {
                    ProgressBar.gameObject.SetActive(true);
                    percentCook = Mathf.Clamp01(journey / totalduration);
                    ProgressBar.fillAmount = percentCook;
                    if (ProgressBar.fillAmount >= 0.999f)
                    {
                        ProgressBar.gameObject.SetActive(false);
                        PotUI.SetItemPotState(ItemPotStateIngredients.CookedDone);
                        // StartCoroutine(ShowImageOK(timeBetweenCookDoneAndShowOK, timeShowingOK, 0.1f, CookedOk));
                        OK = this.StartSafeCoroutine(ShowImageOK(timeBetweenCookDoneAndShowOK, timeShowingOK, 0.1f, CookedOk));
                    }
                }
                if (OK != null)
                {
                    Debug.Log(OK.State);
                    if (OK.HasFinished)
                    {
                        ProgressBar.gameObject.SetActive(false);
                        Alert = this.StartSafeCoroutine(ShowImageAlert(timeBetweenShowOkAndAlert, 0.1f, AlertBurn));
                        OK = null;
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
            else
            {
                ProgressBar.gameObject.SetActive(false);
                CookedOk.gameObject.SetActive(false);
                AlertBurn.gameObject.SetActive(false);
            }
        }
        else
        {

        }
    }

    internal void Reset()
    {
        journey = 0;
        isStarted = false;
        StartCookingBool = false;
        BurnAfterFire.gameObject.SetActive(false);
        AlertBurn.gameObject.SetActive(false);
        CookedOk.gameObject.SetActive(false);
        totalduration = 0;
        journey = 0;
        ProgressBar.fillAmount = 0;
        StopAllCoroutines();
        if (OK != null)
            if (OK.IsPaused) OK.Stop();
        if (Alert != null)
            if (Alert.IsPaused) Alert.Stop();
        OK = null;
        Alert = null;
    }

    public void StartCooking()
    {

        isStarted = true;
        StartCookingBool = true;
        PotUI.SetItemPotState(ItemPotStateIngredients.Cooking);

    }
    public void ResumeCooking()
    {
        if (isStarted && IsPausedCooking)
        {
            IsPausedCooking = false;
            if (OK != null)
            {
                if (OK.IsPaused) { OK.Resume(); }
            }
            if (Alert != null)
            {
                if (Alert.IsPaused) { Alert.Resume(); }
            }
        }
    }
    public void PauseCooking()
    {
        if (isStarted && !IsPausedCooking)
        {
            IsPausedCooking = true;
            if (OK != null)
            {
                if (OK.IsRunning)
                {
                    OK.Pause();
                }
            }
            if (Alert != null)
            {
                if (Alert.IsRunning) { Alert.Pause(); }
            }
        }

    }
    public IEnumerator ShowImageOK(float waitBefore, float waitDuring, float waitAfter, Image image)
    {
        if (IsPausedCooking)
        {
            image.gameObject.SetActive(false);
            while (true)
            {
                yield return (null);
            }
        }
        else
        {
            yield return new WaitForSeconds((speedUp) ? waitBefore / SpeedUpReduccion : waitBefore);
            image.gameObject.SetActive(true);
            yield return new WaitForSeconds((speedUp) ? waitDuring / SpeedUpReduccion : waitDuring);
            image.gameObject.SetActive(false);
            yield return new WaitForSeconds((speedUp) ? waitAfter / SpeedUpReduccion : waitAfter);
            yield return null;
        }
    }
    public IEnumerator ShowImageBurn(float waitBefore, Image image)
    {
        yield return new WaitForSeconds((speedUp) ? waitBefore / SpeedUpReduccion : waitBefore);
        image.gameObject.SetActive(true);
        PotUI.SetItemPotState(ItemPotStateIngredients.BurnedToTrash);
    }

    public IEnumerator ShowImageAlert(float waitBefore, float waitAfter, Image image)
    {
        if (IsPausedCooking)
        {
            image.gameObject.SetActive(false);
            while (true)
            {
                yield return (null);
            }
        }
        else
        {
            yield return new WaitForSeconds((speedUp) ? waitBefore / SpeedUpReduccion : waitBefore);
            PotUI.SetItemPotState(ItemPotStateIngredients.Alert);
            for (int i = 0; i < 3; i++)
            {
                image.gameObject.SetActive(true);
                yield return new WaitForSeconds((speedUp) ? 0.5f / SpeedUpReduccion : 1F);
                image.gameObject.SetActive(false);
                yield return new WaitForSeconds((speedUp) ? 0.5f / SpeedUpReduccion : 1F);
            }
            for (int i = 0; i < 6; i++)
            {
                image.gameObject.SetActive(true);
                yield return new WaitForSeconds((speedUp) ? 0.25f / SpeedUpReduccion : 0.5F);
                image.gameObject.SetActive(false);
                yield return new WaitForSeconds((speedUp) ? 0.25f / SpeedUpReduccion : 0.5F);
            }
            for (int i = 0; i < 12; i++)
            {
                image.gameObject.SetActive(true);
                yield return new WaitForSeconds((speedUp) ? 0.1f / SpeedUpReduccion : 0.25F);
                image.gameObject.SetActive(false);
                yield return new WaitForSeconds((speedUp) ? 0.1f / SpeedUpReduccion : 0.25F);
            }
            yield return new WaitForSeconds((speedUp) ? waitAfter / SpeedUpReduccion : waitAfter);
            StartCoroutine(ShowImageBurn(0.1f, BurnAfterFire));
            yield return null;
        }
    }
    //}
    //public IEnumerator ShowImageOK(float waitBefore, float waitDuring, float waitAfter, Image image)
    //{
    //    if (IsPasedCooking)
    //    {
    //        while (true)
    //            yield return null;
    //    }
    //    else
    //    {
    //        yield return new WaitForSeconds((speedUp) ? waitBefore / SpeedUpReduccion : waitBefore);
    //        image.gameObject.SetActive(true);
    //        yield return new WaitForSeconds((speedUp) ? waitDuring / SpeedUpReduccion : waitDuring);
    //        image.gameObject.SetActive(false);
    //        yield return new WaitForSeconds((speedUp) ? waitAfter / SpeedUpReduccion : waitAfter);
    //        StartCoroutine(ShowImageAlert(timeBetweenShowOkAndAlert, 0.1f, AlertBurn));
    //    }
    //}

    //public IEnumerator ShowImageBurn(float waitBefore, Image image)
    //{
    //    yield return new WaitForSeconds((speedUp) ? waitBefore / SpeedUpReduccion : waitBefore);
    //    image.gameObject.SetActive(true);
    //    PotUI.SetItemPotState(ItemPotStateIngredients.BurnedToTrash);
    //}

    //public IEnumerator ShowImageAlert(float waitBefore, float waitAfter, Image image)
    //{
    //    if (IsPasedCooking)
    //    {
    //        while (true)
    //            yield return null;
    //    }
    //    else
    //    {
    //        yield return new WaitForSeconds((speedUp) ? waitBefore / SpeedUpReduccion : waitBefore);
    //        PotUI.SetItemPotState(ItemPotStateIngredients.Alert);
    //        for (int i = 0; i < 3; i++)
    //        {
    //            image.gameObject.SetActive(true);
    //            yield return new WaitForSeconds((speedUp) ? 0.5f / SpeedUpReduccion : 0.5F);
    //            image.gameObject.SetActive(false);
    //            yield return new WaitForSeconds((speedUp) ? 0.5f / SpeedUpReduccion : 0.5F);
    //        }
    //        for (int i = 0; i < 6; i++)
    //        {
    //            image.gameObject.SetActive(true);
    //            yield return new WaitForSeconds((speedUp) ? 0.25f / SpeedUpReduccion : 0.25F);
    //            image.gameObject.SetActive(false);
    //            yield return new WaitForSeconds((speedUp) ? 0.25f / SpeedUpReduccion : 0.25F);
    //        }
    //        for (int i = 0; i < 12; i++)
    //        {
    //            image.gameObject.SetActive(true);
    //            yield return new WaitForSeconds((speedUp) ? 0.1f / SpeedUpReduccion : 0.1F);
    //            image.gameObject.SetActive(false);
    //            yield return new WaitForSeconds((speedUp) ? 0.1f / SpeedUpReduccion : 0.1F);
    //        }
    //        yield return new WaitForSeconds((speedUp) ? waitAfter / SpeedUpReduccion : waitAfter);
    //        StartCoroutine(ShowImageBurn(0.1f, BurnAfterFire));
    //    }
    //}


}

