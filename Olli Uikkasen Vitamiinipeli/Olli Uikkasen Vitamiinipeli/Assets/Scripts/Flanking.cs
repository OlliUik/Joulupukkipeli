using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flanking : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Global.gamePaused)
        {
            if (collision.gameObject.tag == "Flanker")
            {
                EnemyFlanke flank = collision.GetComponent<EnemyFlanke>(); 
                flank.attacking = true;

            }
        }

    }
}
