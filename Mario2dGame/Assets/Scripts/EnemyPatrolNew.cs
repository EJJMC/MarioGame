using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolNew : MonoBehaviour
{
    public float speed;
    private bool moveRight = true;
    public Transform groundDetection;

    private void Update()
    {
        transform.Translate(speed * Vector2.right * Time.deltaTime);

        RaycastHit2D gInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

        if(gInfo.collider == false || gInfo.collider.CompareTag("walls") || gInfo.collider.CompareTag("steppingstone"))
        {
            if(moveRight)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveRight = false;
            } else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
    }

}
