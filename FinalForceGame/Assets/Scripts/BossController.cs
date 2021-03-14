using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject laser, laserSpawner;
    public float fireRate = 0.5f;

    public static int bossHealth = 10;
    public static bool bossAlive = true;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (bossHealth < 0)
        {
            bossAlive = false;
        }
        if (bossAlive)
        {
            if (timer > fireRate)
            {
                GameObject.Instantiate(laser, laserSpawner.transform.position, laserSpawner.transform.rotation);

                timer = 0;

            }
            timer += Time.deltaTime;
        }

        else if (!bossAlive)
        {
            Destroy(this.gameObject);
        }
    }
}
