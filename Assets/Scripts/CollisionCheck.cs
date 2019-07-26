using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public List<Collider> collisions = new List<Collider>();
    BuildHandler buildHandler;

    // Start is called before the first frame update
    void Start()
    {
        buildHandler = GameObject.Find("GameManager").GetComponent<BuildHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.layer == 10 || col.gameObject.layer == 11 || col.gameObject.layer == 12)
        // if (col.gameObject.tag == "Tree" || col.gameObject.tag == "Tree1" || col.gameObject.tag == "Tree2" || col.gameObject.tag == "Tree3" || col.gameObject.tag == "Rock" || col.gameObject.tag == "Rock1" || col.gameObject.tag == "Rock2" || col.gameObject.tag == "Rock3" || col.gameObject.tag == "Rock4")
        {
            collisions.Add(col);
        }
    }

    public void OnTriggerExit(Collider col)
        {
         if(col.gameObject.layer == 10 || col.gameObject.layer == 11 || col.gameObject.layer == 12)  
        // if (col.gameObject.tag == "Tree" || col.gameObject.tag == "Tree1" || col.gameObject.tag == "Tree2" || col.gameObject.tag == "Tree3" || col.gameObject.tag == "Rock" || col.gameObject.tag == "Rock1" || col.gameObject.tag == "Rock2" || col.gameObject.tag == "Rock3" || col.gameObject.tag == "Rock4")
            {
            collisions.Remove(col);
            }
        }
}
