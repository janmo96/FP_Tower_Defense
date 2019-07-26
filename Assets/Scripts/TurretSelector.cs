using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretSelector : MonoBehaviour
{

    public GameObject turretsToBuild;
    bool mouseOnObject;

    public TurretBlueprint StandartTurret;
    public TurretBlueprint AdvancedTurret;

    public bool canClose = false;

    public Vector3 offset;

    GameObject standardTurret;


    [SerializeField]Material originalMat;

    TurretModUI turretModUI;



    EventSystem system;

    CameraController camC;

    // Start is called before the first frame update
    void Start()
    {

        turretModUI = GameObject.Find("GameManager").GetComponent<TurretModUI>();




        system = EventSystem.current;

        camC = GameObject.Find("Main Camera").GetComponent<CameraController>();


    }

    void SelectedGameObjectMatChanger()
    {
        GameObject flag = Node.selectedGameobject.transform.Find("Plane001").gameObject;
        Renderer fRend = flag.GetComponent<Renderer>();

        fRend.material = originalMat;
    }

  
   public IEnumerator CanClose()
    {
        yield return new WaitForSeconds(0.5f);
        canClose = true;
    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0) && !system.IsPointerOverGameObject() && turretsToBuild.activeSelf == true && canClose)
        {
           turretsToBuild.SetActive(false);
           canClose = false;
           SelectedGameObjectMatChanger();




        }



    }

    void OnMouseEnter()
    {
        print("Enter");
    }


    void OnMouseExit()
    {
        print("Exit");
    }

    public void BuildStandardTurret()
    {
        Destroy(Node.selectedGameobject);
        standardTurret = (GameObject)Instantiate(StandartTurret.prefab, Node.buildpos.position + offset, Quaternion.identity);
        turretsToBuild.SetActive(false);
        canClose = false;
        SelectedGameObjectMatChanger();
        PlayerStats.money -= turretModUI.ArcheryTurretCost;

    }
    public void Close()
    {
        if(canClose) { 
            canClose = false;
        turretsToBuild.SetActive(false);
            SelectedGameObjectMatChanger();

        }
    }


}
