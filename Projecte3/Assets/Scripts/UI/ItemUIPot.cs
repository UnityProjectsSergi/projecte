using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIPot : MonoBehaviour
{
    public bool showWhenIsEmpty;
    public Sprite DefaultSprite;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }
    public void setDefault()
    {
        if (showWhenIsEmpty)
            image.sprite = DefaultSprite;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSpriteFromImgredient(Material material)
    {
        image.material = material;
    }
    public void SetSpriteFromImgredient(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
