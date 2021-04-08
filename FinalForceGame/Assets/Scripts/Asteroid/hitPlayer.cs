using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitPlayer : MonoBehaviour
{
    void Update()
    {
        if (ShipMovement.bosshealth <= 70)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Debug.Log("HitPLAYER");
            PlayerController.playerlife--;
        }
    }
}
