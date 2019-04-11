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
                if (item.GetComponent<Ing11>())
                {
                    player.attachedObject = null;
                    item.transform.parent = null;
                    Ing1Pool.Instance.ReturnToPool((Ing11)item);
                }

            }          
        }
    }
}
