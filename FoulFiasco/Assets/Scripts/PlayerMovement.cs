using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float input;
    [SerializeField] float speed = 8;
    [SerializeField] float jump = 12;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementManager();
    }

    bool IsGrounded() // maakt een method die een bool returned
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); // kijkt of de groundcheck position de groundlayer overlapt
    }

    void MovementManager()
    {
        input = Input.GetAxis("Horizontal"); // in unity kan je settings veranderden voor bijvoorbeeld movement horizontal gebruik je voor links en rechts bewegen
        rb.velocity = new Vector2(input * speed, rb.velocity.y); // veranderd de velocity zodat je kan bewegen

        if ((Input.GetKeyDown(KeyCode.Space) && IsGrounded() || Input.GetKeyDown(KeyCode.W)) && IsGrounded()) // als je spatie klikt en isgrounded true is of je op w klikt en isgrounded true is doe de code
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); // zorgt ervoor dat je force toevoegd aan de y axis zodat je speler omhoog kan gaan dus kan gaan jumpen
        }
    }
}
