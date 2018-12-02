using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Vector3 lookAt;
    public float speed;
    public float rotSpeed;
    public float rotAcc;
    public float acc;
    public float Drag;
    public float maxSpeed;
    public float maxRotSpeed;
    public float margin;
    public float bounce;
    public bool bouncing;
    private bool timerSet;
    public float bounceTime;
    public float bounceTimer;
    public float dClickTimer;
    public float dClickThreshold;
    private Vector2 direction;
    public float teleportCD;
    public float teleportTime;
    public bool canTeleport = true;
    public Animator anim;
	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    private void Update()
    {
        if (!Global.gamePaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time > dClickTimer)
                {
                    dClickTimer = Time.time + dClickThreshold;
                }
                else if (Time.time < dClickTimer && canTeleport)
                {
                    Debug.Log("Teleport!");
                    Teleport();
                }

            }
            if (Time.time > teleportTime)
            {
                canTeleport = true;
                anim.SetBool("canTeleport", canTeleport);
            }
        }
        

    }
    void FixedUpdate () {
        if (!Global.gamePaused)
        {
            if (bouncing)
            {
                Bounce();
                lookAtMouse();
            }
            else if (Input.GetMouseButton(0))
            {

                lookAtMouse();
                moveCharacter();
            }


            else
            {
                rotSpeed = 0;
                if (speed > 0)
                {
                    speed -= Drag;
                    transform.position += transform.right * Time.deltaTime * speed;
                }
                else if (speed < 0)
                {
                    speed = 0;
                    transform.position += transform.right * Time.deltaTime * speed;
                }
            }
        }
            
        
	}
    void Teleport()
    {
        transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        teleportTime = Time.time + teleportCD;
        canTeleport = false;
        anim.SetBool("canTeleport", canTeleport);
    }
    void Bounce()
    {
        if (!timerSet)
        {
            bounceTimer = Time.time + bounceTime;
            timerSet = true;
        }
        

        speed -= bounce;

        transform.position += transform.right * Time.deltaTime * speed;
        if (Time.time > bounceTimer)
        {
            Debug.Log("StopBouncing");
            bouncing = !bouncing;
            timerSet = false;
        }
            
    }
    void lookAtMouse() { 

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (rotSpeed < maxRotSpeed)
        {
            rotSpeed += rotAcc;
        }
        else
        {
            rotSpeed = maxRotSpeed;
        }
        float angleDist = Quaternion.Angle(transform.rotation, Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime));
        if (angleDist > margin || angleDist < -margin)
        {
            rotSpeed = 0;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);


        //Vector3 mousePos = Input.mousePosition;
        //mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        //if(transform.up.x < direction.x * rotSpeed * Time.deltaTime - margin && transform.up.x < direction.x * rotSpeed * Time.deltaTime - margin || )
        //transform.up = direction * rotSpeed * Time.deltaTime;

    }
    void moveCharacter() {
        if (speed < maxSpeed)
        {
            speed += acc;
        }
        else
        {
            speed = maxSpeed;
        }
        
        transform.position += transform.right * Time.deltaTime * speed;
    }
}
