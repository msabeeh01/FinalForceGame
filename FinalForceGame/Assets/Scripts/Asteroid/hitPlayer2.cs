using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hitPlayer2 : MonoBehaviour
{
    public int health = 3;
    void Update()
    {
        if (EnemyController.movenextlevel == true)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Debug.Log("HitPLAYER");
            PlayerController.playerlife--;
        }

        if (other.gameObject.CompareTag("laser"))
        {
            health--;
            if (health < 1)
            {
                EnemyController.enemykilledScore++;
                if (EnemyController.enemykilledScore >= 17)
                {
                    EnemyController.movenextlevel = true;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                Destroy(this.gameObject);
            }
        }
    }
}
