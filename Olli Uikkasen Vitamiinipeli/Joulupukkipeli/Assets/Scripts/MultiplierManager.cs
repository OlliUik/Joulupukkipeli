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
    public float cycleTimer;
    public float cycleLength;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!Global.gamePaused && Global.gameStarted)
        {
            multText.text = "x" + Global.multiplier.ToString();
            scoreText.text = Global.score.ToString();
            multTimer = Global.timer;
            if (Global.gameOver)
            {
                Debug.Log("Game Over!");
                gameOverText.text = "JOULU PILALLA!!!";
                //resetText.text = "Touch to Reset";
                //resetText.text = "R - Reset";
                //quitText.text = "Q - Quit";
            }
            if (Time.time > multTimer)
            {
                multTimer = Time.time + Global.timeLimit;
                Global.multiplier = 1;
            }
            if (Time.time > cycleTimer)
            {
                cycleTimer = Time.time + cycleLength;
                Global.cycles += 1;
                Debug.Log(Global.cycles +"cycles");
            }
        }
  

    }
}
