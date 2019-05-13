using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCollider : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        SpawnPositions = GetComponentsInChildren<Transform>();
    }
    public Transform[] SpawnPositions;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Character>())
        {
            other.gameObject.SetActive(false);
            int num = Random.Range(0, SpawnPositions.Length);
            //TODO Effect of respawn with GameObject of Arry SpawnPosition[num] and call next methodth in other object
            other.GetComponent<RespawnPlayerCharacter>().Respawn(SpawnPositions[num]);
        }
    }
}
