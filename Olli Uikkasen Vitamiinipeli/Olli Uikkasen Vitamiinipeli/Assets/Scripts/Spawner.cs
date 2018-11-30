using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject turret;
    public GameObject hunter;
    public float spawnrate;
    public float spawnTimer;
    public Transform spawner;
    private int spawnCount;
    public int waveLength;
    public bool reliableSpawner;
  
    // Use this for initialization
    void Start()
    {
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.gameStarted)
        {
            if (Time.time > spawnTimer && !reliableSpawner)
            {
                shoot();
            }
            else if (Time.time > spawnTimer && reliableSpawner)
            {
                ReliableSpawn();
            }
        }

    }
    void ReliableSpawn()
    {
        spawnTimer = Time.time + spawnrate;
        Debug.Log("Spawner");

        if (Random.value < 0.5f)
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
    void shoot()
    {
        spawnTimer = Time.time + spawnrate;
        Debug.Log("Spawner");
        spawnCount += 1;
       if(Random.value < 0.33f && spawnCount >= waveLength)
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
        else if (Random.value < 0.33f && spawnCount >= waveLength *2)
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
        else if (Random.value < 0.5f && spawnCount >= waveLength * 3)
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
        else if (Random.value < 0.75f && spawnCount >= waveLength * 4)
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
        else if (Random.value < 1f && spawnCount >= waveLength * 5)
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
