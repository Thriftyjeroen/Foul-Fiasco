using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    Rigidbody2D rb;
    float shootPower = 0;
    bool playerShoot = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (playerShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                shootPower += 0.1f;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.velocity = new Vector2(20, shootPower);
                shootPower = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerShoot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerShoot = false;
        }
    }
}
