using UnityEngine;
using System.Collections;

public class Ingredient1UI : ItemUI
{
    public Color color;
    public Sprite Ing1Sripte;

    // Use this for initialization
    public  void Start()
    {
        image.sprite = Ing1Sripte;
        // image.color = color;
        itemUiType = ItemUiType.Ing1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
