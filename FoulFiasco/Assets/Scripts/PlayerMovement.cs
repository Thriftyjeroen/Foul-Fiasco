using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    FollowPlayer followPlayer;
    [SerializeField] Rigidbody2D rbBall;
    [SerializeField] float jump = 12;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = FindAnyObjectByType<FollowPlayer>();
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
        if ((Input.GetKeyDown(KeyCode.W)) && IsGrounded()) // als je spatie klikt en isgrounded true is of je op w klikt en isgrounded true is doe de code
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); // zorgt ervoor dat je force toevoegd aan de y axis zodat je speler omhoog kan gaan dus kan gaan jumpen
            StartCoroutine(followPlayer.JumpMovement());
        }
    }

    void SlideManager()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
            StartCoroutine(followPlayer.SlideMovementDown());
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            StartCoroutine(followPlayer.SlideMovementUp());
        }
    }

    void KickManager()
    {
        rbBall.velocity = new Vector2(20, 18);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                KickManager();
            }
        }
    }
}
