using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inputs : MonoBehaviour {
    public Text companyText;
    public Text gameText;
    public Text presentsText;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown("r") )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
            Global.score = 0;
            Global.multiplier = 1;
            Global.gameOver = false;
            Global.gameStarted = true;
        }
        if (Input.GetMouseButtonDown(0) && !Global.gameStarted || Input.touchCount > 0 && !Global.gameStarted)
        {
            Global.gameStarted = true;
            companyText.text = "";
            gameText.text = "";
            presentsText.text = "";
        }
        if (Input.GetKeyDown("q"))
        {
            Application.Quit();
        }
        if (Global.gameStarted)
        {
            companyText.text = "";
            gameText.text = "";
            presentsText.text = "";
        }
        if ( Input.GetMouseButtonDown(0) && Global.gameOver || Input.GetMouseButtonDown(1) && Global.gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Global.score = 0;
            Global.multiplier = 1;
            Global.gameOver = false;
            Global.gameStarted = true;
            Global.cycles = 0;
        }

    }
}
