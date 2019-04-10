using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Slots
{
    public  class ServeSlot:Slot
    {

        public override void LeaveObjOn(CharacterControllerAct player)
        {
            if (!hasObjectOn)
            {

                item = player.attachedObject.GetComponent<Item>();

                if (!item.GetComponent<Ing11>())
                {
                    player.attachedObject = null;
                    item.transform.parent = null;
                    //   Crear ordre o mirar si a llist of orders hi ha ordres d'aquest item
                    OrderManager.Instance.CheckAllOrder(item);

                   // Ing1GenPool.Instance.ReturnToPool(item);
                }
            }
        }
    }
}
