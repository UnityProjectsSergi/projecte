using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public  class GarbageSlot:Slot
    {
        public override void LeaveObjOn(CharacterControllerAct player)
        {
            Destroy(player.attachedObject);
        }
    }
}
