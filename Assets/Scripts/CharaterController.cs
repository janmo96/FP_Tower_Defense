using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterController : MonoBehaviour
{
    public Camera eyes;


    //speed
    [Header("Speeds")]
    public float speed = 5f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    [Header("Rotations")]
    bool isMenuOpen = false;




    private float moveFB;
    private float moveLR;
    private float mouseX;
    private float mouseY;

    Rigidbody rb;

    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
       // turretbuildmenu = GameObject.Find("TurretsToBuild");
       // turretselectmenu = GameObject.Find("TurretUI");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Cursor.lockState);

        if (menu.activeSelf)
        {
            isMenuOpen = true;
        } else
        {
            isMenuOpen = false;
        }




        //Movement




        if (!isMenuOpen) {

            Cursor.lockState = CursorLockMode.Locked;


            moveFB = Input.GetAxis("Vertical");
            moveLR = Input.GetAxis("Horizontal");
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");


            if (moveFB > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        } else if(moveFB < 0)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        }

        if (moveLR > 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else if (moveLR < 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        //Rotation
        transform.Rotate(0,mouseX * Time.deltaTime * speedH,0);



        eyes.transform.Rotate(-mouseY * Time.deltaTime * speedH, 0, 0);
        } else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
