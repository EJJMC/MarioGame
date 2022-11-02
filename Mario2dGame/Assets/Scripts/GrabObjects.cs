using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{

    // Create Class and interface variables here..
    [SerializeField] public Transform grabDetect;
    [SerializeField] public Transform boxHolder;

    // create general dynamic variables here..
    [SerializeField] public float rayDistance;
    private bool isPicked = false;
    [SerializeField] public float throwForce;

    // create constant variables here..

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale.x, rayDistance);

        if(grabCheck.collider != null && grabCheck.collider.tag == "grabableobject")
        {
            if(Input.GetKeyDown(KeyCode.F) && !isPicked)
            {
                isPicked = true;
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else if (Input.GetKeyDown(KeyCode.F) && isPicked)
            {
                if (grabCheck.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 2) * throwForce;
                }

                isPicked = false;
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }
}
