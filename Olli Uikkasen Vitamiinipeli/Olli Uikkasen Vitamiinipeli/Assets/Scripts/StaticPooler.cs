using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPooler : MonoBehaviour {

    public static StaticPooler current;
    public GameObject poolObject;
    public int poolSize = 20;
    public bool canGrow;

    List<GameObject> poolObjects;

    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        poolObjects = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(poolObject);
            obj.SetActive(false);
            poolObjects.Add(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }
        if (canGrow)
        {
            GameObject obj = (GameObject)Instantiate(poolObject);
            poolObjects.Add(obj);
            return obj;
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
