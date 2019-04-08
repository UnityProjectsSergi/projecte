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

        private void Update()
        {
            if(item == null)
                item = Instantiate(itemPrefab, transform.position, Quaternion.identity, transform);
        }
    }
}
