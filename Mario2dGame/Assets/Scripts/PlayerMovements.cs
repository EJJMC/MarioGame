using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
    // Create Class and interface variables here..
    Rigidbody2D playerBody;
    public AudioSource playerJumpEFX;

    // create general dynamic variables here..
    float xDirection;
    bool isNotGrounded = false;
    string movement;

    // create constant variables here..
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float jumpHeight = 14f;
    int playerMaxHealth = 2;



    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovementHandler();
        mobileController(movement);
    }

    // Private methods
    private void playerMovementHandler()
    {
        bool keyS = Input.GetKeyDown(KeyCode.S);
        bool keyW = Input.GetKeyDown(KeyCode.W);

        xDirection = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(xDirection * playerSpeed, playerBody.velocity.y);

        // Flip the direction of the player when moving towards the left and right.
        if(xDirection < 0)
        {
            moveLeftAction();
        } 
        else if (xDirection > 0)
        {
            moveRightAction();
        }

        // If "W" is clicked, perform jump or upward movement
        if (keyW && !isNotGrounded)
        {
            jumpAction();
        }

        // If "S" is clicked, perform duck or downward movement
        if (keyS)
        {
            duckAction();
        }
    }
    private void mobileController(string movement)
    {
        if(movement == "right")
        {
            playerBody.velocity = new Vector2(playerSpeed, playerBody.velocity.y);
            moveRightAction();
        } else if (movement == "left")
        {
            playerBody.velocity = new Vector2(-playerSpeed, playerBody.velocity.y);
            moveLeftAction();
        } else if (movement == "up" && !isNotGrounded)
        {
            jumpAction();
        } else if (movement == "down")
        {
            duckAction();
        } else if (movement == "stop")
        {
            // playerBody.velocity = Vector2.zero;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Once the player is on the ground level, the player should be able to jump.
        if (collision.gameObject.CompareTag("ground"))
        {
            isNotGrounded = false;
        }

        if (collision.collider.tag == "enemyjumpkill") {
            Debug.Log("enemy died!");
            Destroy(collision.collider.transform.parent.gameObject);
        }
        else if (collision.collider.tag == "enemy")
        {
            Debug.Log("Collision");
            if (playerMaxHealth == 2)
            {
                playerMaxHealth -= 1;
            }
            else if (playerMaxHealth == 1)
            {
                // Destroy(gameObject);
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                PlayerPrefs.SetInt("restartlevelat", currentSceneIndex);
                SceneManager.LoadScene(1);
            }
        }

        if(collision.collider.tag == "donewithyou")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
    private void jumpAction()
    {
        bool efxOnPresPrefs = (PlayerPrefs.GetInt("efxon") != 0);
        float efxVolPresPrefs = PlayerPrefs.GetFloat("gameefx");
        if (efxOnPresPrefs)
        {
            Debug.Log(playerJumpEFX);
            Debug.Log(efxVolPresPrefs);
            playerJumpEFX.volume = efxVolPresPrefs;
            playerJumpEFX.Play();
        }
        playerBody.velocity = new Vector2(playerBody.velocity.x, jumpHeight);
    }
    private void duckAction()
    {
        Debug.Log("Duck");
    }
    private void moveLeftAction()
    {
        transform.localScale = new Vector2(-1, 1);
    }
    private void moveRightAction()
    {
        transform.localScale = new Vector2(1, 1);
    }

    // Public methods
    public void mobControllerUp()
    {
        movement = "up";
    }
    public void mobControllerDown()
    {
        movement = "down";
    }
    public void mobControllerLeft()
    {
        movement = "left";
    }
    public void mobControllerRight()
    {
        movement = "right";
    }
    public void releaseController()
    {
        movement = "stop";
    }

}
