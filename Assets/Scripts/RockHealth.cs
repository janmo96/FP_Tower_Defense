using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHealth : MonoBehaviour
{
    public float rockHealth;
    public GameObject fracturedRock1;
    public GameObject fracturedRock2;
    public GameObject fracturedRock3;
    public GameObject fracturedRock4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rockHealth <= 0)
        {
            if(gameObject.tag == "Rock1")
            {
               Instantiate(fracturedRock1, transform.position, transform.rotation);
                Destroy(this.gameObject);
            } else if(gameObject.tag == "Rock2")
            {
                Instantiate(fracturedRock2, transform.position, transform.rotation);
                Destroy(this.gameObject);
            } else if(gameObject.tag == "Rock3")
            {
                Instantiate(fracturedRock3, transform.position, transform.rotation);
                Destroy(this.gameObject);
            } else if(gameObject.tag == "Rock4")
            {
                Instantiate(fracturedRock4, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }

        }
    }
}
