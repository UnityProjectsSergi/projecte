using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ingredient2UI : ItemUI
{
    public Color color;
    public Sprite Ing2Sripte;

    // Use this for initialization
    public  void Start()
    {
        image.sprite = Ing2Sripte;
        //base.Start();
        // image.color = color;
        itemUiType = ItemUiType.Ing2;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
