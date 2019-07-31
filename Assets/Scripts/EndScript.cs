using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{

    SpawnController spawnController;
    // Start is called before the first frame update
    void Start()
    {
        spawnController = GameObject.Find("EnemySpawner").GetComponent<SpawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.tag != "Player") { 
            spawnController.enemiesAlive--;
            Destroy(col.transform.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        
    }
}
