using UnityEngine;
using System.Collections;
[System.Serializable]
public class Ingredient2 : Item
{
    public Canvas canvas;
    // Use this for initialization
 
    public  void Start()
    {
        if (canvas == null)
            canvas = GetComponentInChildren<Canvas>();
        if(rigidbodyController==null)
        rigidbodyController = GetComponent<RigidbodyController>();
        duration = 5f;
        nameO = "Ing2";
        itemType = ItemType.Ing;
        ing = ItemUiType.Ing2;
    }
    public void Update()
    {
        if (transform.parent == null  )
        { 
                canvas.transform.gameObject.SetActive(true);
        }
        else if(transform.parent!=null && transform.parent==null)
            canvas.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame


}
