using UnityEngine;

public class MapMovement : MonoBehaviour
{
    PlayerInfo playerInfo;
    [SerializeField] bool tutorial;

    private void Start()
    {
        //initialized playerinfo
        playerInfo = FindAnyObjectByType<PlayerInfo>();
    }

    private void Update()
    {
        //when tutorial is false 
        if (!tutorial)
        {
            //if the x position is lower or equal to 60
            if (transform.position.x <= -60)
            {
                //current game object gets destroyed
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        //nieuwe positie is vector3 met de (x positie - player speed), de z en y blijven het zelfde 
        transform.position = new Vector3(transform.position.x - playerInfo.speed, transform.position.y, transform.position.z);
    }
}
