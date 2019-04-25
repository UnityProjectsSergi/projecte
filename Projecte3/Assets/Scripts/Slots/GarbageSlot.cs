using Assets.Scripts.ObjPooler;
using UnityEngine;

namespace Assets.Scripts
{
    public  class GarbageSlot:Slot
    {
        public override void LeaveObjOn(CharacterControllerAct player)
        {
            if (!hasObjectOn)
            {
                item = player.attachedObject.GetComponent<Item>();
                if (item.itemType == ItemType.Ing)
                {
                    if (item.GetType() == typeof(Ingredient2))
                    {
                        player.attachedObject = null;
                        item.transform.parent = null;
                        item.transform.localScale = new Vector3(0.85f,0.85f,0.85f);
                        Ingredient2Pool.Instance.ReturnToPool((Ingredient2)item);
                    }
                    else
                    {
                        player.attachedObject = null;
                        item.transform.parent = null;
                        item.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
                        Ing1Pool.Instance.ReturnToPool((Ing11)item);
                    }
                }
                else if(item.itemType==ItemType.Pot)
                {
                    ItemPot itemPot = item.GetComponent<ItemPot>();
                    itemPot.ResetPot();
                }
            }          
        }
    }
}
