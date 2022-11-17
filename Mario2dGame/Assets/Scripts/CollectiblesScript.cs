using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectiblesScript : MonoBehaviour
{
    private int count = 0;
    public Text countText;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectible"))
        {
            count++;
            Debug.Log(count);
            countText.text = count.ToString();
            Destroy(collision.gameObject);
        }
    }
}
