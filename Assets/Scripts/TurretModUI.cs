using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretModUI : MonoBehaviour
{


    public GameObject NodePrefab;
    public GameObject turretUI;


    public int ArcheryTurretCost;


    public bool canClose = false;

    EventSystem system;

    CameraController camC;


    // Start is called before the first frame update
    void Start()
    {
        system = EventSystem.current;

        camC = GameObject.Find("Main Camera").GetComponent<CameraController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!camC.isMobile)
        {
            if (Input.GetMouseButtonDown(0) && !system.IsPointerOverGameObject() && turretUI.activeSelf == true && canClose)
            {
                turretUI.SetActive(false);
                canClose = false;





            }

        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !system.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && turretUI.activeSelf == true && canClose)
        {
            turretUI.SetActive(false);
            canClose = false;

        }



        if (Input.GetMouseButtonDown(1) && turretUI.activeSelf == true)
        {
            turretUI.SetActive(false);
            canClose = false;

        }




    }



    public IEnumerator CanCloseTurretUI()
    {
        yield return new WaitForSeconds(0.5f);
        canClose = true;
    }

    public void SellArcherTurret()
    {
        PlayerStats.money += ArcheryTurretCost / 2;
        Destroy(Turret.selectedTurret);

        GameObject node = Instantiate(NodePrefab, Turret.selectedTurret.transform.position, NodePrefab.transform.rotation);

        turretUI.SetActive(false);
        canClose = false;
    }
}
