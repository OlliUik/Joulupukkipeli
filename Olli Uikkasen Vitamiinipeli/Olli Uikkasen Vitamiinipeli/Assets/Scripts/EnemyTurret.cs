using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour {
    public GameObject target;

    public float rotSpeed;
    public float life;


    
    private Vector2 direction;
    
    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player");

        

    }
	
	// Update is called once per frame
	void Update () {
        if (!Global.gamePaused)
        {
            if (target != null)
            {
                direction = target.transform.position - transform.position;
            }

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
        }
    }

   
}
