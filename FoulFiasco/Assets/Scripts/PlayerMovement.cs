using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Draggable variable
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jump = 12;

    [SerializeField] AudioSource jumpSFX;
    [SerializeField] AudioSource slideSFX;

    // Script variable
    PlayerInfo playerInfo;

    CircleCollider2D circleCollider;
    BoxCollider2D boxCollider;

    bool isGrounded = false;
    public bool isSliding = false;

    private void Start()
    {
        // playerInfo variable gets linked to PlayerInfo script
        playerInfo = FindAnyObjectByType<PlayerInfo>();
        circleCollider = GetComponent<CircleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Cals method
        MovementManager();
        SlideManager();
    }

    void MovementManager()
    {
        if (((Input.GetKeyDown(KeyCode.W)) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded && !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))) // If you space click and isgrounded true is or you on w click and isgrounded true is do the code
        {
            jumpSFX.Play(); // Plays the jump sound effect
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); // concern that you force add to the y axis so that you player upward can go so can go jump
            isGrounded = false;
        }
    }

    void SlideManager()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (!slideSFX.isPlaying) slideSFX.Play();
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.0065f, transform.position.z);
            circleCollider.enabled = false;
            boxCollider.enabled = true;
            transform.localScale = new Vector3(1, 0.5f, 1);
            isSliding = true;
        }
        else
        {
            slideSFX.Stop();
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