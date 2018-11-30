using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour {
    public GameObject target;
    public GameObject debris;
    public GameObject debris2;
    public GameObject debris3;
    public float rotSpeed;
    public float life;
    public GameObject turret;
    public Camera cam;
    private ScreenShake shake;
    private Vector2 direction;
    private bool dying;
    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player");
        cam = Camera.main;
        shake = cam.GetComponent<ScreenShake>();
        Destroy(turret, life);
    }
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            direction = target.transform.position - transform.position;
        }
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hitter" && !dying || collision.gameObject.tag == "Debris" && !dying)
        {
            dying = true;
            Global.score += 1 * Global.multiplier;
            Global.multiplier += 1;
            Global.timer = Time.time + Global.timeLimit;
            Debug.Log(Global.score);
            Instantiate(debris, this.transform.position, collision.transform.rotation);
            Instantiate(debris2, this.transform.position, collision.transform.rotation);
            Instantiate(debris3, this.transform.position, collision.transform.rotation);
            
            
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
    }
}
