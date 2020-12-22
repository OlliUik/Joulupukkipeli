using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    public GameObject debris;
    public GameObject debris2;
    public GameObject debris3;
    public bool dying;
    public bool instantiated;
    private ScreenShake shake;
    public Camera cam;
    public Quaternion rot;
    public AudioClip shootSound;
    public AudioSource source;
    public GameObject direction;
    public GameObject flyDirection;
    // Use this for initialization
    void Awake()
    {
        //source = GetComponent<AudioSource>();
    }
    void Start () {
        cam = Camera.main;
        shake = cam.GetComponent<ScreenShake>();
        //source.clip = shootSound;
        Debug.Log("Kill!1");
    }
    private void Update()
    {
        if (instantiated && !dying)
        {
            dying = true;



            //source.Play();
            Global.score += 1 * Global.multiplier;
            Global.multiplier += 1;
            Global.timer = Time.time + Global.timeLimit;
            Debug.Log(Global.score);
            //Instantiate(debris, this.transform.position, rot);
            //Instantiate(debris2, this.transform.position, rot);
            //Instantiate(debris3, this.transform.position, rot);


            Debug.Log("Kill!");
            dying = false;
            //instantiated = false;
            flyDirection.transform.rotation = rot;
            Bullet bullet = gameObject.GetComponent<Bullet>();
            bullet.flying = true;
            bullet.flySpeed = 10;
            Debug.Log("Waited");
            dying = true;
            //StartCoroutine(WaitBit());
        }

        IEnumerator WaitBit()
        {
            print(Time.time);
            yield return new WaitForSecondsRealtime(5);
            print(Time.time);
            gameObject.SetActive(false);
        }
    }

 


}
