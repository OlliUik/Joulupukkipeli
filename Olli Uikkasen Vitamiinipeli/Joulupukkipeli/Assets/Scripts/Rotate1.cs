using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate1 : MonoBehaviour {
    public float rotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * rotation);
    }
}
