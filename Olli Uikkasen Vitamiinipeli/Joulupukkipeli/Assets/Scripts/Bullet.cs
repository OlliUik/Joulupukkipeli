using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;

    public float life;
    public float startAngle;
    public bool hasDrag;
    public float drag;
    public float flyDrag = 1;
    public float flySpeed;
    public float maxSpeed;
    public bool hasMaxSpeed;
    public GameObject direction;
    public bool flying = false;
    public GameObject flyDirection;
    public Animator anim;
    private bool debounce = false;
    public float wait;
    private float waitTimer;
    private bool leaving = false;
    public Explode explode;
    public bool kid = false;
    private bool finalDebounce = false;
    private float scareSpeed = 7;

    // Use this for initialization
    void Start () {
        
        transform.Rotate(Vector3.forward * startAngle);

    }
	
	// Update is called once per frame
	void Update () {
        if (!Global.gamePaused)
        {
            if (flying)
            {
                anim.Play("Base Layer.KidCatch");
                transform.position += flyDirection.transform.right * Time.deltaTime * flySpeed;
                flySpeed -= flyDrag; 
                if (flySpeed < 0)
                {
                    flySpeed = 0;

                    waitTimer = Time.time + wait;
                    leaving = true;
                    flying = false;
                    
                }
            }
            else if (leaving)
            {
                if (Time.time > waitTimer)
                {
                    anim.Play("Base Layer.KidLeave");
                    if (transform.position.x < 0)
                    {
                        transform.position += -transform.right * Time.deltaTime * speed * 1.5f;
                    }
                    else
                    {
                        transform.position += transform.right * Time.deltaTime * speed * 1.5f;
                    }
                   
                     if (transform.position.x > 50 || transform.position.x < -50)
                    {
                        explode.instantiated = false;
                        leaving = false;
                        explode.dying = false;
                        gameObject.SetActive(false);

                    }
                }
            }
            else if (Global.gameOver && kid)
            {
                if (!finalDebounce)
                {
                    waitTimer = Time.time + 1.5f;
                    finalDebounce = true;
                }
                if (Time.time > waitTimer)
                {
                    anim.Play("Base Layer.KidCryin");
                    if (transform.position.x < 0)
                    {
                        transform.position += -transform.right * Time.deltaTime * speed * 1.5f;
                    }
                    else
                    {
                        transform.position += transform.right * Time.deltaTime * speed * 1.5f;
                    }

                    if (transform.position.x > 50 || transform.position.x < -50)
                    {
                        explode.instantiated = false;
                        leaving = false;
                        explode.dying = false;
                        gameObject.SetActive(false);

                    }
                }
                else
                {
                    transform.position += direction.transform.right * Time.deltaTime * -scareSpeed;
                    scareSpeed -= .05f;
                    if (scareSpeed < 0)
                    {
                        scareSpeed = 0;
                        anim.Play("Base Layer.KidShock");
                    }
                }
                 
            }
            else
            {
                transform.position += direction.transform.right * Time.deltaTime * speed;

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

}
