using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigirBodyExplosion : MonoBehaviour
{
    public float force;
    public float radius;
    public float upModifier;

    Rigidbody[] rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = this.gameObject.GetComponentsInChildren<Rigidbody>();


        foreach(Rigidbody body in rb)
        {
            body.AddExplosionForce(force,transform.position,radius, upModifier);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
