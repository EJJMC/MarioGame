using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbullets : MonoBehaviour
{
    public float speed;
    public Rigidbody2D bullet;

    private void Start()
    {
        bullet.velocity = transform.right * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("enemyjumpkill"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("walls"))
        {
            Destroy(gameObject);
        }
    }
}
