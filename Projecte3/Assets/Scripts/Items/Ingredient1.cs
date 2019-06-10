using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Ingredient1:Item
    {
    public Canvas canvas;
    
    public  void Start()
    {
        if (canvas == null)
            canvas = GetComponentInChildren<Canvas>();
        if(rigidbodyController==null)
        rigidbodyController = GetComponent<RigidbodyController>();
        canvas.GetComponentInChildren<Image>().sprite = spriteIng;
        duration = 2f;
        nameO = "Ing1";
        itemType = ItemType.Ing;
        ing = ItemUiType.Ing1;

    }
    public override void Update()
    {
        base.Update();
        if (transform.parent != null && transform.parent.parent != null)
        {
            if (transform.parent.parent.GetComponent<Character>() != null)
                canvas.gameObject.SetActive(true);
            else
                 canvas.gameObject.SetActive(false);
           
        }
        else
            canvas.gameObject.SetActive(true);
    }
}
