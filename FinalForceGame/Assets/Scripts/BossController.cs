using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject laser, laserSpawner;
    public float fireRate = 0.5f;
    public float bossspeed = 10;
    public float minX, maxX, minY, maxY;

    public static int bossHealth = 10;
    public static bool bossAlive = true;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    int Direction = -1;

    void Update()
    {
        //Fire code for boss if alive.
        if (bossHealth < 0)
        {
            bossAlive = false;
        }
        if (bossAlive)
        {
            //Code for moving boss, simple left and right for alpha
            switch (Direction)
            {
                case -1:
                    // Moving Left
                    if (GetComponent<Rigidbody2D>().position.x > minX)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0);
                    }
                    else
                    {
                        // Hit left boundary, change direction
                        Direction = 1;
                    }
                    break;

                case 1:
                    // Moving Right
                    if (GetComponent<Rigidbody2D>().position.x < maxX)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0);
                    }
                    else
                    {
                        // Hit right boundary, change direction
                        Direction = -1;
                    }
                    break;
            }

            //Fire code
            if (timer > fireRate)
            {
                GameObject.Instantiate(laser, laserSpawner.transform.position, laserSpawner.transform.rotation);

                timer = 0;

            }
            timer += Time.deltaTime;
        }

        //Destroy the boss
        else if (!bossAlive)
        {
            Destroy(this.gameObject);
        }
    }
}
