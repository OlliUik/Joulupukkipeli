using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KillPlayer : MonoBehaviour {
    public bool bullet;
    // Use this for initialization
    //public Text finalScore;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Global.gamePaused)
        {
            if (collision.gameObject.tag == "Player")
            {
                //finalScore.text = Global.score.ToString();
                Global.gameOver = true;
                Debug.Log("Hit!");
                Destroy(collision.gameObject);
                if (bullet)
                {
                    Destroy(this.gameObject);
                }

            }
        }

    }
}
