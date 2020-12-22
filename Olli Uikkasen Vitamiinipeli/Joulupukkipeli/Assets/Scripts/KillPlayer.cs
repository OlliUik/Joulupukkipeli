using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KillPlayer : MonoBehaviour {
    public bool bullet;
    public Explode explode;
    // Use this for initialization
    //public Text finalScore;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("COLLIDED!!!!");
        if (!Global.gamePaused)
        {
            if (collision.gameObject.tag == "Player" && !explode.instantiated)
            {
                //finalScore.text = Global.score.ToString();
                Global.gameOver = true;
                Debug.Log("Hit!");
                //Destroy(collision.gameObject);
                if (bullet)
                {
                    gameObject.SetActive(false);
                }

            }
        }

    }
}
