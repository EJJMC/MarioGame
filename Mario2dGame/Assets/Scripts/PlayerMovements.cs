using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Create Class and interface variables here..
    Rigidbody2D playerBody;
    SpriteRenderer spriteRenderer;

    // create general dynamic variables here..
    float xDirection;
    bool isNotGrounded = false;

    // create constant variables here..
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float jumpHeight = 7f;


    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovementHandler();
    }

    private void playerMovementHandler()
    {
        bool keyS = Input.GetKeyDown(KeyCode.S);
        bool keyW = Input.GetKeyDown(KeyCode.W);

        xDirection = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(xDirection * playerSpeed, playerBody.velocity.y);

        // Flip the direction of the player when moving towards the left and right.
        if(xDirection < 0)
        {
            //spriteRenderer.flipX = true;
            transform.localScale = new Vector2(-1, 1);
        } 
        else if (xDirection > 0)
        {
            //spriteRenderer.flipX = false;
            transform.localScale = new Vector2(1, 1);
        }

        // If "W" is clicked, perform jump or upward movement
        if (keyW && !isNotGrounded)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpHeight);
        }

        // If "S" is clicked, perform duck or downward movement
        if (keyS)
        {
            Debug.Log("Duck!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Once the player is on the ground level, the player should be able to jump.
        if (collision.gameObject.CompareTag("ground"))
        {
            isNotGrounded = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Once the player is above the ground level, the player should not be able to jump again.
        if (collision.gameObject.CompareTag("ground"))
        {
            isNotGrounded = true;
        }
    }
}
