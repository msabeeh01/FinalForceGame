using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("laser"))
        {
            Destroy(other.gameObject);
        }
    }
}
