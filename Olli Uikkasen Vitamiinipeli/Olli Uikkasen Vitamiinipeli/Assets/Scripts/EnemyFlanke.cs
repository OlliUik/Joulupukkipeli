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
    public float sprintCoolDown;
    public float sprintCoolDownTimer;
    private bool dying;
    private Vector2 direction;
    public float flankDist = 1f;
    // Use this for initialization
    void Start()
    {
        move = this.GetComponent<Bullet>();
        target = GameObject.FindWithTag("Player");

        sprintTimer = Time.time + sprintTime;
        sprintCoolDownTimer = Time.time + sprintTime;
      
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
             else if (Vector2.Distance(this.transform.position, target.transform.position) > flankDist)
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
            else if (!attacking)
            {
                if (target != null)
                {
                    direction = target.transform.position - transform.position;
                }
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle +90, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
            }
        }
        //move.speed = attackSpeed;


    }
    void Attack()
    {
        //sprintCoolDownTimer = Time.time + sprintCoolDown;
        sprintTimer = Time.time + sprintTime;
        Debug.Log("Charge!");
        move.hasDrag = true;
        move.speed = attackSpeed;
        attacking = true;

    }
    void Stop()
    {
        sprintCoolDownTimer = Time.time + sprintCoolDown;
        //sprintTimer = Time.time + sprintTime;
        move.hasDrag = false;
        move.speed = regSpeed;
        attacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Global.gamePaused)
        {
            if (collision.gameObject.tag == "FlankArea")
            {
                attacking = true;

            }
        }

    }
}
