using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAttachPoint : MonoBehaviour
{
    public Transform parent;
    void Start()
    {
        this.transform.parent.gameObject.GetComponent<CharacterControllerAct>().attachTransform.parent = parent;
    }
}
