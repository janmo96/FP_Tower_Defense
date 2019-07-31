using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningScript : MonoBehaviour
{

    public int castDistance;

    public float randomHit;
    public float randomValueResources;

    float treeHealth;

    public bool canMine = true;

    Inventory inventory;
    ItemsRecieved itemsRecieved;

    BuildHandler buildHandler;
    // Start is called before the first frame update
    void Start()
    {
        
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        itemsRecieved = GameObject.Find("GameManager").GetComponent<ItemsRecieved>();
        buildHandler = GameObject.Find("GameManager").GetComponent<BuildHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(buildHandler.currentPlaceableObject == null)
        {
            canMine = true;
        } else
        {
            canMine = false;
        }



        if(Input.GetMouseButtonDown(0))
        {
            if(canMine) { 
            Vector3 origin = transform.position;
            Vector3 direction = transform.forward;

            Debug.DrawRay(origin, direction * 2f, Color.red);

            Ray ray = new Ray(origin,direction);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {

                randomHit = Random.Range(1, 50);
                randomValueResources = Random.Range(0, 5);

                if (hit.collider.gameObject.tag == "Tree1" || hit.collider.gameObject.tag == "Tree2" || hit.collider.gameObject.tag == "Tree3")
                {
                    Debug.Log("ray hit (name): " + hit.collider.gameObject.name);
                    Debug.Log("ray hit (tag): " + hit.collider.gameObject.tag);



 
                    Mathf.RoundToInt(randomHit);
                   hit.collider.gameObject.GetComponent<TreeHealth>().treeHealth -= randomHit;
                   StartCoroutine(itemsRecieved.RecieveText(Mathf.RoundToInt(randomValueResources), "Wood"));
                    inventory.wood += Mathf.RoundToInt(randomValueResources);


                    Debug.Log(hit.collider.transform);
                 }

                if (hit.collider.gameObject.tag == "Rock1" || hit.collider.gameObject.tag == "Rock2" || hit.collider.gameObject.tag == "Rock3" || hit.collider.gameObject.tag == "Rock4")
                {
                    Debug.Log("ray hit (name): " + hit.collider.gameObject.name);
                    Debug.Log("ray hit (tag): " + hit.collider.gameObject.tag);




                    Mathf.RoundToInt(randomHit);
                    hit.collider.gameObject.GetComponent<RockHealth>().rockHealth -= randomHit;
                    StartCoroutine(itemsRecieved.RecieveText(Mathf.RoundToInt(randomValueResources), "Stone"));
                    inventory.stone += Mathf.RoundToInt(randomValueResources);


                    Debug.Log(hit.collider.transform);

                    }
                }
            }
        }


    }
}
