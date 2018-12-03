using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float spawnrate;
    public float spawnTimer;
    public Transform spawner;
    private int spawnCount;
    public int waveLength;
    public bool reliableSpawner;
    public Pooler pooler;
   
  
    // Use this for initialization
    void Start()
    {
   
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
            Spawn();

        }
    }
    void shoot()
    {
        spawnTimer = Time.time + spawnrate;
        Debug.Log("Spawner");
        spawnCount += 1;
       if(Random.value < 0.33f && spawnCount >= waveLength)
        {
            Spawn();

        }
        else if (Random.value < 0.33f && spawnCount >= waveLength *2)
        {
            Spawn();

        }
        else if (Random.value < 0.5f && spawnCount >= waveLength * 3)
        {
            Spawn();

        }
        else if (Random.value < 0.75f && spawnCount >= waveLength * 4)
        {
            Spawn();

        }
        else if (Random.value < 1f && spawnCount >= waveLength * 5)
        {
           
            Spawn();
           

        }

    }
    void Spawn()
    {
        GameObject obj = pooler.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
  
    }

}
