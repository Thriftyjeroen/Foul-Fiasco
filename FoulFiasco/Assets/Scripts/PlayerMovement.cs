using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jump = 12;

    [SerializeField] AudioSource jumpSFX;

    PlayerInfo playerInfo;

    CircleCollider2D circleCollider;
    BoxCollider2D boxCollider;

    bool isGrounded = false;
    public bool isSliding = false;

    private void Start()
    {
        playerInfo = FindAnyObjectByType<PlayerInfo>();
        circleCollider = GetComponent<CircleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementManager();
        SlideManager();
    }

    void MovementManager()
    {
        if (((Input.GetKeyDown(KeyCode.W)) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded) // als je spatie klikt en isgrounded true is of je op w klikt en isgrounded true is doe de code
        {
            jumpSFX.Play();
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); // zorgt ervoor dat je force toevoegd aan de y axis zodat je speler omhoog kan gaan dus kan gaan jumpen
            isGrounded = false;
        }
    }

    void SlideManager()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.0065f, transform.position.z);
            circleCollider.enabled = false;
            boxCollider.enabled = true;
            transform.localScale = new Vector3(1, 0.5f, 1);
            isSliding = true;
        }
        else
        {
            circleCollider.enabled = true;
            boxCollider.enabled = false;
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}