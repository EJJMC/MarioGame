using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovements : MonoBehaviour
{
    // Create Class and interface variables here..
    Rigidbody2D playerBody;
    public AudioSource playerJumpEFX;
    public Text countText;
    public Text lifeCountText;

    // create general dynamic variables here..
    float xDirection;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    bool isGrounded;
    bool canDoubleJump;
    public float delayBeforeDoubleJump;
    private int count = 0;
    private bool keyboardClick = true;
    private bool mobileControllerClick = false;

    private Animator Myanimator;

    // create constant variables here..
    int playerMaxHealth = 2;
    public float speed = 15f;
    public float jumpSpeed = 10f;


    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();

        moveLeft = false;
        moveRight = false;

        Myanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
        playerMovementHandler();
        HandleLayers();
    }
    private void FixedUpdate()
    {
        if( mobileControllerClick )
        {
            playerBody.velocity = new Vector2(horizontalMove, playerBody.velocity.y);
            Myanimator.SetFloat("speed", Mathf.Abs(horizontalMove));

        } else if ( keyboardClick )
        {
            playerBody.velocity = new Vector2(xDirection * speed, playerBody.velocity.y);
            Myanimator.SetFloat("speed", Mathf.Abs(horizontalMove));

        }
    }

    // Private methods
    private void playerMovementHandler()
    {
        bool keyW = Input.GetKeyDown(KeyCode.W);
        bool keyA = Input.GetKeyDown(KeyCode.A);
        bool keyD = Input.GetKeyDown(KeyCode.D);
        bool keySpace = Input.GetKeyDown(KeyCode.Space);

        xDirection = Input.GetAxisRaw("Horizontal");

        // Flip the direction of the player when moving towards the left and right.
        if (keyA)
        {
            keyBoardClicked();
            transform.localScale = new Vector2(-1, 1);
            

        } else if (keyD)
        {
            keyBoardClicked();
            transform.localScale = new Vector2(1, 1);
            
        }
        // If "W" is clicked, perform jump or upward movement
        if (keyW)
        {
            keyBoardClicked();
            doJump();
        }

        if(playerBody.velocity.y<0)
        {
            Myanimator.SetBool("Land", true);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Once the player is on the ground level, the player should be able to jump.
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            Myanimator.SetBool("Land", false);
            canDoubleJump = false;
        }

        if (collision.collider.tag == "enemyjumpkill")
        {
            Destroy(collision.collider.gameObject.transform.parent.gameObject);
        }
        
        if (collision.collider.tag == "enemy")
        {
            if (playerMaxHealth == 2)
            {
                playerMaxHealth -= 1;
                lifeCountText.text = playerMaxHealth.ToString();
            }
            else if (playerMaxHealth == 1)
            {
               // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
               //  PlayerPrefs.SetInt("restartlevelat", currentSceneIndex);
                // SceneManager.LoadScene(1);
                Myanimator.SetBool("Death", true);
            }
        }

        if(collision.collider.tag == "donewithyou")
        {
            if(count == 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } else
            {
                Debug.Log("Player has to collect 3 keys");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectible"))
        {
            count++;
            countText.text = count.ToString();
            Destroy(collision.gameObject);
        }
    }
    private void MovementPlayer()
    {
        //If I press the left button
        if (moveLeft)
        {
            horizontalMove = -speed;
            
        }

        //if i press the right button
        else if (moveRight)
        {
            horizontalMove = speed;
            
        }

        //if I am not pressing any button
        else
        {
            horizontalMove = 0;
        }
    }
    private void keyBoardClicked ()
    {
        keyboardClick = true;
        mobileControllerClick = false;
    }
    private void mobileControllerClicked()
    {
        keyboardClick = false;
        mobileControllerClick = true;
    }

    // Public methods
    
    // Function that handles a bool for double jump
    void EnableDoubleJump()
    {
        canDoubleJump = true;
    }

    // Left button press
    public void PointerDownLeft()
    {
        mobileControllerClicked();
        transform.localScale = new Vector2(-1, 1);
        moveLeft = true;
    }

    // Release left button press
    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    // Right button press
    public void PointerDownRight()
    {
        mobileControllerClicked();
        transform.localScale = new Vector2(1, 1);
        moveRight = true;
    }

    // Release right button press
    public void PointerUpRight()
    {
        moveRight = false;
    }

    // Jump handler
    public void doJump()
    {
        /*
            bool efxOnPresPrefs = (PlayerPrefs.GetInt("efxon") != 0);
            float efxVolPresPrefs = PlayerPrefs.GetFloat("gameefx");
            if (efxOnPresPrefs)
            {
                Debug.Log(playerJumpEFX);
                Debug.Log(efxVolPresPrefs);
                playerJumpEFX.volume = efxVolPresPrefs;
                playerJumpEFX.Play();
            }
         */
        if (isGrounded)
        {
            isGrounded = false;
            playerBody.velocity = Vector2.up * jumpSpeed;
            Invoke("EnableDoubleJump", delayBeforeDoubleJump);
            
            //   Myanimator.SetBool("IsGrounded", true);
        }

        if (canDoubleJump)
        {
            playerBody.velocity = Vector2.up * jumpSpeed;
            
            canDoubleJump = false;
        }
    }

        private void HandleLayers()
        {
        if(!isGrounded)
        {
            Myanimator.SetLayerWeight(1, 1);
        }
        else {
            Myanimator.SetLayerWeight(1, 0);
        }
        }
    }


