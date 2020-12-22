using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlanke : MonoBehaviour {
    public GameObject target;

    public float rotSpeed;
    public float life;
  

    public Bullet move;
    public bool attacking;
    public float attackSpeed;
    public float regSpeed;
    public float sprintTimer;
    public float sprintTime;
    private float dist;
    private bool dying;
    private Vector2 direction;
    public float flankDist = 1f;
    // Use this for initialization
    void Start()
    {
        move = this.GetComponent<Bullet>();
        target = GameObject.FindWithTag("Player");

 
      
    }

    // Update is called once per frame
    void Update()
    {

        if (!Global.gamePaused)
        {

            if (attacking)
            {
                if (target != null)
                {
                    direction = target.transform.position - transform.position;
                }
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
                Attack();

            }
            else
            {
                if(target != null)
                {
                    dist = Vector2.Distance(this.transform.position, target.transform.position);
                }
                
              if (dist > flankDist)
                {
                    Debug.Log("Moving");
                    if (target != null)
                    {
                        direction = target.transform.position - transform.position;
                    }
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
                }
                else
                {
                    if (target != null)
                    {
                        direction = target.transform.position - transform.position;
                    }
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
                }
            }

        }
        //move.speed = attackSpeed;


    }
    void Attack()
    {
        //sprintCoolDownTimer = Time.time + sprintCoolDown;
        sprintTimer = Time.time + sprintTime;
        Debug.Log("Charge!");

        move.speed = attackSpeed;
        attacking = true;

    }

    //    private void OnTriggerEnter2D(Collider2D collision)
    //    {
    //        if (!Global.gamePaused)
    //        {
    //            if (collision.gameObject.tag == "FlankArea")
    //            {
    //                attacking = true;

    //            }
    //        }

    //    }
}
