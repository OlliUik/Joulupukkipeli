using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHunter : MonoBehaviour {
    public GameObject target;
    public GameObject debris;
    public GameObject debris2;
    public GameObject debris3;
    public float rotSpeed;
    public float life;
    public GameObject turret;
    public Camera cam;
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
    // Use this for initialization
    void Start () {
         move = this.GetComponent<Bullet>();
        target = GameObject.FindWithTag("Player");
        cam = Camera.main;
        sprintTimer = Time.time + sprintTime;
        sprintCoolDownTimer = Time.time + sprintTime;
        Destroy(turret, life);
    }
	
	// Update is called once per frame
	void Update () {
        
        //move.speed = attackSpeed;
        if (Time.time > sprintCoolDownTimer && !attacking)
        {

            Attack();

        }
        if (Time.time > sprintTimer && attacking)
        {

            Stop();

        }
       
        if (!attacking)
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
        if (collision.gameObject.tag == "Hitter" && !dying || collision.gameObject.tag == "Debris" && !dying)
        {
            dying = true;
            Global.score += 1 * Global.multiplier;
            Global.multiplier += 1;
            Global.timer = Time.time + Global.timeLimit;
            Instantiate(debris, this.transform.position, collision.transform.rotation);
            Instantiate(debris2, this.transform.position, collision.transform.rotation);
            Instantiate(debris3, this.transform.position, collision.transform.rotation);
            ScreenShake shake = cam.GetComponent<ScreenShake>();
            
            if(collision.gameObject.tag == "Hitter")
            {
                Movement move = collision.GetComponentInParent<Movement>();
                Debug.Log(move.bouncing);
                move.bouncing = true;
                shake.shake = 0.3f;
            }
            else
            {
                shake.shake = 0.2f;
            }

            Debug.Log("Kill!");
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Destroyer")
        {
            Debug.Log("Destroyed!");
            Destroy(this.gameObject);
        }
    }
}
