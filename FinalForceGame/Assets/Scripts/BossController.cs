using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

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
    int specialmove = 0;

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
            if (specialmove <= 5)
            {
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
                            specialmove++;
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
                            specialmove++;
                        }
                        break;
                }
            }

            else
            {   
                GetComponent<Rigidbody2D>().position = new Vector2(0, 0);
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
