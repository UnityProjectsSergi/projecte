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
                    VialItem vialItem = item.GetComponent<VialItem>();
                       Debug.Log("es vial");
                    //   Crear ordre o mirar si a llist of orders hi ha ordres d'aquest item
                    if (OrderManager.Instance.CheckAllOrder(vialItem))
                    {
                        
                        Debug.Log("Odrer ok");
                    }
                    else
                    {
                        Debug.Log("Order KO");
                    }
                }
                else
                {
                    //ToDo Show Error on Screen Needs a vial

                    Debug.Log("Nees a vial");
                }
            }
        }
    }
}
