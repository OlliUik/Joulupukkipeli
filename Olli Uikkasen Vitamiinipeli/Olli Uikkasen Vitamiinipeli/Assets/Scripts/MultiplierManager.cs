using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierManager : MonoBehaviour {
 
    public float multTimer;
    public Text multText;
    public Text scoreText;
    public Text gameOverText;
    public Text resetText;
    public Text quitText;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        multText.text = "x" + Global.multiplier.ToString();
        scoreText.text = Global.score.ToString();
        multTimer = Global.timer;
        if (Global.gameOver)
        {
            Debug.Log("Game Over!");
            gameOverText.text = Global.score.ToString();
            //resetText.text = "Touch to Reset";
            //resetText.text = "R - Reset";
            //quitText.text = "Q - Quit";
        }
        if (Time.time > multTimer)
        {
            multTimer = Time.time + Global.timeLimit;
            Global.multiplier = 1;
        }

    }
}
