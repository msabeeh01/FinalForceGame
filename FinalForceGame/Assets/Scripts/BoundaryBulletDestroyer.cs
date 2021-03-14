using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBulletDestroyer : MonoBehaviour
{
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("laser") || other.gameObject.CompareTag("bosslaser"))
        {
            Destroy(other.gameObject);
        }
    }
}
