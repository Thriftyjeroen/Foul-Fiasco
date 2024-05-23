using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    // Variable for the PlayerInfo script
    PlayerInfo playerInfo;
  
    // Variable for the PlayerMovement script
    PlayerMovement playerMovement;

    // Variable for the RefManager script
    RefManager refManager;

    // Start is called before the first frame update
    void Start()
    {
        // Fetches the PlayerInfo script from the PlayerInfo object
        playerInfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
        // Fetches the PlayerMovement script
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        // Fetches the RefManager script from the ref object
        refManager = GameObject.Find("Ref").GetComponent<RefManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpriteRotate();
    }

    void PlayerSpriteRotate()
    {
        // Fetch the speed from the PlayerInfo script
        float speed = playerInfo.speed;

        // Calculate the rotation angle based on the speed
        float rotationAngle = speed * Time.deltaTime * -360f;

        // Apply the rotation to the sprite
        transform.Rotate(Vector3.forward, rotationAngle);
    }
}
