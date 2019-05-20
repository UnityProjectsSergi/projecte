using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UI_Screen : MonoBehaviour
{
   public UIFader canvas;
    public GameObject FisrrtSelected;
    // Start is called before the first frame update
    public virtual void  Awake()
    {

        canvas = GetComponent<UIFader>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    public virtual void CloseScreen()
    {
        canvas.FadeOut();
        canvas.uiElement.interactable = false;
        canvas.uiElement.blocksRaycasts = false;
    }
    public virtual void OpenScreen()
    {
        canvas.FadeIn();
        EventSystem.current.SetSelectedGameObject(FisrrtSelected);
        canvas.uiElement.interactable = true;
        canvas.uiElement.blocksRaycasts = true;
      
    }
    

}
