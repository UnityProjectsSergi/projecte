using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Screen : MonoBehaviour
{
   public CanvasGroup canvas;
    // Start is called before the first frame update
    void Awake()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void CloseScreen()
    {
        canvas.alpha = 0;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }
    public virtual void OpenScreen()
    {
        canvas.alpha = 1;
        canvas.interactable = true;
        canvas.blocksRaycasts = true;
      
    }

}
