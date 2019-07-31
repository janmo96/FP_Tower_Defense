using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;




public class LevelCreator : MonoBehaviour
{
    public Terrain terrain;
    public int numberOfEachTree;
    private int currentPlacedObjects;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public List<Pool> treePools;
    public List<Pool> RockPools;


    public GameObject Rocks;
    public GameObject Trees;

    private int terrainWidth;
    private int terrainLength;
    private int terrainPosX;
    private int terrainPosZ;

    void Start()
    {
        // terrain size x
        terrainWidth = (int)terrain.terrainData.size.x;
        // terrain size z
        terrainLength = (int)terrain.terrainData.size.z;
        // terrain x position
        terrainPosX = (int)terrain.transform.position.x;
        // terrain z position
        terrainPosZ = (int)terrain.transform.position.z;



       // SpawnTrees();
    }




    public void GenerateTerrain()
    {
        SpawnTrees();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnTrees();
        }
    }


    public void SpawnTrees()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool treePool in treePools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < treePool.amount; i++)
            {
                int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
                // generate random z position
                int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
                // get the terrain height at the random position
                float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));

                GameObject treeObj = Instantiate(treePool.prefab, new Vector3(posx, posy, posz), Quaternion.Euler(-90, 0, 0));
                if(treeObj.tag == "Rock" || treeObj.tag == "Rock1" || treeObj.tag == "Rock2")
                {
                    treeObj.transform.parent = Rocks.transform;
                } else
                {
                    treeObj.transform.parent = Trees.transform;
                }
                //objectPool.Enqueue(treeObj);
            }

            poolDictionary.Add(treePool.tag, objectPool);
        }
    }
}

[System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int amount;
    }

