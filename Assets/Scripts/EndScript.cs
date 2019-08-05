using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{

    SpawnController spawnController;
    // Start is called before the first frame update
    void Awake()
    {
        spawnController = GameObject.Find("EnemySpawner").GetComponent<SpawnController>();
    }


    void Start()
    {
        spawnController = GameObject.Find("EnemySpawner").GetComponent<SpawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnController == null)
        {
            spawnController = GameObject.Find("EnemySpawner").GetComponent<SpawnController>();
        }
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Player")
        { 
            spawnController.enemiesAlive--;
            Destroy(col.transform.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        
    }
}
