using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets2 : MonoBehaviour
{
    private float angle2 = 0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.03f);
    }

    // Update is called once per frame
    private void Fire()
    {
        float bulDirX = transform.position.x + Mathf.Sin((angle2 * Mathf.PI) / 180f);
        float bulDirY = transform.position.y + Mathf.Cos((angle2 * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
        bul.transform.position = transform.position;
        bul.transform.rotation = transform.rotation;
        bul.SetActive(true);
        bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

        angle2 += 50f;


    }
}
