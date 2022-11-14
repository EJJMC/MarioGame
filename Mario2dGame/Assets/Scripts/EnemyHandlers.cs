using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHandlers : MonoBehaviour
{
    // Create Class and interface variables here..

    // create general dynamic variables here..

    // create constant variables here..
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.tag == "grabableobject")
        {
            Debug.Log("Collision - grab");
            Destroy(collision.collider.GetComponent<Rigidbody2D>().gameObject);
            Destroy(gameObject);
        }
    }
}
