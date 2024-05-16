using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jump = 12;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    PlayerInfo playerInfo;

    private void Start()
    {
        playerInfo = FindAnyObjectByType<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementManager();
        SlideManager();
    }

    bool IsGrounded() // maakt een method die een bool returned
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); // kijkt of de groundcheck position de groundlayer overlapt
    }

    void MovementManager()
    {
        if (((Input.GetKeyDown(KeyCode.W)) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded()) // als je spatie klikt en isgrounded true is of je op w klikt en isgrounded true is doe de code
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); // zorgt ervoor dat je force toevoegd aan de y axis zodat je speler omhoog kan gaan dus kan gaan jumpen
        }
    }

    void SlideManager()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tutorial")
        {
            playerInfo.score = 0;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
