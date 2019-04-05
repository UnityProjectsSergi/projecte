using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public bool _P1;
    public bool _P2;
    public bool _P3;
    public bool _P4;

    void Awake()
    {
        Debug.Log(gameObject.name);
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void LoadLvl(bool _P1, bool _P2, bool _P3, bool _P4, int _lvl)
    {

    }
}
