using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.ObjPooler;
namespace Assets.Scripts.Slots
{
    public  class ServeSlot:Slot
    {

        public override void LeaveObjOn(CharacterControllerAct player)
        {
            if (!hasObjectOn)
            {

                item = player.attachedObject.GetComponent<Item>();

                if (item.itemType==ItemType.Vial)
                {
                    Debug.Log("es vial");
                    //   Crear ordre o mirar si a llist of orders hi ha ordres d'aquest item
                    
                    player.attachedObject = null;
                    item.transform.parent = null;
                    item.GetComponent<VialItem>().ResetVial();
                    VialPool.Instance.ReturnToPool(item.GetComponent<VialItem>());
                }
            }
        }
    }
}
