using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bullet;
    public float firerate;
    public float shootTimer;
    public Transform bulletSpawn;
	// Use this for initialization
	void Start () {
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
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    }
}
