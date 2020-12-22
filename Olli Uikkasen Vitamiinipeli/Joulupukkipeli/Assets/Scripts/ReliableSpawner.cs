using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliableSpawner : MonoBehaviour {
    public GameObject turret;
    public GameObject hunter;
    public float spawnrate;
    public float spawnTimer;
    public Transform spawner;
   
    public int waveLength;
  
    // Use this for initialization
    void Start()
    {
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTimer)
        {
            shoot();
        }
    }

    void shoot()
    {
        spawnTimer = Time.time + spawnrate;
        Debug.Log("Spawner");
       
       if(Random.value < 0.5f)
        {
            if (Random.value < 0.5f)
            {
                Instantiate(turret, spawner.position, spawner.rotation);
            }
            else
            {
                Instantiate(hunter, spawner.position, spawner.rotation);
            }
                
        }


    }

}
