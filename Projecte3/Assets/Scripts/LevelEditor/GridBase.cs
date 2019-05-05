using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBase : MonoBehaviour
{
    public GameObject nodePrefab;
    GameObject floor;

    public int sizeX;
    public int sizeZ;
    public int offset = 1;

    public Node[,] grid;

    private static GridBase instance = null;

    public static GridBase GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
        CreateMouseCollision();
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Node[sizeX, sizeZ];

        for(int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                float posX = x * offset;
                float posZ = z * offset;

                GameObject go = Instantiate(nodePrefab, new Vector3(posX - 0.5f, 1, posZ - 0.5f), Quaternion.Euler(new Vector3(90, 0, 0))) as GameObject;
                go.transform.parent = floor.transform;

                NodeObject nodeObj = go.GetComponent<NodeObject>();
                nodeObj.posX = x;
                nodeObj.posZ = z;

                Node node = new Node();
                node.vis = go;
                node.tileRenderer = node.vis.GetComponentInChildren<MeshRenderer>();
                node.isWalkable = true;
                node.nodePosX = x;
                node.nodePosZ = z;
                grid[x, z] = node;
            }
        }
    }

    void CreateMouseCollision()
    {
        floor = new GameObject();
        //floor.AddComponent<BoxCollider>();
        //floor.GetComponent<BoxCollider>().size = new Vector3(sizeX * offset, 0.1f, sizeZ * offset);
        floor.transform.position = new Vector3((sizeX * offset) / 2 - 1, 1, (sizeZ * offset) / 2 - 1);
        floor.name = "Floor";
    }

    public Node NodeFromWorldPosition(Vector3 worldPosition)
    {
        float worldX = worldPosition.x;
        float worldZ = worldPosition.z;

        worldX /= offset;
        worldZ /= offset;

        int x = Mathf.RoundToInt(worldX);
        int z = Mathf.RoundToInt(worldZ);

        if (x > sizeX)
            x = sizeX;
        if (z > sizeZ)
            z = sizeZ;
        if (x < 0)
            x = 0;
        if (z < 0)
            z = 0;

        return grid[x, z];

        return new Node();
    }
}
