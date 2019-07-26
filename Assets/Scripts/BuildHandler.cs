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

   public Material originalMatRoof;
    public Material canPlaceMatRoof;
    public Material cantPlaceMatRoof;
    public Material originalMatTower;
    public Material canPlaceMatTower;
    public Material cantPlaceMatTower;
    public Material windowBlack;
    public Material windowFadedBlack;

    Material[] materials;

    GameObject roof;
    GameObject tower;

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
                    if(canBuild) { 

                    currentPlaceableObject = Instantiate(towerPrefab);
                    GameObject towerObj = currentPlaceableObject.transform.GetChild(1).gameObject;
                    roof = towerObj.transform.GetChild(0).gameObject;
                    tower = towerObj.transform.GetChild(1).gameObject;
                   // tower.GetComponent<MeshCollider>().isTrigger = true;
                        roof.GetComponent<Renderer>().material = canPlaceMatRoof;
                    Material[] towerMats = tower.GetComponent<Renderer>().materials;
                    towerMats[0] = canPlaceMatTower;
                    towerMats[1] = windowFadedBlack;

                    tower.GetComponent<Renderer>().materials = towerMats;

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
            GameObject towerObj = currentPlaceableObject.transform.GetChild(1).gameObject;
            roof = towerObj.transform.GetChild(0).gameObject;
            tower = towerObj.transform.GetChild(1).gameObject;
            // tower.GetComponent<MeshCollider>().isTrigger = true;
            roof.GetComponent<Renderer>().material = cantPlaceMatRoof;
            Material[] towerMats = tower.GetComponent<Renderer>().materials;
            towerMats[0] = cantPlaceMatTower;
            towerMats[1] = windowFadedBlack;

            tower.GetComponent<Renderer>().materials = towerMats;
        } else
        {

            GameObject towerObj = currentPlaceableObject.transform.GetChild(1).gameObject;
            roof = towerObj.transform.GetChild(0).gameObject;
            tower = towerObj.transform.GetChild(1).gameObject;
            // tower.GetComponent<MeshCollider>().isTrigger = true;
            roof.GetComponent<Renderer>().material = canPlaceMatRoof;
            Material[] towerMats = tower.GetComponent<Renderer>().materials;
            towerMats[0] = canPlaceMatTower;
            towerMats[1] = windowFadedBlack;

            tower.GetComponent<Renderer>().materials = towerMats;


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
            roof = towerObj.transform.GetChild(0).gameObject;
            tower = towerObj.transform.GetChild(1).gameObject;
                currentPlaceableObject.GetComponent<Collider>().isTrigger = false;
                roof.GetComponent<Renderer>().material = originalMatRoof;
            Material[] towerMats = tower.GetComponent<Renderer>().materials;
            towerMats[0] = originalMatTower;
            towerMats[1] = windowBlack;

            tower.GetComponent<Renderer>().materials = towerMats;
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
