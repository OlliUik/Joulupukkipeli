using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour {
    public bool isPlayer;
    private Camera cam;
    private ScreenShake shake;
    public float shakeAmount;
    private Movement move;
    void Start()
    {
        move = this.GetComponentInParent<Movement>();
        cam = Camera.main;
        shake = cam.GetComponent<ScreenShake>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Global.gamePaused)
        {
            if (collision.gameObject.tag == "Turret"  || collision.gameObject.tag == "Hunter"  || collision.gameObject.tag == "Flanker")
            {
                Explode boom = collision.GetComponent<Explode>();
                boom.rot = this.transform.rotation;
                boom.instantiated = true;
                if (isPlayer)
                {
                    Global.sleep = true;
                    Debug.Log("Bounce");
                    
                    Debug.Log(move.bouncing);
                    move.bouncing = true;
                    
                }
                shake.shake = shakeAmount;

            }
        }

    }
}
