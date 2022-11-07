using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandlers : MonoBehaviour
{
    // Create Class and interface variables here..

    // create general dynamic variables here..

    // create constant variables here..
    int playerMaxHealth = 2;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "enemy")
        {
            Debug.Log("Collision");
            if (playerMaxHealth == 2)
            {
                playerMaxHealth -= 1;
            } else if (playerMaxHealth == 1)
            {
                Destroy(gameObject);
            }
        }

        if(collision.collider.tag == "grabableobject")
        {
            Debug.Log("Collision - grab");
            Destroy(collision.collider.GetComponent<Rigidbody2D>().gameObject);
            Destroy(gameObject);
        }
    }
}
