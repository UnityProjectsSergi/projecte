using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    //Slot Where player catch ingrredients 
    public class ItemSlot : Slot
    { 
        public GameObject itemPrefab;

        public override void Catch(Transform _attachTransform, ref GameObject _attachedObject)
        {
            base.Catch(_attachTransform, ref _attachedObject);
        }

        public override void Update()
        {
            if(item == null)
                item = Instantiate(itemPrefab, transform.position, Quaternion.identity, transform);
        }
    }
}
