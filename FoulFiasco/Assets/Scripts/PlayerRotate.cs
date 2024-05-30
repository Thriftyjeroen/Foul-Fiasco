using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    // Variable for the PlayerInfo script
    PlayerInfo playerInfo;
    // Variable for the PlayerMovement script
    PlayerMovement playerMovement;
    // Variable for the original rotation of the object
    public Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the value of the original rotation
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Fetches the PlayerMovement script
        playerMovement = GetComponent<PlayerMovement>();
        // Fetches the PlayerInfo script from the PlayerInfo object
        playerInfo = GameObject.FindGameObjectWithTag("PlayerInfo").GetComponent<PlayerInfo>();

        // Calls method
        PlayerSpriteRotate();
    }

    void PlayerSpriteRotate()
    {
        // If statement that gets excecuted when the player is sliding
        if (playerMovement.isSliding)
        {
            // Resets rotation to the original rotation
            transform.rotation = originalRotation;
        }
        else
        {
            // Fetch the speed from the PlayerInfo script
            float speed = playerInfo.speed;

            // Calculate the rotation angle based on the speed
            float rotationAngle = speed * Time.deltaTime * 10 * -360f;

            // Apply the rotation to the sprite
            transform.Rotate(Vector3.forward, rotationAngle);
        }
    }
}
