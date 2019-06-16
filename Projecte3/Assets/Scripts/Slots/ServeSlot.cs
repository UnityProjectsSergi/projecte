using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.ObjPooler;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts.Slots
{
    public  class ServeSlot:Slot
    {
       

        public void Start()
        {
          
        }

        public override void LeaveObjOn(CharacterControllerAct player)
        {
            if (!hasObjectOn)
            {

                item = player.attachedObject.GetComponent<Item>();

                if (item.itemType==ItemType.Vial)
                {
                    VialItem vialItem = item.GetComponent<VialItem>();
                    
                    //   Crear ordre o mirar si a llist of orders hi ha ordres d'aquest item
                    bool check = OrderManagerEric.Instance.CheckAllOrder(vialItem);
                 
                    if (check)
                    {
                        Debug.Log("SSSSS VLID");
                        FloatingText.Show("Order Get", "OrderOK", new FromWorldPointTextPositioner(Camera.main, new Vector3(transform.position.x,transform.position.y+1,transform.position.z),0.5f,20f));
                       // StartCoroutine(TextWide(5f, "Order get"));
                    }
                    else
                    {
                        Debug.Log("SSSS NOT");
                        FloatingText.Show("Order Wrong", "OrderKO", new FromWorldPointTextPositioner(Camera.main, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), 0.5f, 20f));
                    //    StartCoroutine(TextWide(5f, "Order Wrong"));
                    }
                    vialItem.ResetVial();
                    base.LeaveObjOn(player);
                    vialItem.ResetMaterial();
                    VialPool.Instance.ReturnToPool(vialItem);
                    hasObjectOn = false;
                }
                else
                {
                    FloatingText.Show("Needs A Vial", "OrderKO", new FromWorldPointTextPositioner(Camera.main, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), 0.5f, 20f));
                //    StartCoroutine(TextWide(5f, "Needs a Vial"));
                }
            }
        }
     
    }
}
