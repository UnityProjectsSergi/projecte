using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.ObjPooler;
namespace Assets.Scripts
{
    public  class GarbageSlot:Slot
    {
        public override void LeaveObjOn(CharacterControllerAct player)
        {
            if (!hasObjectOn)
            {
                item = player.attachedObject.GetComponent<Item>();

                if(item.GetType() == typeof(Ingredient2))
                {
                    player.attachedObject = null;
                    item.transform.parent = null;
                    Ingredient2Pool.Instance.ReturnToPool((Ingredient2)item);
                }
                else
                {
                    player.attachedObject = null;
                    item.transform.parent = null;
                    Ing1Pool.Instance.ReturnToPool((Ing11)item);
                }
            }          
        }
    }
}
