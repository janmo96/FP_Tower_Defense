using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{

    public static Transform buildpos;
    public static GameObject selectedGameobject;


    Vector3 positionOffset;
    GameObject GameManager;
    GameObject turretsToBuild;


    public Material originalMat;
    public Material editingMat;

    // Start is called before the first frame update
    void Start()
    {
        GameObject flag = this.transform.Find("Plane001").gameObject;
        Renderer fRend = flag.GetComponent<Renderer>();

        originalMat = fRend.material;



        GameManager = GameObject.Find("GameManager");
        turretsToBuild = GameManager.GetComponent<TurretSelector>().turretsToBuild;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        buildpos = this.gameObject.transform;
       // turretsToBuild.transform.position = Input.mousePosition;
        selectedGameobject = this.gameObject;

        GameObject flag = selectedGameobject.transform.Find("Plane001").gameObject;
        Renderer fRend = flag.GetComponent<Renderer>();

        originalMat = fRend.material;

        fRend.material = editingMat;

            


        turretsToBuild.SetActive(true);


        StartCoroutine(GameObject.Find("GameManager").GetComponent<TurretSelector>().CanClose());


    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (turretsToBuild.activeSelf)
            {
               GameObject.Find("GameManager").GetComponent<TurretSelector>().canClose = false;
                turretsToBuild.SetActive(false);
                selectedGameobject.transform.Find("Plane001").gameObject.GetComponent<Renderer>().material = originalMat;

            }
        }
    }






    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;



    }

    void OnMouseExit()
    {
        
    }

}


