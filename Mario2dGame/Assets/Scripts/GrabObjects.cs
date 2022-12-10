using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{

    // Create Class and interface variables here..
    [SerializeField] public Transform grabDetect;
    [SerializeField] public Transform boxHolder;
    [SerializeField] public Transform [] gunHolder;
    [SerializeField] public GameObject ShootBtn;
    public GameObject DropButton;

    // create general dynamic variables here..
    [SerializeField] public float rayDistance;
    private bool isPicked = false;
    [SerializeField] public float throwForce;
    public string status;

    // create constant variables here..

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale.x, rayDistance);

        if (((grabCheck && grabCheck.collider != null)) && 
            (grabCheck.collider.tag == "grabableobject" || 
            ((grabCheck.collider.tag == "gun") && 
                status == "dropped") 
            || grabCheck.collider.tag == "steppingstone"))
        {
            // If the object is not picked
            if((Input.GetKeyDown(KeyCode.F) || status == "picked") && !isPicked)
            {
                ifPickedWhatToDo(grabCheck);
            }
            // If the object is picked
            else if ((Input.GetKeyDown(KeyCode.F) || status == "dropped") && isPicked)
            {
                ifDroppedWhatToDo(grabCheck);
            }
        }
    }

    public void PickClicked()
    {
        status = "picked";
    }

    public void DropClicked()
    {
        status = "dropped";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gun"))
        {
            PickClicked();
            ShootBtn.SetActive(true);
            isPicked = true;
            DropButton.SetActive(true);
            collision.gameObject.transform.parent = boxHolder;
            collision.gameObject.transform.position = boxHolder.position;
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            status = "released";
            /*RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale.x, rayDistance);
            if (grabCheck.collider != null)
            {
                pickUpGun(grabCheck, true);
            } else if (collision.gameObject.transform)
            {
                Debug.Log("Cannot pickup once discarded");
                //pickUpGun(grabCheck, false);
            }*/
        }
    }

    private void pickUpGun(RaycastHit2D grabCheck, bool trigger)
    {
        PickClicked();
        ShootBtn.SetActive(true);
        isPicked = true;
        DropButton.SetActive(true);
        grabCheck.collider.gameObject.transform.parent = boxHolder;
        grabCheck.collider.gameObject.transform.position = boxHolder.position;
        grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        grabCheck.collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        status = "released";
    }

    private void ifPickedWhatToDo(RaycastHit2D grabCheck)
    {
        DropButton.SetActive(true);
        isPicked = true;
        grabCheck.collider.gameObject.transform.parent = boxHolder;
        grabCheck.collider.gameObject.transform.position = boxHolder.position;
        grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        grabCheck.collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        status = "released";
    }

    private void ifDroppedWhatToDo(RaycastHit2D grabCheck)
    {
        if (grabCheck.collider.tag == "gun")
        {
            ShootBtn.SetActive(false);
        }
        if (grabCheck.collider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 2) * throwForce;
        }

        DropButton.SetActive(false);
        isPicked = false;
        grabCheck.collider.gameObject.transform.parent = grabCheck.collider.tag == "gun" ? gunHolder[0] : null;
        grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        status = "released";
    }
}
