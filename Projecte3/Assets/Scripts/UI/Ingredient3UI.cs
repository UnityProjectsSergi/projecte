using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ingredient3UI : ItemUI
{
    public Color color;

    public Sprite Ing3Sripte;

    // Use this for initialization
    public  void Start()
    {
        image.sprite = Ing3Sripte;
        itemUiType = ItemUiType.Ing2;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
