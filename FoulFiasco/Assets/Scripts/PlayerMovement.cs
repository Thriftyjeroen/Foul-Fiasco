using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jump = 12;

    PlayerInfo playerInfo;

    bool isGrounded = false;
    public bool isSliding = false;

    private void Start()
    {
        playerInfo = FindAnyObjectByType<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        print(isGrounded);
        MovementManager();
        SlideManager();
    }

    void MovementManager()
    {
        if (((Input.GetKeyDown(KeyCode.W)) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded) // als je spatie klikt en isgrounded true is of je op w klikt en isgrounded true is doe de code
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); // zorgt ervoor dat je force toevoegd aan de y axis zodat je speler omhoog kan gaan dus kan gaan jumpen
        }
    }

    void SlideManager()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
            isSliding = true;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            isSliding = false;
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

    private void OnCollisionStay2D(Collision2D collision)
    {
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}