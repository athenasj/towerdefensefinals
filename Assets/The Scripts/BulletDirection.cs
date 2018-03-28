using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDirection : MonoBehaviour {
    private Transform target;
    public float speed = 70f;
    public GameObject bulletImpact;
    public float bulletRange = 0f;

    public void Seek (Transform _target)
    {
        target = _target;
    }

	// Use this for initialization
	void Start () {
		
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
        }
        


    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    /* This is for the gizmo to see the range*/
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, bulletRange);
    }
}
