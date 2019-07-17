using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour
{

    public float treeHealth;

    public GameObject oakTree;
    public GameObject palmTree;
    public GameObject poplarTree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(treeHealth <= 0 )
        {
            if(gameObject.tag == "Tree1")
            {
                Instantiate(oakTree, transform.position, transform.rotation);
                Destroy(this.gameObject);
            } else if (gameObject.tag == "Tree2")
            {
                Instantiate(palmTree, transform.position, transform.rotation);
                Destroy(this.gameObject);
            } else if(gameObject.tag == "Tree3")
            {
                Instantiate(poplarTree, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }

        }
    }
}
