using System.Collections;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    // this code will collect the waypoints that set up

    public static Transform[] points;

    private void Awake()
    {
        points = new Transform[transform.childCount]; //Counts the waypoints under Waypoint gameobject
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
