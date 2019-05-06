using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum ItemUiType
{
    Ing1,Ing2
}
public enum ItemType
{
    Pot,Vial, Ing
}
public enum ItemPotStateIngredients
{
    Empty, Cooking, CookedDone, Alert, Burning, BurnedToTrash

}
public enum StateIngredient
{
    raw, cutting, cutted, initCook, cooked
}
public enum HabilityType
{
    LevitationItems,SpeedTheFire
}