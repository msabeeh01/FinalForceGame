using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    [SerializeField]
    //lets us choose how many bullets
    private int bulletsAmount = 10;

    [SerializeField]
    //changes the angle of bullet spread
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;//direction of each bullet

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);//repeats the Fire() method every 2 seconds
    }

    //All FireBullets(n) code borrowed from https://www.youtube.com/watch?v=Mq2zYk5tW_E
    private void Fire()
    {
        if (ShipMovement.bosshealth > 70)//used to create different stages of the boss
        {
            float angleStep = (endAngle - startAngle) / bulletsAmount;//used to spread the bullets proportionally based on given angles
            float angle = startAngle;//sets a new float to startAngle initially

            for (int i = 0; i < bulletsAmount + 1; i++)//for each bullet, calculate move direction, each bullet will be different from other
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);//changes bullets x direction based on angle variable provided
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);//changes bullets y direction based on angle variable provided

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);//assigns current bullet's directional movement to a direction vector
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;//gives each bullet a direction

                GameObject bul = BulletPool.bulletPoolInstance.GetBullet();//grab a bullet from the pool
                bul.transform.position = transform.position;//set bullets direction
                bul.transform.rotation = transform.rotation;//set bullets rotation
                bul.SetActive(true);//set this bullet active, meaning it will move
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);//give the bullet its pre-assigned direction

                angle += angleStep; //increase angle by angle step, this allows us to repeat the previous steps but for another, different bullet.
            }
        }

        else if (ShipMovement.bosshealth <= 70 && ShipMovement.bosshealth > 40)//checks if boss' health is within certain range.
        {
            ((FireBullets2)gameObject.GetComponent<FireBullets2>()).enabled = true;//if the boss health is within range, disable this script and run the next one
            //InvokeRepeating("Fire2", 0f, 0.1f);
        }
    }
}
