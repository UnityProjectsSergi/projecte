using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionTrial : MonoBehaviour
{
    public Material emissiveMaterial;
    public float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        
        if(timer < 1)
        {
            emissiveMaterial.DisableKeyword("_EMISSION");
        }

        else if (timer >= 1)
        {
            //emissiveMaterial.EnableKeyword("_EMISSION");
            emissiveMaterial.EnableKeyword("_EMISSION");
            

        }

        else if(timer >= 10)
        {
            timer = 0;
        }

    }
}
