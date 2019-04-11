using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.ObjPooler;

public enum StateIngredient
{
    raw,cutting,cutted,initCook,cooked
}
// x fer unna maq esstats
public  class Item : MonoBehaviour
{
    public ItemType itemType;
    public bool isPot;
    public int points;
    public StateIngredient stateIngredient;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        stateIngredient=StateIngredient.raw;
    }
    // Update is called once per frame
    void Update()
    {
      
           
    }
}
