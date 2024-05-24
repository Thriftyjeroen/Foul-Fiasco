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

    //each frame 
    private void Update()
    {
        //when the bool playershoot true is
        if (playerShoot)
        {
            //when the user presses the space button
            if (Input.GetKey(KeyCode.Space))
            {
                //+0.15 gets added to shootpower
                shootPower += 0.15f;

                //if shootpower is over or equal to 30
                if (shootPower >= 30)
                {
                    //shootpower gets set back to 30
                    shootPower = 30;
                }
            }
            //if the space key gets released
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //the velocity will be set to x = 15 and y = shooting power (the map is moving, so 15 is to equalise the ball speed with map speed)
                rb.velocity = new Vector2(15, shootPower);
                //shootpower gets reset to 0
                shootPower = 0;
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
            //100 gets added to the current score of the player
            playerInfo.score += 100;
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
