using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDirection : MonoBehaviour {
    private Transform target;
    public float speed = 70f;
    public GameObject bulletImpact;

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

    }

    void HitTarget()
    {
        GameObject holdEffect = (GameObject)Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(holdEffect, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
