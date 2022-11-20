using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbullets : MonoBehaviour
{
    public GameObject PEObject;
    public float destroyTime;
    private void Start()
    {
        StartCoroutine(BulletsNull());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("enemyjumpkill"))
        {
            Destroy(collision.gameObject);
            DestroyBullet();
        }
        Destroy(gameObject);
    }

    IEnumerator BulletsNull()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(PEObject);
    }

    void DestroyBullet()
    {
        if(PEObject != null)
        {
            Instantiate(PEObject, transform.position, Quaternion.identity);
        }
    }
}
