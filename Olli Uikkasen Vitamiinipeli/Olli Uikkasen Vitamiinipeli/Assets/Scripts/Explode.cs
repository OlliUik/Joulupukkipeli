using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    public GameObject debris;
    public GameObject debris2;
    public GameObject debris3;
    private bool dying;
    private ScreenShake shake;
    public Camera cam;
    // Use this for initialization
    void Start () {
        cam = Camera.main;
        shake = cam.GetComponent<ScreenShake>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Global.gamePaused)
        {
            if (collision.gameObject.tag == "Hitter" && !dying || collision.gameObject.tag == "Debris" && !dying)
            {
                dying = true;
                Global.sleep = true;
                if (collision.gameObject.tag == "Hitter")
                {
                    Debug.Log("Bounce");
                    Movement move = collision.GetComponentInParent<Movement>();
                    Debug.Log(move.bouncing);
                    move.bouncing = true;
                    shake.shake = 0.3f;
                }
                else
                {
                    shake.shake = 0.2f;
                }

                Global.score += 1 * Global.multiplier;
                Global.multiplier += 1;
                Global.timer = Time.time + Global.timeLimit;
                Debug.Log(Global.score);
                Instantiate(debris, this.transform.position, collision.transform.rotation);
                Instantiate(debris2, this.transform.position, collision.transform.rotation);
                Instantiate(debris3, this.transform.position, collision.transform.rotation);




                Debug.Log("Kill!");
                Destroy(this.gameObject);
            }
        }
           
    }

}
