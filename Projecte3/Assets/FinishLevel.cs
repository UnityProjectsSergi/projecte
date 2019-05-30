using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    // Start is 
    bool isStop = false;

    public float timeChangeScene;
    public string nameNextScene; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nameNextScene != null)
        {

            if (timeChangeScene > 0.0)
                timeChangeScene -= Time.unscaledDeltaTime;
            else
                GameManager.Instance.LoadScene(nameNextScene);


        }
    }
}
