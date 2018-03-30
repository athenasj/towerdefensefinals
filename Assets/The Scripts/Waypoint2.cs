using System.Collections;
using UnityEngine;

public class Waypoint2 : MonoBehaviour{

    // this code will collect the waypoints that set up

    public static Transform[] point2;

    private void Awake()
    {
        point2 = new Transform[transform.childCount]; //Counts the waypoints under Waypoint gameobject
        for (int i = 0; i < point2.Length; i++)
        {
            point2[i] = transform.GetChild(i);
        }
    }
}