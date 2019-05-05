using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.InputSystem;
public class HabilityesController : MonoBehaviour
{
    public HabilityType habilityType;
    public Hability hability;
    public CharacterControllerAct CharacterControllerAct;
    // Start is called before the first frame update
    void Start()
    {
        hability = gameObject.AddComponent<Hability>();
        if (habilityType == HabilityType.LevitationItems)
            hability.set(3, 4, ActivateLevitation, DeactivateLevitation);
        else if (habilityType == HabilityType.SpeedTheFire)
            hability.set(3, 4, ActivateHabilitySpeedFire, DeactivateHabilitySpeedFire);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivateLevitation()
    {
       CharacterControllerAct. attachedObject.GetComponent<Item>().ActivateDeactivateItemPlayerControler(true, GetComponent<Character>().playercontroller, GetComponent<PlayerInput>());
        GetComponent<CharacterController>().enabled = false;

        GetComponent<Character>().enabled = false;
    }
    public void DeactivateLevitation()
    {
        CharacterControllerAct. attachedObject.GetComponent<Item>().ActivateDeactivateItemPlayerControler(false, 0, null);
        GetComponent<CharacterController>().enabled = true;
        GetComponent<Character>().enabled = true;
    }
    public void ActivateHabilitySpeedFire()
    {

    }
    public void DeactivateHabilitySpeedFire()
    {

    }
}
