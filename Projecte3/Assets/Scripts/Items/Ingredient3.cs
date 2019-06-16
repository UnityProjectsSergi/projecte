using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Ingredient3 : Item
{
    public Canvas canvas;

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
    }
}
