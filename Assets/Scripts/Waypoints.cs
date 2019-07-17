using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{


    public static Transform[] waypoints;


    void Awake()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }

   void OnDrawGizmos()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }


        foreach (Transform waypoint in waypoints)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(waypoint.transform.position, .2f);
        }
    }


}
