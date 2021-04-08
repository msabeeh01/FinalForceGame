using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    private float moveSpeed;
    private bool moveRight;
    public static int bosshealth = 100;
    public static bool bossalive = true;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
        moveRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (bosshealth < 1)
        {
            bossalive = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            Destroy(this.gameObject);
        }
        if (bossalive)
        {
            if (bosshealth > 70)
            {
                if (transform.position.x > 3f)
                {
                    moveRight = false;
                }
                else if (transform.position.x < -3f)
                {
                    moveRight = true;
                }

                if (moveRight)
                {
                    transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
                }

                else
                {
                    transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
                }
            }

            else if (ShipMovement.bosshealth > 0 && ShipMovement.bosshealth <= 70)
            {
                transform.position = new Vector2(0,0);

            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            PlayerController.playerlife--;
        }
        if(other.gameObject.CompareTag("laser"))
        {
            Destroy(other.gameObject);

        }
    }
}
