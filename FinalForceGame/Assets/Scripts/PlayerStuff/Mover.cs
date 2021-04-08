using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (other.gameObject.CompareTag("bosslaser") || other.gameObject.CompareTag("boss"))
        {
            if (other.gameObject.CompareTag("boss"))
            {
                GameObject.Instantiate(explosion, transform.position, transform.rotation);
                ScoreManager.score1--;
                ShipMovement.bosshealth--;
            }

            
            else
            {
                GameObject.Instantiate(explosion, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
            
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("aster") || other.gameObject.CompareTag("enemy"))
        {
            GameObject.Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            GameObject.Instantiate(explosion, transform.position, transform.rotation);
            Debug.Log(EnemyController.enemykilledScore);
        }
    }
}
    
