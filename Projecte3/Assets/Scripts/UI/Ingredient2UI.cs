using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ingredient2UI : ItemUI
{
    public Color color;
    // Use this for initialization
    public  void Start()
    {
        //base.Start();
       // image.color = color;
        itemUiType = ItemUiType.Ing2;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
