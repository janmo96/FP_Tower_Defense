using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTrees : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 10 || col.gameObject.layer == 11)
        {
            Destroy(col.transform.gameObject);
        }
    }


}
