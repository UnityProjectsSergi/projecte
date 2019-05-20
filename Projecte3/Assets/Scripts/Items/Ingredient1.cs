using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
        duration = 2f;
        nameO = "Ing1";
        itemType = ItemType.Ing;
        ing = ItemUiType.Ing1;
    }
    private void Update()
    {
        if (transform.parent != null && transform.parent.parent == null)
            canvas.gameObject.SetActive(false);
        else
            canvas.gameObject.SetActive(gameObject.activeSelf);
    }
}
