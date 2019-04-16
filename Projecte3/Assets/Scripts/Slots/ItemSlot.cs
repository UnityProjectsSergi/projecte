using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.ObjPooler;

    //Slot Where player catch ingrredients 
    public class ItemSlot : Slot
    { 
        public GameObject itemPrefab;
        
        public virtual void Start()
        { 
            hasObjectOn = true;
        }

        public override void Catch(CharacterControllerAct player)
        {
            base.Catch(player);
            hasObjectOn = true;
        }
    }

