using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerInfo playerInfo;
    float shootPower = 0;
    bool playerShoot = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInfo = FindAnyObjectByType<PlayerInfo>();
    }

    private void Update()
    {
        if (playerShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                shootPower += 0.15f;
                if (shootPower >= 30)
                {
                    shootPower = 30;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.velocity = new Vector2(15, shootPower);
                shootPower = 0;
            }
        }

        GameObject.FindGameObjectWithTag("ShootBar").GetComponent<Image>().fillAmount = shootPower / 30;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerShoot = true;
        }

        if (collision.tag == "Goal")
        {
            playerInfo.score += 100;
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
