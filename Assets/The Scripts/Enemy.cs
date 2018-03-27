using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];    //On start, Enemies must hit waypoint[0]
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position; //Gets the direction
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //Tells that the gameObject must comply to the speed variable given. Normalized is needed bcoz Unity applies automatic physics

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        //A value shall be given as basis because Unity depends on math and might given inaccuracies if not
        {
            getNextWaypoint();
        }
    }

    void getNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return; //Return, so that the code below won't run anymore after destroying
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

}
