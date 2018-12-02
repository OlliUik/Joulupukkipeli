using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public float sleepTime = 0.02f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Global.sleep)
        {
            StartCoroutine(PauseGame());
            
        }
		if (Input.GetKeyDown("p"))
        {
            Debug.Log("pause");
            if(Time.timeScale >= 1)
            {
                Global.gamePaused = true;
                Time.timeScale = 0f;
                //StartCoroutine(PauseGame());

            }
            else
            {
                Time.timeScale = 1f;
                Global.gamePaused = false;
            }
        }
	}
    IEnumerator PauseGame()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(sleepTime);
        Time.timeScale = 1f;
        Global.sleep = false;
    }
}
