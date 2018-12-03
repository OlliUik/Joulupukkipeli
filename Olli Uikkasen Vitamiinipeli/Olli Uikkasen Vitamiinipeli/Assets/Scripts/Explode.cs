using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    public GameObject debris;
    public GameObject debris2;
    public GameObject debris3;
    private bool dying;
    public bool instantiated;
    private ScreenShake shake;
    public Camera cam;
    public Quaternion rot;
    // Use this for initialization
    void Start () {
        cam = Camera.main;
        shake = cam.GetComponent<ScreenShake>();
        
    }
    private void Update()
    {
        if (instantiated && !dying)
        {
            dying = true;




            Global.score += 1 * Global.multiplier;
            Global.multiplier += 1;
            Global.timer = Time.time + Global.timeLimit;
            Debug.Log(Global.score);
            Instantiate(debris, this.transform.position, rot);
            Instantiate(debris2, this.transform.position, rot);
            Instantiate(debris3, this.transform.position, this.transform.rotation);


            Debug.Log("Kill!");
            dying = false;
            instantiated = false;
            gameObject.SetActive(false);
        }
    }

 


}
