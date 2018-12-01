using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {
    public float dampTime = 10f;
    public Vector3 cameraPos = Vector3.zero;
    public GameObject target;
    public float xOffset = 0;
    public float yOffset = 0;
    public float otherMargin;
    public float camSpeed;
    public float maxCamSpeed;
    public float camAcc;
    public float margin = 0.1f;

	// Use this for initialization
	void Start () {
        target = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //if (target)
        //{
        //    transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        //}
        if(target != null)
        {
            cameraPos = new Vector3(Mathf.SmoothStep(transform.position.x, target.transform.position.x, dampTime), Mathf.SmoothStep(transform.position.y, target.transform.position.y, dampTime));
        }
       
        //if (target)
        //{
        //    float targetX = target.position.x + xOffset;
        //    float targetY = target.position.y + yOffset;
        //    float newTargetX = target.position.x + xOffset;
        //    float newTargetY = target.position.y + yOffset;
        //    if (Mathf.Abs(transform.position.x - targetX) < margin)
        //    {
        //        newTargetX = Mathf.Lerp(transform.position.x, targetX, 1 / dampTime * Time.deltaTime);
        //    }
        //    if (Mathf.Abs(transform.position.y - targetY) < margin)
        //    {
        //        newTargetY = Mathf.Lerp(transform.position.y, targetY, 1 / dampTime * Time.deltaTime);
        //    }
        //    float pos = transform.position.x;

        //    if (targetX < pos + otherMargin && targetY < pos + otherMargin || targetX > pos - otherMargin && targetY < pos + otherMargin || targetX > pos - otherMargin && targetY > pos - otherMargin || targetX < pos + otherMargin && targetY > pos - otherMargin)
        //    {
        //        transform.position = new Vector3(newTargetX, newTargetY, transform.position.z);
        //        targetX = newTargetX;
        //        targetY = newTargetY;

        //    }
        //    else
        //    {
        //        transform.position = new Vector3(targetX, targetY, transform.position.z);
        //    }


        //}

    }
    void LateUpdate()
    {
        transform.position = cameraPos + Vector3.forward * -10;
    }
}
