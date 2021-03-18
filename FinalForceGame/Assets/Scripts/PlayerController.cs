using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float minX, minY, maxX, maxY;
    public GameObject laser, laserSpawner;

    private float timer = 0;
    public static int playerlife = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerlife > 0)
        {
            float horizontal, vertical;
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            Vector2 nVelocity = new Vector2(horizontal, vertical);
            GetComponent<Rigidbody2D>().velocity = nVelocity * speed;

            float newX, newY;

            newX = Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, minX, maxX);
            newY = Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, minY, maxY);

            GetComponent<Rigidbody2D>().position = new Vector2(newX, newY);

        }
        else
        {
            GetComponent<Rigidbody2D>().position = new Vector2(0, -4);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ShipMovement.bosshealth = 100;
            ScoreManager.score1 = 100;
            playerlife = 1;

        }

    }

    void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && timer > 0.25f)
        {
            GameObject.Instantiate(laser, laserSpawner.transform);

            timer = 0;
        }
        timer += Time.deltaTime;
    }

    

}
