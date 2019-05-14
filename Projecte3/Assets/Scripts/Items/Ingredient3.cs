using UnityEngine;
using System.Collections;
[System.Serializable]
public class Ingredient3 : Item
{

    // Use this for initialization
 
    public  void Start()
    {

        duration = 5f;
        nameO = "Ing2";
        itemType = ItemType.Ing;
        ing = ItemUiType.Ing2;
    }
    public void SetActiveUI(bool active)
    {
        
    }

    // Update is called once per frame
   
    
}
