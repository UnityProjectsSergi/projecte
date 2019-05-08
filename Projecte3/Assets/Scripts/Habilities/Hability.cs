﻿using UnityEngine;
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

    public void set(float duration, float cooldown, MyHability Start, MyHability _cancel)
    {
        _duration = duration;
        _coolDown = cooldown;
        Starthability += Start;
        CancelHability += _cancel;
    }

    public void SetHabilityAvalableFalse()
    {
        habilityHabailable = false;
    }

    public void UseHability()
    {
        if (!habilityHabailable)
        {
            usingHability = true;

            Starthability();
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
                CancelHability();
                StopCoroutine(stop);
            }
        }
    }

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_duration);
        StopHability();
        yield return new WaitForSeconds(_coolDown);
        habilityHabailable = true;
        yield return null;
    }





}