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
        nameO = "Ing2";
        itemType = ItemType.Ing;
        ing = ItemUiType.Ing2;
    }
    public override void Update()
    {
        base.Update();
        if (transform.parent != null && transform.parent.parent != null)
        {
            if (!canvas.gameObject.activeSelf)
                canvas.transform.gameObject.SetActive(true);
        }
        else
            if(canvas.gameObject.activeSelf)
            canvas.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame


}
