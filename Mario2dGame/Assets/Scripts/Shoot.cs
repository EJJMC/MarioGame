using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public float shootSpeed, shootTimer;
    private bool isShooting;
    public Transform shootingPoint;
    public GameObject bullet;
    public Transform isHoldingGun;
    public AudioSource shootEfx;
    private bool efxOnPresPrefs;

    void Start()
    {
        isShooting = false;
    }
    void Update()
    {
        efxOnPresPrefs = (PlayerPrefs.GetInt("efxon") != 0);

        if (Input.GetButtonDown("Fire1"))
        {
            shootEnemy();
        }
        
    }

    public void shootEnemy()
    {
        if (!isShooting)
        {
            if (isHoldingGun.transform.childCount > 0 && isHoldingGun.transform.GetChild(0).CompareTag("gun"))
            {
                // Shoot function
                StartCoroutine(FuncShoot());
            }
        }
    }

    IEnumerator FuncShoot()
    {
        int direction()
        {
            if (transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }

        isShooting=true;
        // Debug.Log("Shoot");
        GameObject goBullet = Instantiate(bullet, shootingPoint.position, Quaternion.identity);
        goBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        goBullet.transform.localScale = new Vector2(goBullet.transform.localScale.x * direction(), goBullet.transform.localScale.y);
        if(efxOnPresPrefs)
        {
            shootEfx.Play();
        }
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}
