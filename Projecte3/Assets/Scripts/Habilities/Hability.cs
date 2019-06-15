using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hability : MonoBehaviour
{
    public bool habilityHabailable = true, usingHability;

    public string hability;
    public float _duration;
    public float _coolDown;
    public delegate void MyHability();
    public MyHability Starthability;
    public MyHability CancelHability;

    public Image imageCooldown;
    Coroutine stop;

    public void set(float duration, float cooldown, MyHability Start, MyHability _cancel,Image image)
    {
        _duration = duration;
        _coolDown = cooldown;
        Starthability += Start;
        CancelHability += _cancel;
        imageCooldown = image;
    }

   

    public void UseHability()
    {
        if (habilityHabailable)
        {
            Starthability();
            habilityHabailable = false;
            usingHability = true;
            stop = StartCoroutine(Cooldown());
        }
    }

    public void StopHability()
    {
        if (!habilityHabailable && usingHability)
        {
            usingHability = false;
            if (CancelHability != null)
            {
                CancelHability.Invoke();
                StopCoroutine(stop);
                CountDownAnimation(_coolDown);
            }
        }
    }

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_duration);
        Debug.Log("Cooldown end");
        StopHability();
        StartCoroutine(CountDownAnimation(_coolDown));
        yield return null;
    }

    public void StartCoolDown()
    {
        StartCoroutine(CountDownAnimation(_coolDown));
    }

    IEnumerator CountDownAnimation(float time)
    {
        float animationTime = time;
        while (animationTime > 0)
        {
            imageCooldown.GetComponent<Image>().enabled = true;
            animationTime -= Time.deltaTime;
            imageCooldown.fillAmount = animationTime / time;
            if (animationTime < 0.01f)
            {
                habilityHabailable = true;

               imageCooldown.enabled = false;
            }

            yield return null;
        }

    }





}
