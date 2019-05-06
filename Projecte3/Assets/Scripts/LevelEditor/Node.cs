using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int nodePosX;
    public int nodePosZ;
    public GameObject vis;
    public MeshRenderer tileRenderer;
    public bool isWalkable;
    public LevelEditor.LevelObject placedObj;
    public List<LevelEditor.LevelObject> stackedObjs = new List<LevelEditor.LevelObject>();
    public LevelEditor.Level_WallObj wallObj;
}
