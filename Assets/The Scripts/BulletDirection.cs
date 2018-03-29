using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDirection : MonoBehaviour {
    private Transform target;
    public float speed = 70f;
    public GameObject bulletImpact;
    public float bulletRange = 0f;
    

    void Start()
    {

    }

    public void Seek (Transform _target)
    {
        target = _target;
    }

	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject holdEffect = (GameObject)Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(holdEffect, 2f);

        //to check whether to destroy close enemies or not
        if(bulletRange > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        
        Destroy(gameObject); //for destroy bullet
    }

    void Explode()
    {
        Collider[] hitObject = Physics.OverlapSphere(transform.position,bulletRange);

        foreach (Collider collider in hitObject)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }           
            else if (collider.tag == "MediumEnemy")
            {

            }
            else if (collider.tag == "HardEnemy")
            {

            }
        }
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
        if (enemy.gameObject.tag == "Enemy")
        {
            PlayerStats.Money += 10;
            PlayerStats.Rounds++;
        }

        //Debug.Log("Money should add");
    }

    /* This is for the gizmo to see the range*/
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, bulletRange);
    }
}
