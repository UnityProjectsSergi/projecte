using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class CuttingSlot : Slot
    { 
    public override void LeaveObjOn(CharacterControllerAct player)
    {
        Item i = player.attachedObject.GetComponent<Item>();
        base.LeaveObjOn(player);
        if (i.itemType == ItemType.Ing)
            item.stateIngredient = StateIngredient.cutting;

    }
    public override void Catch(CharacterControllerAct player)
    { 
      
      if(item.stateIngredient == StateIngredient.cutted)
        base.Catch(player);
        
    }
}
