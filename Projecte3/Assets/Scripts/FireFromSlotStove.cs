    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFromSlotStove : MonoBehaviour
{
    public ParticleSystem Fire;
    [Range(1,10)]
    public float FIREiNTENSITY;
    // Start is called before the first frame update
    void Start()
    {
        Fire = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame


    internal void updateFire(float fireIntensity)
    {
        var em = Fire.emission;
        float num = Mathf.Abs(FIREiNTENSITY - 10);
        num = num / 20;
        em.rateOverTime = num;
    }
}
