using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Screen : MonoBehaviour
{
    public UIFader canvas;
    // Start is called before the first frame update
    public virtual void Awake()
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
        canvas.uiElement.interactable = true;
        canvas.uiElement.blocksRaycasts = true;

    }
}
