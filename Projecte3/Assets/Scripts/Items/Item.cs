using System.Collections;
using UnityEngine;
using Assets.Scripts.InputSystem;
[System.Serializable]
public  class Item : MonoBehaviour
{
    [Header("Hability variables")]
  
    public bool isHabilityOn;
    public LayerMask layerSlot;
    public bool hasDeacactivateLevitation;
    [Header("Item Variables")]
    public ItemUiType ing;
    public ItemType itemType;
   
    public int points;
    public string nameO;
    public StateIngredient stateIngredient;
    public RigidbodyController rigidbodyController;
    public float duration;
    public float ingCookValue = 0;

    private bool inTable { get { return inTable; } set { } }

    private void OnEnable()
    {       
        stateIngredient=StateIngredient.raw;
    }
    
    public virtual void Catch(CharacterControllerAct player)
    {
        rigidbodyController.ActiveRigidbody(false);
        transform.parent = player.attachTransform;
        transform.position = player.attachTransform.position;
        player.attachedObject = gameObject;    
    }

    public override bool Equals(object other)
    {

        if (!(other is Item))
        {
            Debug.Log("Other is nnull");
            return false;
        }
        var objOther = other as Item;
        Debug.LogWarning(ing != objOther.ing);
        if(GetType()!=objOther.GetType())
       // if (ing!=objOther.ing)
            return false;
        Debug.Log("is same obj");
        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public Item Clone()
    {
        return(Item) this.MemberwiseClone();
    }

    public float percentCooked;

    public IEnumerator Cook()
    {
        float journey = 0f;
        while (journey <= duration)
        {
            Debug.Log("coocking");
            journey += Time.deltaTime;
            percentCooked = Mathf.Clamp01(journey / duration);

            ingCookValue = Mathf.Lerp(0, 1.0f, percentCooked);
            if (ingCookValue > 0.99f)
                stateIngredient = StateIngredient.cooked;

            yield return null;
        }
    }
   
    public  virtual void Update()
    {
        DetectSlotBelow();
    }
    
    public void ActivateDeactivateItemPlayerControler(bool isActive,int controller,PlayerInput playerInput)
    {
        // he fet servir el character controller mod
        isHabilityOn = isActive;
        if (!isActive)
        { 
            hasDeacactivateLevitation = true;
            DetectSlotBelow();
        }
        GetComponent<CharaterControllerItem>().enabled = isActive;
        GetComponent<CharacterController>().enabled = isActive;
        GetComponent<CharaterControllerItem>().playerInput = playerInput;
        GetComponent<CharaterControllerItem>().playercontroller = controller;
        if(playerInput!=null)
        GetComponent<CharaterControllerItem>().setplayerinptu();

    }
    public void DetectSlotBelow()
    {
        if (!isHabilityOn && hasDeacactivateLevitation)
        {
            RaycastHit hit;
            Debug.Log("ssaaaa");
            if (Physics.Raycast(transform.position, -transform.up, out hit, 2f, layerSlot))
            {

                Slot slot = hit.collider.gameObject.GetComponent<Slot>();
                if (slot)
                {
                    if (!slot.hasObjectOn && transform.parent)
                    {

                        slot.LeaveObjOn(transform.parent.parent.GetComponent<CharacterControllerAct>());
                    }
                }
                else
                {
                    Debug.Log("ssssss");
                    if (transform.parent)
                    {
                        transform.parent.parent.GetComponent<CharacterControllerAct>().LeaveObjOn();

                    }
                }
            }
            else
            {
                Debug.Log("sssmsss");
                if (transform.parent)
                {
                    transform.parent.parent.GetComponent<CharacterControllerAct>().LeaveObjOn();

                }
            }
            hasDeacactivateLevitation = false;
        }

    }

}

