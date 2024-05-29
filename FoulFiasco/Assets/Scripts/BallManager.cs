using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    // Rigidbody variable
    Rigidbody2D rb;
    // Script variable
    PlayerInfo playerInfo;
    float shootPower = 0;
    bool playerShoot = false;
    // Audiosource draggable
    [SerializeField] AudioSource goalSFX;
    [SerializeField] AudioSource goalFailSFX;
    [SerializeField] AudioSource kickSFX;

    // Runs on start
    private void Start()
    {
        // Finds the rigidbody on this GameObject
        rb = GetComponent<Rigidbody2D>();
        // Finds the PlayerInfo script on a GameObject with PlayerInfo script
        playerInfo = FindAnyObjectByType<PlayerInfo>();
    }

    // Runs every frame
    private void Update()
    {
        // If bool is true, do this
        if (playerShoot)
        {
            //if the space key gets released
            if (Input.GetKeyUp(KeyCode.Space))
            {
                // Plays the kicking sound effect
                kickSFX.Play();
                //the velocity will be set to x = 15 and y = shooting power (the map is moving, so 15 is to equalise the ball speed with map speed)
                rb.velocity = new Vector2(15, shootPower);
                //shootpower gets reset to 0
                shootPower = 0;
            }
        }
    }

    // runs on a fixed frame
    private void FixedUpdate()
    {
        //when the bool playershoot true is
        if (playerShoot)
        {
            //when the user presses the space button
            if (Input.GetKey(KeyCode.Space))
            {
                //+0.50 gets added to shootpower
                shootPower += 0.50f;

                //if shootpower is over or equal to 30
                if (shootPower >= 30)
                {
                    //shootpower gets set back to 30
                    shootPower = 30;
                }
            }
        }
        //shows the charge in the shootbar, the amount filled is shootpower : 30
        GameObject.FindGameObjectWithTag("ShootBar").GetComponent<Image>().fillAmount = shootPower / 30;
    }

    //when trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when the player walks to the ball
        if (collision.tag == "Player")
        {
            //playershoot gets set to true
            playerShoot = true;
        }

        //if the collision tag is Goal
        if (collision.tag == "Goal")
        {
            // Plays the goal sound effect
            goalSFX.Play();
            //100 gets added to the current score of the player
            playerInfo.score += 100;
        }

        //if the collision tag is GoalMiss
        if (collision.tag == "GoalMiss")
        {
            // Plays the goal fail sound effect
            goalFailSFX.Play();
        }
    }

    //when the player does not touch the ball
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //playershoot gets set to false
            playerShoot = false;
        }
    }
}
