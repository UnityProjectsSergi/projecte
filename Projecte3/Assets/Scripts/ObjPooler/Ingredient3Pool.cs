using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.ObjPooler;
namespace Assets.Scripts.ObjPooler
{

    // xo el problema q hi veig esq  si l'objectee  item 
   public class Ingredient3Pool:GenericObjectPool<Ingredient3>
    {
        public override void ReturnToPool(Ingredient3 gameObjectReturnPool)
        {
            gameObjectReturnPool.stateIngredient = StateIngredient.raw;
            gameObjectReturnPool.transform.localScale = Vector3.one;
            base.ReturnToPool(gameObjectReturnPool);
        }
    }
}
