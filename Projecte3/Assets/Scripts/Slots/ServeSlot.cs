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
            text = textGO.GetComponent<Text>();
        }
        public GameObject    textGO;
        private Text text;
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
                    bool check = OrderManager.Instance.CheckAllOrder(vialItem);
                    Debug.Log("orderc check" + check);
                    if (check)
                    {

                        StartCoroutine(TextWide(5f, "Order get"));
                    }
                    else
                    {
                        StartCoroutine(TextWide(5f, "Order Wrong"));
                    }
                    vialItem.ResetVial();
                    base.LeaveObjOn(player);
                    VialPool.Instance.ReturnToPool(vialItem);
                }
                else
                {
                    StartCoroutine(TextWide(5f, "Needs a Vial"));
                }
            }
        }
        public IEnumerator TextWide(float num,string textO)
        {
            text.text = textO;
            yield return new WaitForSeconds(num);
            text.text = "";
        }
    }
}
