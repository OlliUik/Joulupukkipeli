using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

public class Shoot : MonoBehaviour {
    public GameObject bullet;
    private GameObject pool;
    public float firerate;
    public float shootTimer;
    public Transform bulletSpawn;
    public Pooler pooler;
    public AudioClip shootSound;
    public AudioSource source;
    private float volLowRange = .5f;
    private float volHiRange = 1f;
    // Use this for initialization
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Start () {
        pool = GameObject.FindWithTag("ProjectilePool");
        pooler = pool.GetComponent<Pooler>();
        shootTimer = 0;
        source.clip = shootSound;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Time.time > shootTimer)
        {
            shoot();
        }	
	}

    void shoot()
    {
        shootTimer = Time.time + firerate;
        GameObject obj = pooler.GetPooledObject();
  
        if (obj == null) return;

        source.Play();

        obj.transform.position = bulletSpawn.position;
        obj.transform.rotation = bulletSpawn.rotation;
        obj.SetActive(true);
    }
}
