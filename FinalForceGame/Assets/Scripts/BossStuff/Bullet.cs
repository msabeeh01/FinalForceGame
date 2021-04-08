using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;
    public GameObject explosion;

    //All bullet movement code borrowed from https://www.youtube.com/watch?v=Mq2zYk5tW_E
    private void OnEnable()
    { 
        Invoke("Destroy", 3f);
    }
    // Start is called before the first frame update
    void Start()
    {
        //presets bullet speed
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //move bullet based on speed and direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        //sets bullets movement direction
        moveDirection = dir;
    }

    public void Destroy()
    {
        //instead of destroying prefab copy, it deactivates the copy in the hierarchy
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //basic collision code
        if (other.gameObject.CompareTag("laser"))
        {
            Destroy();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("player"))
        {
            Destroy();
            PlayerController.playerlife--;
        }


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("aster"))
        {
            GameObject.Instantiate(explosion, transform.position, transform.rotation);
            Destroy();
        }
    }
}
