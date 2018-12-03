using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour {
    public float lifeSpan;
    private void OnEnable()
    {
        Invoke("Destroy", lifeSpan);
    }
    private void OnDestroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
