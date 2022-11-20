using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObjectHandler : MonoBehaviour
{

    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the object hits the ground, it has to disappear below the ground level
        if(collision.collider.tag == "ground" && collision.transform.CompareTag("grabableobject"))
        {
            boxCollider.isTrigger = true;
        }
    }
}
