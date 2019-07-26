using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform target;
    int wavepointIndex = 0;

    public float startSpeed = 10f;

    public float startHealth = 100;
    private float health;

    public int worth = 50;

    public GameObject deathEffect;
    public float speed;

    public GameObject end;

    public bool isMenu = false;

    private bool isDead = false;


    SpawnController spawnController;

    NavMeshAgent agent;
    Rigidbody rb;

    bool startingPassed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        speed = startSpeed;
        health = startHealth;

        end = GameObject.FindGameObjectWithTag("End");

        agent.updateRotation = true;
        agent.updatePosition = true;

        spawnController = GameObject.Find("EnemySpawner").GetComponent<SpawnController>();

        StartCoroutine(StartingCount());

        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            isMenu = true;
        }

    }

    IEnumerator StartingCount()
    {
        yield return new WaitForSeconds(2);
        agent.enabled = true;
        yield return new WaitForSeconds(20);
        startingPassed = true;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        //healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }


    // Update is called once per frame
    void Update()
    {


        if(agent.isOnNavMesh)
        {
            agent.enabled = true;
        }


        if(agent.enabled)

        { 


        agent.SetDestination(end.transform.position);

        float dist = agent.remainingDistance;
      /*      if (startingPassed)
            {
                if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance <= 1 && startingPassed)
        {
            EndPath();
        }
            }*/
        }
        

        /*   float step = speed * Time.deltaTime;

           Vector3 newDir = Vector3.RotateTowards(transform.forward, target.position, step, 0.0f);

            Quaternion q = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 5.0f * Time.deltaTime);

           //transform.LookAt(target);
           */
    }

    private void FixedUpdate()
    {
      //  rb.MovePosition(target.position);
    }



    void EndPath()
    {
        spawnController.enemiesAlive--;
        Destroy(this.gameObject);
    }

    void Die()
    {
        spawnController.enemiesAlive--;
        isDead = true;
        PlayerStats.money += 50;

       // PlayerStats.Money += worth;

       // GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        //WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

}
