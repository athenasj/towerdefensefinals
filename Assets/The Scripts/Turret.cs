using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {


    [Header("Turret Details")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup")]
    public Transform target;
    public float speedtoRotate = 15f;
    public string enemyTag = "Enemy";
    public Transform rotateThis;

    public GameObject bulletPrefab;
    public Transform firePoint;

    /* Use this for initialization */
    void Start() {
        //calls UpdateTarget every .5 seconds thats why InvokeRepeating
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    /* Checks the nearest target */
    void UpdateTarget()
    {
        //looks for game objects tagged with "enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity; // tagged as infinity for instance and comparison on later score
        GameObject nearestEnemy = null; //contains the nearest enemy

        //contains every enemy in the scene loops through each enemy tagged "Enemy"
        foreach (GameObject enemy in enemies)
        {
            //distance between turret and enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            //if the current enemy is closer than previous shortest distance make it shortest distance
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy; //also make it the new enemy
            }
        }

        //if nearest enemy is set and shortest distance is within range
        if (nearestEnemy != null && shortestDistance <= range)
        {
            //make the nearest enemy the target
            target = nearestEnemy.transform;
        }
        else
            target = null;


    }



    /* Update is called once per frame */
    void Update() {

        //if target doesnot exist exit lol
        if (target == null)
            return;

        //gets distance for direction
        Vector3 dir = target.position - transform.position;

        //"converts" v to Q for rotation purposes
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        //Use Q.lerp for smooth rotation lerp(rotatefrom, rotateto, speed/float
        Vector3 rotation = Quaternion.Lerp(rotateThis.rotation, lookRotation, Time.deltaTime * speedtoRotate).eulerAngles;

        //apply rotation with Euler
        rotateThis.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletDirection bullet = bulletGO.GetComponent<BulletDirection>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    /* This is for the gizmo to see the range*/
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
