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
    //void Awake()
    //{
    //    source = GetComponent<AudioSource>();
    //}
    void Start () {
        pool = GameObject.FindWithTag("ProjectilePool");
        pooler = pool.GetComponent<Pooler>();
        shootTimer = 0;
        //source.clip = shootSound;
    }
	
	// Update is called once per frame
	void Update ()
    {
       if (Input.GetMouseButton(0))
        {
            if (Time.time > shootTimer)
            {

                shoot();

            }
        }	
	}

    void shoot()
    {
        shootTimer = Time.time + firerate;
        GameObject obj = pooler.GetPooledObject();
        GameObject direction = obj.transform.Find("Direction").gameObject;
        print("Shootin");
        if (obj == null) return;

        //source.Play();
        //obj.GetComponent<TrailRenderer>().Clear();
        //obj.GetComponent<TrailRenderer>().enabled = false;

        obj.transform.position = bulletSpawn.position;
        direction.transform.rotation = bulletSpawn.rotation;
        obj.SetActive(true);
        //obj.GetComponent<TrailRenderer>().enabled = true;
    }
}
