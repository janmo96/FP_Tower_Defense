// Just add this script to your camera. It doesn't need any configuration.

using UnityEngine;

public class TouchCamera : MonoBehaviour {


    public float speed;

    public float minX;
    public float maxX;

    public float minZ;
    public float maxZ;

    public GameObject buildTurretUI;
    public GameObject TurretUI;


    public bool mapLocked = false;
    private void Start()
    {
        
    }
    private void Update()
    {
        if(!buildTurretUI.activeSelf)
        { 
            if(!TurretUI.activeSelf)
            {


        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(touchDeltaPosition.x * speed, 0, touchDeltaPosition.y * speed, Space.World);
                }
                if (mapLocked) { 
            transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),transform.position.y,
            Mathf.Clamp(transform.position.z, minZ, maxZ)
                );
            }
        }
        }
    }


}
