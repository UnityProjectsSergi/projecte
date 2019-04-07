using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    public abstract class Slot :MonoBehaviour
    {
        public bool isActive;
        public bool hasObjectOn;
        public GameObject objectOn;
        public Transform positionObjOn; 
        public void CatchObjOn(Player player)
        {
            
        }
        public void LeaveObjOn(Player player)
        {
            
        }
    }

