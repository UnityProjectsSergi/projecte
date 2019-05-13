using System;
using UnityEngine;
public class RespawnPlayerCharacter : MonoBehaviour
{
    public void Start()
    {
        
    }
    internal void Respawn(Transform SpawnTransform)
    {
        transform.position= SpawnTransform.transform.position;
        transform.rotation = SpawnTransform.transform.rotation;
        gameObject.SetActive(true);
    }
}