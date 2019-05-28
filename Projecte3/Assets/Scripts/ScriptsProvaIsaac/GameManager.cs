using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public static GameManager Instance
    {
        get { return instance; }
    }

    public bool j1, j2, j3, j4;
    public int j1c, j2c, j3c, j4c;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void CheckPlayerActive(int controller, GameObject caller)
    {
        HabilityesController hability;
        switch (controller)
        {
            case 1:
                if (!j1)
                    caller.SetActive(false);

                hability = caller.GetComponent<HabilityesController>();
                hability.habilityType = (HabilityType)j1c;
                hability.SetHability();
                break;
            case 2:
                if (!j2)
                    caller.SetActive(false);

                hability = caller.GetComponent<HabilityesController>();
                hability.habilityType = (HabilityType)j2c;
                hability.SetHability();
                break;
            default:
                break;
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }
}
