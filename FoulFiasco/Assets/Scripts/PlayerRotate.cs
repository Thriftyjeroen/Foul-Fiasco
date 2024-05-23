using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    // Variable for the PlayerInfo script
    PlayerInfo playerInfo;
  

    // Start is called before the first frame update
    void Start()
    {
        // Fetches the PlayerInfo script from the PlayerInfo object
        playerInfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
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
