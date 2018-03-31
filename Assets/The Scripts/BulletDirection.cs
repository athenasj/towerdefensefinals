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
            //Debug.Log(target.gameObject.tag);
            if (target.gameObject.name.Contains("Easy"))
            {
                Damage(target, 50);
                //Debug.Log("inEnemy if");
            }
            else if (target.gameObject.name.Contains("Medium"))
            {

            }
            else if (target.gameObject.name.Contains("Hard"))
            {
                Damage(target, 25);
            }
            else if (target.gameObject.name.Contains("Fast"))
            {
                Damage(target, 100);
            }
        }

        
        Destroy(gameObject); //for destroy bullet
    }

    //this is for enemies within vicinity
    void Explode()
    {
        Collider[] hitObject = Physics.OverlapSphere(transform.position,bulletRange);

        foreach (Collider collider in hitObject)
        {
            if(collider.name.Contains("Easy"))
            {
                Damage(collider.transform, 50);
            }           
            else if (collider.name.Contains("Medium"))
            {
                Damage(collider.transform, 25);
            }
            else if (collider.name.Contains("Hard"))
            {

            }
            else if (collider.name.Contains("Fast"))
            {
                Damage(collider.transform, 100);
            }
        }
    }

    void Damage(Transform enemy, int damagePoint)
    {
        if (enemy.name.Contains("2"))
        {
            Enemy2 subtr = enemy.GetComponent<Enemy2>();
            subtr.LessHealth(damagePoint); //one hit for normal enemy
        }
        else
        {
            Enemy subt = enemy.GetComponent<Enemy>();
            subt.LessHealth(damagePoint); //one hit for normal enemy
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
