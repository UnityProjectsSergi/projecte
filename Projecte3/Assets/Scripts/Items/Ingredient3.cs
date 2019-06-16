using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Ingredient3 : Item
{
    public Canvas canvas;
    // Use this for initialization

    public  void Start()
    {
        if(canvas==null)
            canvas = GetComponentInChildren<Canvas>();
        if (rigidbodyController == null)
            rigidbodyController = GetComponent<RigidbodyController>();
        canvas.GetComponentInChildren<Image>().sprite = spriteIng;
        duration = 5f;
        nameO = "Ing3";
        itemType = ItemType.Ing;
        ing = ItemUiType.Ing3;
    }
    public override void Update()
    {
        base.Update();
        //if (transform.parent != null && transform.parent.parent != null)
        //{
        //    if (!canvas.gameObject.activeSelf)
        //        canvas.transform.gameObject.SetActive(true);
        //}
        //else
        //    if(canvas.gameObject.activeSelf)
        //    canvas.transform.gameObject.SetActive(false);
    }
    // com poso la url relativa fmod a unity
    //  ja esta 
    // xo el  problema es q con  git xq cadascu te un path difeent
   
    // Update is called once per frame


}
