using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIPot : MonoBehaviour
{
    public bool showWhenIsEmpty;
    public Sprite DefaultSprite;
    public Color defaultColor;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }
    
    public void setDefaultColor()
    {

    }

    public void setDefault()
    {
        if (showWhenIsEmpty)
            image.color = defaultColor;
        //image.sprite = DefaultSprite;
    }
    // Update is called once per frame

    public void SetSpriteFromImgredient(Material material)
    {
        image.color = material.color;
    }

    public void SetSpriteFromImgredient(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
