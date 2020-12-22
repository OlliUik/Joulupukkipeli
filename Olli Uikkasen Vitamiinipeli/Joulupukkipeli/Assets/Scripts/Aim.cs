using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public GameObject target;
    private Vector2 direction;
    public float rotSpeed;
    public float life;



 

    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        if (!Global.gamePaused)
        {

            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.rotation = rotation;
        }
    }


}
