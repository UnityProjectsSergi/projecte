using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.ObjPooler;

    //Slot Where player catch ingrredients 
    public class VialSlot : Slot
    { 
        public GameObject itemPrefab;
        private void Start()
        {
            item = VialPool.Instance.GetObjFromPool(transform);
           // item = Instantiate(itemPrefab, positionObjOn.transform.position, Quaternion.identity, positionObjOn.transform);
            hasObjectOn = true;
        }

        public override void Catch(CharacterControllerAct player)
        {
            base.Catch(player);
            item = VialPool.Instance.GetObjFromPool(transform);
           
        //    item = Instantiate(itemPrefab, positionObjOn.transform.position, Quaternion.identity, positionObjOn.transform);
            hasObjectOn = true;
        }
    }

