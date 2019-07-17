using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public GameObject start;
   public GameObject end;

   public GameObject enemy;

    public GameObject Enemies;

    public GameObject Menu;

    bool isMenu;
    // Start is called before the first frame update
    void Start()
    {
       start = GameObject.Find("Start");
        end = GameObject.Find("End");

        Enemies = GameObject.Find("Enemies");

        start.GetComponent<Renderer>().enabled = false;




       if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            isMenu = true;
        }





        CorountineStarter();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Menu.SetActive(true);
            }
       

        if(Menu.activeSelf)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
        }else
        {
            Time.timeScale = 1;
        }
    }

    void CorountineStarter()
    {
        if (!isMenu)
        { 
        StartCoroutine(SpawnEnemy());
        } else
        {
            StartCoroutine(SpawnEnemyMenu());
        }
    }


    IEnumerator SpawnEnemy()
    {
        GameObject enemyInstance = Instantiate(enemy, start.transform.position, Quaternion.identity);
        enemyInstance.transform.SetParent(Enemies.transform);
        yield return new WaitForSeconds(3);
        CorountineStarter();
    }

    IEnumerator SpawnEnemyMenu()
    {
      GameObject enemyInstance =  Instantiate(enemy, start.transform.position, Quaternion.identity);
        enemyInstance.transform.SetParent(Enemies.transform);
        yield return new WaitForSeconds(.5f);
        CorountineStarter();
    }


    public void Quit()
    {
        Application.Quit();
    }

}
