using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 10;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, speed);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bosslaser") || other.gameObject.CompareTag("laser"))
        {
            GameObject.Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
    
