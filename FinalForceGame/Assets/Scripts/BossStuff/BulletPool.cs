using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;

    [SerializeField]
    private GameObject pooledBullet;//represents a pooled bullet
    private bool notEnoughBulletsInPool = true;//used to add more bullets to pool

    private List<GameObject> bullets;//list of game objects also known as the bullet pool, basically contains all the bullets

    ////All code borrowed from https://www.youtube.com/watch?v=Mq2zYk5tW_E
    
    private void Awake()
    {
        bulletPoolInstance = this;//assigns bulletPoolInstance to this gameObject
    }
    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>(); //creates a new List assigned to bullets
    }

    public GameObject GetBullet()
    {
        //when bullet pool is empty, add more bullets
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            { 
                if(!bullets[i].activeInHierarchy)
                {
                    //when an inactive bullet is found, it is returned
                    return bullets[i];
                }
            }
        }

        if (notEnoughBulletsInPool)// if there are not enough bullets, it creates one from a prefab and assigns it to the pool
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        //if none of the two are true, return null, since one of two should always be true
        return null;
    }

}
