using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
   public  class GarbageSlot:Slot
    {
        public override void Catch(UnityEngine.Transform _attachTransform, ref GameObject _attachedObject)
        {
            base.Catch(_attachTransform, ref _attachedObject);
        }
    }
}
