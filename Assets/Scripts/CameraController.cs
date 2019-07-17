using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject turretSelector;
    public GameObject turretUI;


    public float cSpeed;



    public bool mapLocked;

    public float minX;
    public float maxX;

    public float minZ;
    public float maxZ;





    public bool isMobile;

    Vector2 StartPosition;
    Vector2 DragStartPosition;
    Vector2 DragNewPosition;
    Vector2 Finger0Position;
    float DistanceBetweenFingers;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Vertical:" + Input.GetAxis("Vertical"));
        Debug.Log("Horizontal:" + Input.GetAxis("Horizontal"));
        //if (!isMobile)
        //{
            if (!turretSelector.activeSelf)
            {
            if(!turretUI.activeSelf)
            {

                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    transform.Translate(-Vector3.forward * cSpeed * Time.deltaTime, Space.World);
                }
                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    transform.Translate(Vector3.forward * cSpeed * Time.deltaTime, Space.World);
                }

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    transform.Translate(Vector3.left * cSpeed * Time.deltaTime, Space.World);
                }
                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    transform.Translate(Vector3.right * cSpeed * Time.deltaTime, Space.World);
                }

            }
        }

            else
            {

            }


            if (mapLocked)
            {
                transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y,
                Mathf.Clamp(transform.position.z, minZ, maxZ)
                    );
            }


        //}
    }
}
