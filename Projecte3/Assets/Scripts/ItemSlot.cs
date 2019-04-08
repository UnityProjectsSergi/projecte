using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class ItemSlot : Slot
    {
        public GameObject itemPrefab;

        private void Start()
        {
            item = Instantiate(itemPrefab, positionObjOn.transform.position, Quaternion.identity, positionObjOn.transform);
            hasObjectOn = true;
        }

        public override void Catch(CharacterControllerAct player)
        {
            base.Catch(player);
            item = Instantiate(itemPrefab, positionObjOn.transform.position, Quaternion.identity, positionObjOn.transform);
            hasObjectOn = true;
        }
    }
}
