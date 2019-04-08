using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    public abstract class Slot :MonoBehaviour
    {
        protected GameObject item;
        public Transform positionObjOn;

        public bool isActive;
        public bool hasObjectOn;
        public bool objectOn;

        public virtual void Catch(Transform _attachTransform, ref GameObject _attachedObject)
        {
            if (item != null)
            {
                item.transform.parent = _attachTransform.transform;
                item.transform.position = _attachTransform.position;
                _attachedObject = item;
                item = null;
            }

        }
        public virtual void Update()
        {
            
        }

     
    }

