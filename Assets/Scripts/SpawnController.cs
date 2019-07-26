using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    public Vector3 pos;

    public Waves[] spawningWavesArray;
    int waveArrayIndex = 0;
    int enemytypeArrayIndex = 0;

    bool canSpawn = false;

    public int enemiesAlive;
    // Start is called before the first frame update
    void Awake()
    {
    }

    void Start()
    {

        pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 1, (Random.Range(-size.z / 2, size.z / 2)));
        StartCoroutine(spawner(spawningWavesArray[waveArrayIndex].eachEnemyAmount));
    }

    IEnumerator spawner(int number)
    {
        int i = 0;
        while(i < number)
        {
            pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 1, (Random.Range(-size.z / 2, size.z / 2)));
            Instantiate(spawningWavesArray[waveArrayIndex].enemyTypes[enemytypeArrayIndex], pos, Quaternion.identity);
            enemiesAlive++;
            i++;
        }
        
        yield return 0;
        i = 0;





        

    }
    // Update is called once per frame
    void Update()
    {
        pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 1, (Random.Range(-size.z / 2, size.z / 2)));

        if(enemiesAlive <= 0)
        {
            canSpawn = true;
        } else
        {
            canSpawn = false;
        }


        if (canSpawn)
        {
            canSpawn = false;
            waveArrayIndex++;
            
            StartCoroutine(spawner(spawningWavesArray[waveArrayIndex].eachEnemyAmount));
        }

    }

    public void SpawnEnenmy()
    {
       

        
    }

    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);

    }
}

[System.Serializable]
public class Waves
{
    public GameObject[] enemyTypes;
    public int eachEnemyAmount;
}

