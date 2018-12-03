using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bullet;
    private GameObject pool;
    public float firerate;
    public float shootTimer;
    public Transform bulletSpawn;
    public Pooler pooler;
	// Use this for initialization
	void Start () {
        pool = GameObject.FindWithTag("ProjectilePool");
        pooler = pool.GetComponent<Pooler>();
        shootTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Time.time > shootTimer)
        {
            shoot();
        }	
	}

    void shoot()
    {
        shootTimer = Time.time + firerate;
        GameObject obj = pooler.GetPooledObject();
  
        if (obj == null) return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
}
