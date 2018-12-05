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
    public int cycle = 1;
    public int startCycle;
    public Pooler pooler;
    public List<GameObject> spawnPoints;
    //public GameObject spawnPoint1;
    //public GameObject spawnPoint2;
    //public GameObject spawnPoint3;
    //public GameObject spawnPoint4;
    //public GameObject spawnPoint5;
    //public GameObject spawnPoint6;
    //public GameObject spawnPoint7;
    //public GameObject spawnPoint8;


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
                //shoot();
            }
            else if (Time.time > spawnTimer && reliableSpawner && Global.cycles >= startCycle)
            {

                if (spawnCount <= 2)
                {
                    ReliableSpawn(2);
                }
                else if (spawnCount <= 5)
                {
                    ReliableSpawn(3);
                }
                else if (spawnCount <= 8)
                {
                    Debug.Log("Spawn4");
                    ReliableSpawn(4);
                }
                else {
                    spawnCount = 0;
                }
            }

        }

    }
    void ReliableSpawn(int spawns)
    {
        spawnCount += 1;
        int prevRandom = 0;
        spawnTimer = Time.time + spawnrate;
        Debug.Log("Spawner");
        
        for (int i = 0; i < spawns; i++)
        {
            int rand = Random.Range(0, 7);
            if(rand != prevRandom)
            {
                Spawn(spawnPoints[rand]);
            }
            else
            {
                rand = Random.Range(0, 7);
                Spawn(spawnPoints[rand]);
            }
            prevRandom = rand;
        }

        
    }
    //void shoot()
    //{
    //    spawnTimer = Time.time + spawnrate;
    //    Debug.Log("Spawner");
    //    spawnCount += 1;
    //   if(Random.value < 0.33f && spawnCount >= waveLength)
    //    {
    //        Spawn();

    //    }
    //    else if (Random.value < 0.33f && spawnCount >= waveLength *2)
    //    {
    //        Spawn();

    //    }
    //    else if (Random.value < 0.5f && spawnCount >= waveLength * 3)
    //    {
    //        Spawn();

    //    }
    //    else if (Random.value < 0.75f && spawnCount >= waveLength * 4)
    //    {
    //        Spawn();

    //    }
    //    else if (Random.value < 1f && spawnCount >= waveLength * 5)
    //    {
           
    //        Spawn();
           

    //    }

    //}
    void Spawn(GameObject sPoint)
    {
        GameObject obj = pooler.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = sPoint.transform.position;
        obj.transform.rotation = sPoint.transform.rotation;
        obj.SetActive(true);
  
    }

}
