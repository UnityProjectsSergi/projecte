using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.ObjPooler;

public class VialSlot : Slot
{ 
    public GameObject itemPrefab;
    public Transform spawnTransform;

    private void Start()
    {
        item = VialPool.Instance.GetObjFromPool(spawnTransform);
        hasObjectOn = true;
    }

    public override void Catch(CharacterControllerAct player)
    {
        base.Catch(player);
        SoundManager.Instance.OneShotEvent("event:/MOVIMIENTO PERSONAJE/COGER/COGER BOTELLA", transform.position);    
        item = VialPool.Instance.GetObjFromPool(spawnTransform);
        hasObjectOn = true;
    }
}

