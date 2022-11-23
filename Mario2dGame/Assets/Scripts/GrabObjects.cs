using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{

    // Create Class and interface variables here..
    [SerializeField] public Transform grabDetect;
    [SerializeField] public Transform boxHolder;
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

        if(grabCheck.collider != null && 
            (grabCheck.collider.tag == "grabableobject" || grabCheck.collider.tag == "gun" || grabCheck.collider.tag == "steppingstone"))
        {
            // If the object is not picked
            if((Input.GetKeyDown(KeyCode.F) || status == "picked") && !isPicked)
            {
                if(grabCheck.collider.tag == "gun")
                {
                    ShootBtn.SetActive(true);
                }
                DropButton.SetActive(true);
                isPicked = true;
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                // if(grabCheck.collider.tag == "grabableobject")
                // {
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    grabCheck.collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                // }
                status = "released";
            }
            // If the object is picked
            else if ((Input.GetKeyDown(KeyCode.F) || status == "dropped") && isPicked)
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
                grabCheck.collider.gameObject.transform.parent = null;
                // if(grabCheck.collider.tag == "grabableobject")
                // {
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                // }
                status = "released";
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
}
