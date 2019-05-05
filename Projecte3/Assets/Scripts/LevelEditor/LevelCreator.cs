using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor
{
    public class LevelCreator : MonoBehaviour
    {
        LevelManager manager;
        GridBase gridBase;
        InterfaceManager ui;
        public LayerMask layer;

        bool hasObj;
        GameObject objToPlace;
        GameObject cloneObj;
        LevelObject objProperties;
        Vector3 mousePosition;
        Vector3 worldPosition;
        bool deleteObj;

        bool hasMaterial;
        bool paintTile;
        public Material matToPlace;
        Node previousNode;
        Material prevMaterial;
        Quaternion targetRot;
        Quaternion prevRotation;

        bool placeStackObj;
        GameObject stackObjToPlace;
        GameObject stackCloneObj;
        LevelObject stackObjProperties;
        bool deleteStackObj;

        bool createWall;
        public GameObject wallPrefab;
        Node startNode_Wall;
        Node endNodeWall;
        public Material[] wallPlacementMaterial;
        bool deleteWall;

        private void Start()
        {
            gridBase = GridBase.GetInstance();
            manager = LevelManager.GetInstance();
            ui = InterfaceManager.GetInstance();

            PaintAll();
        }

        private void Update()
        {
            PlaceObject();
            PaintTile();
            DeleteObjs();
            PlaceStackedObj();
            //CreateWall();
            DeleteStackedObjs();
            //DeleteWallsActual();
            UpdateMousePosition();
        }

        void UpdateMousePosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
            {
                mousePosition = hit.point;
                gridBase.NodeFromWorldPosition(hit.transform.position);
            }
        }

        #region Tile Painting
        void PaintTile()
        {
            if(hasMaterial)
            {
                UpdateMousePosition();

                Node curNode = gridBase.NodeFromWorldPosition(mousePosition);

                if(previousNode == null)
                {
                    previousNode = curNode;
                    prevMaterial = previousNode.tileRenderer.material;
                    prevRotation = previousNode.vis.transform.rotation;
                }
                else
                {
                    if(previousNode != curNode)
                    {
                        if(paintTile)
                        {
                            int matId = ResourceManager.GetInstance().GetMaterial(matToPlace);
                            curNode.vis.GetComponent<NodeObject>().textureid = matId;
                            paintTile = false;
                        }
                        else
                        {
                            previousNode.tileRenderer.material = prevMaterial;
                            previousNode.vis.transform.rotation = prevRotation;
                        }

                        previousNode = curNode;
                        prevMaterial = curNode.tileRenderer.material;
                        prevRotation = curNode.vis.transform.rotation;
                    }
                }

                curNode.tileRenderer.material = matToPlace;
                curNode.vis.transform.localRotation = targetRot;

                if(Input.GetMouseButton(0) && !ui.mouseOverUIElement)
                {
                    paintTile = true;
                }

                if(Input.GetMouseButtonUp(1))
                {
                    Vector3 eulerAngles = curNode.vis.transform.eulerAngles;
                    eulerAngles += new Vector3(0, 90, 0);
                }
            }
        }

        public void PassMaterialToPaint(int matId)
        {
            deleteObj = false;
            placeStackObj = false;
            hasObj = false;
            matToPlace = ResourceManager.GetInstance().GetMaterial(matId);
            hasMaterial = true;
        }
        
        public void PaintAll()
        {
            for(int x = 0; x < gridBase.sizeX; x++)
            {
                for(int z = 0; z < gridBase.sizeZ; z++)
                {
                    gridBase.grid[x, z].tileRenderer.material = matToPlace;
                    int matId = ResourceManager.GetInstance().GetMaterial(matToPlace);
                    gridBase.grid[x, z].vis.GetComponent<NodeObject>().textureid = matId;
                }
            }

            previousNode = null;
        }
        #endregion

        void PlaceObject()
        {
            if (hasObj)
            {
                UpdateMousePosition();

                Node curNode = gridBase.NodeFromWorldPosition(mousePosition);

                worldPosition = curNode.vis.transform.position;

                if (cloneObj == null)
                {
                    cloneObj = Instantiate(objToPlace, worldPosition, Quaternion.identity) as GameObject;
                    objProperties = cloneObj.GetComponent<LevelObject>();
                }
                else
                {
                    cloneObj.transform.position = worldPosition;

                    if (Input.GetMouseButton(0) && !ui.mouseOverUIElement)
                    {
                        if (curNode.placedObj != null)
                        {
                            manager.inSceneGameObjects.Remove(curNode.placedObj.gameObject);
                            Destroy(curNode.placedObj.gameObject);
                            curNode.placedObj = null;
                        }

                        GameObject actualObjPlaced = Instantiate(objToPlace, worldPosition, cloneObj.transform.rotation);
                        LevelObject placedObjProperties = actualObjPlaced.GetComponent<LevelObject>();

                        placedObjProperties.gridPosX = curNode.nodePosX;
                        placedObjProperties.gridPosZ = curNode.nodePosZ;
                        curNode.placedObj = placedObjProperties;
                        manager.inSceneGameObjects.Add(actualObjPlaced);
                    }

                    if (Input.GetMouseButtonUp(1))
                    {
                        objProperties.ChangeRotation();
                    }
                }
            }
        }

        public void PassGameObjectToPlace(string objId)
        {
            if (cloneObj != null)
            {
                Destroy(cloneObj);
            }

            CloseAll();
            hasObj = true;
            cloneObj = null;
            objToPlace = ResourceManager.GetInstance().GetObjBase(objId).objPrefab;
        }

        void DeleteObjs()
        {
            if (deleteObj)
            {
                UpdateMousePosition();

                Node curNode = gridBase.NodeFromWorldPosition(mousePosition);

                if (Input.GetMouseButton(0) && !ui.mouseOverUIElement)
                {
                    if (curNode.placedObj != null)
                    {
                        if (manager.inSceneGameObjects.Contains(curNode.placedObj.gameObject))
                        {
                            manager.inSceneGameObjects.Remove(curNode.placedObj.gameObject);
                            Destroy(curNode.placedObj.gameObject);
                        }

                        curNode.placedObj = null;
                    }
                }
            }
        }

        public void PassStackedObjectToPlace(string objId)
        {
            if (stackCloneObj != null)
            {
                Destroy(stackCloneObj);
            }

            CloseAll();
            placeStackObj = true;
            stackCloneObj = null;
            stackObjToPlace = ResourceManager.GetInstance().GetStackObjBase(objId).objPrefab;
        }

        void PlaceStackedObj()
        {
            if (placeStackObj)
            {
                UpdateMousePosition();

                Node curNode = gridBase.NodeFromWorldPosition(mousePosition);

                worldPosition = curNode.vis.transform.position;

                if (stackCloneObj == null)
                {
                    stackCloneObj = Instantiate(stackObjToPlace, worldPosition, Quaternion.identity) as GameObject;
                    stackObjProperties = stackCloneObj.GetComponent<LevelObject>();
                }
                else
                {
                    stackCloneObj.transform.position = worldPosition;

                    if (Input.GetMouseButtonUp(0) && !ui.mouseOverUIElement)
                    {
                        GameObject actualObjPlaced = Instantiate(stackObjToPlace, worldPosition, stackCloneObj.transform.rotation) as GameObject;
                        LevelObject placedObjProperties = actualObjPlaced.GetComponent<LevelObject>();

                        placedObjProperties.gridPosX = curNode.nodePosX;
                        placedObjProperties.gridPosZ = curNode.nodePosZ;
                        curNode.stackedObjs.Add(placedObjProperties);
                        manager.inSceneStackObjects.Add(actualObjPlaced);
                    }

                    if (Input.GetMouseButtonUp(1))
                    {
                        stackObjProperties.ChangeRotation();
                    }
                }
            }
            else
            {
                if (stackCloneObj != null)
                {
                    Destroy(stackCloneObj);
                }
            }
        }

        public void DeletStackObj()
        {
            CloseAll();
            deleteStackObj = true;
        }

        void DeleteStackedObjs()
        {
            if (deleteStackObj)
            {
                UpdateMousePosition();

                Node curNode = gridBase.NodeFromWorldPosition(mousePosition);

                if (Input.GetMouseButton(0) && !ui.mouseOverUIElement)
                {
                    if (curNode.stackedObjs.Count > 0)
                    {
                        for (int i = 0; i < curNode.stackedObjs.Count; i++)
                        {
                            if (manager.inSceneStackObjects.Contains(curNode.stackedObjs[i].gameObject))
                            {
                                manager.inSceneStackObjects.Remove(curNode.stackedObjs[i].gameObject);
                                Destroy(curNode.stackedObjs[i].gameObject); ;
                            }
                        }
                        curNode.stackedObjs.Clear();
                    }
                }
            }
        }

        void CloseAll()
        {
            hasObj = false;
            deleteObj = false;
            paintTile = false;
            placeStackObj = false;
            createWall = false;
            hasMaterial = false;
            deleteStackObj = false;
            deleteWall = false;
        }
    }
}