using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UI_Screen : MonoBehaviour
{
   public UIFader canvas;
    public string stringEventSound="";
    public GameObject FisrrtSelected;
    FMOD.Studio.EventInstance EventInstance;
    public bool HasStopOnClose, HasStartOnOpen,isSounding;

    // Start is called before the first frame update
    public virtual void  Awake()
    {
        if(stringEventSound!="")
        EventInstance = SoundManager.Instance.CreateEventInstaceAttached(stringEventSound, this.gameObject);
        canvas = GetComponent<UIFader>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    public virtual void CloseScreen()
    {
        if (HasStopOnClose && isSounding && EventInstance.isValid())
        {
            isSounding = false;
            EventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        canvas.FadeOut();
        canvas.uiElement.interactable = false;
        canvas.uiElement.blocksRaycasts = false;
    }
    public virtual void OpenScreen()
    {

        if (HasStartOnOpen && !isSounding && EventInstance.isValid())
        {
            isSounding = true;
            EventInstance.start();
        }
        canvas.FadeIn();
        EventSystem.current.SetSelectedGameObject(FisrrtSelected);
        canvas.uiElement.interactable = true;
        canvas.uiElement.blocksRaycasts = true;
      
    }
    

}
