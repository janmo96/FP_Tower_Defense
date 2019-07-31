using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHandler : MonoBehaviour
{
    Animator animator;
    

    public GameObject buildPanel;
    bool menuOpen = false;


    [Header("Prefabs")]
    public GameObject towerPrefab;
    [HideInInspector]
    public GameObject currentPlaceableObject;
    Renderer[] renderers;

    //--TowerMatArrays--//

        [Header("Archery Tower")]
        //Archery Tower//
    public Material[] ArcheryTowerMats;
    public Material[] ArcheryTowerTransparentMats;

    [Header("Misc")]
    public int speed;

    public Material[] currentMats;

    CollisionCheck collisionCheck;

  public bool canBuild = true;

    // Start is called before the first frame update
    void Start()
    {
       animator = buildPanel.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {

        if(currentPlaceableObject != null)
        currentMats = currentPlaceableObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().materials;



        if (Input.GetMouseButtonDown(1))
        {
            Destroy(currentPlaceableObject);
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (menuOpen)
            {
                animator.SetBool("MenuOpen", false);
                menuOpen = false;
            } else
            {
                animator.SetBool("MenuOpen", true);
                menuOpen = true;
            }



        }

        if (menuOpen)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (currentPlaceableObject != null)
                {
                    Destroy(currentPlaceableObject);
                } else
                {
                    if (canBuild) {

                        currentPlaceableObject = Instantiate(towerPrefab);
                        GameObject towerObj = currentPlaceableObject.transform.GetChild(0).gameObject;
                        if (currentPlaceableObject.tag == "ArcherTower" && currentPlaceableObject != null)
                        {
                            Material[] mats = towerObj.GetComponent<Renderer>().materials;
                            mats[0] = ArcheryTowerTransparentMats[0];
                            mats[1] = ArcheryTowerTransparentMats[1];
                            mats[2] = ArcheryTowerTransparentMats[2];
                            mats[3] = ArcheryTowerTransparentMats[3];
                            mats[4] = ArcheryTowerTransparentMats[4];

                            towerObj.transform.GetComponent<Renderer>().materials = mats;
                        }
                    } else
                    {
                        GameObject towerObj = currentPlaceableObject.transform.GetChild(0).gameObject;
                        if (currentPlaceableObject.tag == "ArcherTower" && currentPlaceableObject != null)
                        {
                            Material[] mats = towerObj.GetComponent<Renderer>().materials;
                            mats[0] = ArcheryTowerTransparentMats[5];
                            mats[1] = ArcheryTowerTransparentMats[6];
                            mats[2] = ArcheryTowerTransparentMats[7];
                            mats[3] = ArcheryTowerTransparentMats[8];
                            mats[4] = ArcheryTowerTransparentMats[9];

                            towerObj.transform.GetChild(0).GetComponent<Renderer>().materials = mats;
                        }



                    }
                }


            }
        }



        if (currentPlaceableObject != null)
        {
            collisionCheck = currentPlaceableObject.transform.GetChild(0).GetComponent<CollisionCheck>();
            MoveCurrentPrefabToMouse();
            ReleaseIfClicked();
            RotateObject();

            if (collisionCheck.collisions.Count > 0)
            {
                canBuild = false;
            }
            else
            {
                canBuild = true;
            }
       


        if (!canBuild && currentPlaceableObject != null)
        {

                GameObject towerObj = currentPlaceableObject.transform.GetChild(0).gameObject;
                if (currentPlaceableObject.tag == "ArcherTower" && currentPlaceableObject != null)
                {
                    Material[] mats = towerObj.gameObject.GetComponent<Renderer>().materials;
                    mats[0] = ArcheryTowerTransparentMats[5];
                    mats[1] = ArcheryTowerTransparentMats[6];
                    mats[2] = ArcheryTowerTransparentMats[7];
                    mats[3] = ArcheryTowerTransparentMats[8];
                    mats[4] = ArcheryTowerTransparentMats[9];

                    towerObj.transform.GetComponent<Renderer>().materials = mats;
                }


        } else if(canBuild && currentPlaceableObject != null)
        {
                GameObject towerObj = currentPlaceableObject.transform.GetChild(0).gameObject;
                if (currentPlaceableObject.tag == "ArcherTower" && currentPlaceableObject != null)
                {
                    Material[] mats = towerObj.gameObject.GetComponent<Renderer>().materials;
                    mats[0] = ArcheryTowerTransparentMats[0];
                    mats[1] = ArcheryTowerTransparentMats[1];
                    mats[2] = ArcheryTowerTransparentMats[2];
                    mats[3] = ArcheryTowerTransparentMats[3];
                    mats[4] = ArcheryTowerTransparentMats[4];

                    towerObj.transform.GetComponent<Renderer>().materials = mats;
                }
            }
        }
    }


    public void MoveCurrentPrefabToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
           
            if(hitInfo.transform.gameObject.layer == 9 && hitInfo.transform.gameObject.layer != 10 || hitInfo.transform.gameObject.layer != 11) { 
            currentPlaceableObject.transform.position = hitInfo.point;
            //currentPlaceableObject.transform.rotation = Quaternion.identity; //Quaternion.FromToRotation(Vector3.up, hitInfo.normal);


                GameObject towerObj = currentPlaceableObject.transform.GetChild(0).gameObject;



            }
        }

    }



    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(canBuild) { 

            GameObject towerObj = currentPlaceableObject.transform.GetChild(0).gameObject;
                currentPlaceableObject.transform.GetChild(0).GetComponent<Collider>().isTrigger = false;
                currentPlaceableObject.layer = 12;
                /* Rigidbody rb = towerObj.AddComponent<Rigidbody>();
                 rb.useGravity = false;
                 rb.isKinematic = true;
                 */
                if (currentPlaceableObject.tag == "ArcherTower" && currentPlaceableObject != null)
                {
                    Material[] mats = towerObj.gameObject.GetComponent<Renderer>().materials;
                    mats[0] = ArcheryTowerMats[4];
                    mats[1] = ArcheryTowerMats[3];
                    mats[2] = ArcheryTowerMats[0];
                    mats[3] = ArcheryTowerMats[1];
                    mats[4] = ArcheryTowerMats[2];

                    towerObj.transform.GetComponent<Renderer>().materials = mats;

                    currentMats = currentPlaceableObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().materials;

                    towerObj.GetComponent<Turret>().enabled = true;

                }


                currentPlaceableObject = null;

            } else
            {
                collisionCheck = currentPlaceableObject.GetComponent<CollisionCheck>();
                MoveCurrentPrefabToMouse();

            } 
        }
    }

    void RotateObject()
    {
        if(currentPlaceableObject != null)
       currentPlaceableObject.transform.Rotate(Vector3.up * speed * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime);
    }

}
