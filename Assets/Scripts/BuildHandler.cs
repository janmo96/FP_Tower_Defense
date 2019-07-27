using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHandler : MonoBehaviour
{
    Animator animator;
    

    public GameObject buildPanel;
    bool menuOpen = false;

    public GameObject towerPrefab;
    [HideInInspector]
    public GameObject currentPlaceableObject;
    Renderer[] renderers;

    //--TowerMatArrays--//

        [Header("Archery Tower")]
        //Archery Tower//
    public Material[] ArcheryTowerMats;
    public Material[] ArcheryTowerTransparentMats;

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
                        GameObject towerObj = currentPlaceableObject;
                        if (currentPlaceableObject.name == "ArcheryTower") {
                            Material[] mats = towerObj.GetComponent<Renderer>().materials;
                            mats[0] = ArcheryTowerTransparentMats[0];
                            mats[1] = ArcheryTowerTransparentMats[1];
                            mats[2] = ArcheryTowerTransparentMats[2];
                            mats[3] = ArcheryTowerTransparentMats[3];
                            mats[4] = ArcheryTowerTransparentMats[4];


                        }
                    } else
                    {
                        GameObject towerObj = currentPlaceableObject;
                        if (currentPlaceableObject.name == "ArcheryTower")
                        {
                            Material[] mats = towerObj.GetComponent<Renderer>().materials;
                            mats[0] = ArcheryTowerTransparentMats[5];
                            mats[1] = ArcheryTowerTransparentMats[6];
                            mats[2] = ArcheryTowerTransparentMats[7];
                            mats[3] = ArcheryTowerTransparentMats[8];
                            mats[4] = ArcheryTowerTransparentMats[9];

                            towerObj.GetComponent<Renderer>().materials = mats;
                        }



                    }
                }


            }
        }



        if (currentPlaceableObject != null)
        {
            collisionCheck = currentPlaceableObject.GetComponent<CollisionCheck>();
            MoveCurrentPrefabToMouse();
            ReleaseIfClicked();

            if (collisionCheck.collisions.Count > 0)
            {
                canBuild = false;
            }
            else
            {
                canBuild = true;
            }
       


        if (!canBuild)
        {

                GameObject towerObj = currentPlaceableObject;
                if (currentPlaceableObject.name == "ArcheryTower")
                {
                    Material[] mats = towerObj.GetComponent<Renderer>().materials;
                    mats[0] = ArcheryTowerTransparentMats[5];
                    mats[1] = ArcheryTowerTransparentMats[6];
                    mats[2] = ArcheryTowerTransparentMats[7];
                    mats[3] = ArcheryTowerTransparentMats[8];
                    mats[4] = ArcheryTowerTransparentMats[9];

                    towerObj.GetComponent<Renderer>().materials = mats;
                }


        } else
        {
                GameObject towerObj = currentPlaceableObject;
                if (currentPlaceableObject.name == "ArcheryTower")
                {
                    Material[] mats = towerObj.GetComponent<Renderer>().materials;
                    mats[0] = ArcheryTowerTransparentMats[0];
                    mats[1] = ArcheryTowerTransparentMats[1];
                    mats[2] = ArcheryTowerTransparentMats[2];
                    mats[3] = ArcheryTowerTransparentMats[3];
                    mats[4] = ArcheryTowerTransparentMats[4];


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
            currentPlaceableObject.transform.rotation = Quaternion.identity; //Quaternion.FromToRotation(Vector3.up, hitInfo.normal);


                GameObject towerObj = currentPlaceableObject.transform.GetChild(1).gameObject;



            }
        }

    }



    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(canBuild) { 

            GameObject towerObj = currentPlaceableObject.transform.GetChild(1).gameObject;
                currentPlaceableObject.GetComponent<Collider>().isTrigger = false;
                currentPlaceableObject.layer = 12;
               /* Rigidbody rb = towerObj.AddComponent<Rigidbody>();
                rb.useGravity = false;
                rb.isKinematic = true;
                */


            currentPlaceableObject = null;
            } else
            {
                collisionCheck = currentPlaceableObject.GetComponent<CollisionCheck>();
                MoveCurrentPrefabToMouse();

            } 
        }
    }


}
