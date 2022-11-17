using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float walkSpeed, range;
    public bool isPatrol;
    private bool doTurn;
    private float distToPlayer;
    // private bool canShoot;

    private Rigidbody2D enemyBody;
    public LayerMask ground;
    public LayerMask wall;
    public Transform groundCheck;
    public Collider2D bodyCollider;
    public Transform player;
    // public Transform shootPos;
    // public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        isPatrol = true;
        // canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPatrol)
            Patrol();

        // Get the distance between the player and the enemy
        distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer <= range)
        {
            if((player.position.x > transform.position.x && transform.localScale.x < 0) 
                || (player.position.x < transform.position.x && transform.localScale.x > 0))
            {
                Flip();
            }

            // if(canShoot)
                // StartCoroutine(AttackPlayer());
            isPatrol = false;

        } else
        {
            isPatrol = true;
        }
    }

    private void FixedUpdate()
    {
        // Checking for the ground level. If it goes beyond the ground level, it becomes true (because of ! operator)
        if (isPatrol)
        {
            doTurn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        }
    }

    private void Patrol()
    {
        // If doTurn is true or if the enemy hits a wall, turn back (or Flip)
        if(doTurn || bodyCollider.IsTouchingLayers(wall))
        {
            Flip();
        }
        enemyBody.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, enemyBody.velocity.y);
    }

    private void Flip()
    {
        isPatrol = false;
        // Flip the scale of the enemy on hitting the wall or if he tries to go beyond the ground level.
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        isPatrol = true;
    }

    /*IEnumerator AttackPlayer()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBTWShots);
        Debug.Log("Attack!");

        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody>().velocity = new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);
        canShoot = true;
    }*/
}
