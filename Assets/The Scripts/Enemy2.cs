using System.Collections;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;
    public int enemyHealth = 100;

    void Start()
    {
        target = Waypoint2.point2[0];    //On start, Enemies must hit waypoint[0] //this is changed for diffent spawnpoints
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position; //Gets the direction
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //Tells that the gameObject must comply to the speed variable given. Normalized is needed bcoz Unity applies automatic physics

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        //A value shall be given as basis because Unity depends on math and might given inaccuracies if not
        {
            getNextWaypoint();
        }
    }

    public void LessHealth(int subtHealth)
    {
        enemyHealth -= subtHealth;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            PlayerStats.Money += 10;
            PlayerStats.Rounds++;
        }
    }

    void getNextWaypoint()
    {
        if (wavepointIndex >= Waypoint2.point2.Length - 1)
        {
            PlayerStats.Lives -= 1;
            if (PlayerStats.Lives <= 0)
            {
                PlayerStats.Lives = 0;
            }
            Destroy(gameObject);
            return; //Return, so that the code below won't run anymore after destroying
        }
        wavepointIndex++;
        target = Waypoint2.point2[wavepointIndex];
    }

}