using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBulletDestroyer : MonoBehaviour
{
    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("player") || !other.gameObject.CompareTag("boss"))
        {
            Destroy(other.gameObject);
        }
    }
}
