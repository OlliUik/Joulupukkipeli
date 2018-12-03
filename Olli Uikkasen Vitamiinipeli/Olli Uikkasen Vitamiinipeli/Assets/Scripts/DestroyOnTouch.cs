using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Global.gamePaused && collision.gameObject.tag != "Blade")
        {
            collision.gameObject.SetActive(false);
        }
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Global.gamePaused && collision.gameObject.tag != "Blade")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
