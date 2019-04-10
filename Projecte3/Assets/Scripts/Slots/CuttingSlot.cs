using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class CuttingSlot : Slot
    { 
    public override void LeaveObjOn(CharacterControllerAct player)
    {
       
        base.LeaveObjOn(player);
        item.stateIngredient = StateIngredient.cutting;

    }
    public override void Catch(CharacterControllerAct player)
    { 
        item.stateIngredient = StateIngredient.cutted;
        base.Catch(player);
        
    }
}
