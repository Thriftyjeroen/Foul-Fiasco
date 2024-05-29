using UnityEngine;

public class MapMovement : MonoBehaviour
{
    // Script variable
    PlayerInfo playerInfo;

    private void Start()
    {
        //initialized playerinfo
        playerInfo = FindAnyObjectByType<PlayerInfo>();
    }

    private void Update()
    {
        //if the x position is lower or equal to 60
        if (transform.position.x <= -60)
        {
            //current game object gets destroyed
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        //new position is vector3 with the (x position - player speed), the z and y stay the same 
        transform.position = new Vector3(transform.position.x - playerInfo.speed, transform.position.y, transform.position.z);
    }
}
