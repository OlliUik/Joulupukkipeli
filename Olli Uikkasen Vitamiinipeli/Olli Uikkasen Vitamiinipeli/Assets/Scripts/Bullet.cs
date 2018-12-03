using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;

    public float life;
    public float startAngle;
    public bool hasDrag;
    public float drag;
    public float maxSpeed;
    public bool hasMaxSpeed;

	// Use this for initialization
	void Start () {
        
        transform.Rotate(Vector3.forward * startAngle);

    }
	
	// Update is called once per frame
	void Update () {
        if (!Global.gamePaused)
        {
            transform.position += transform.right * Time.deltaTime * speed;

            if (hasDrag)
            {
                if (speed < maxSpeed || !hasMaxSpeed)
                {
                    speed -= drag;
                }
                else
                {
                    speed = maxSpeed;
                }

            }
        }

    }

}
