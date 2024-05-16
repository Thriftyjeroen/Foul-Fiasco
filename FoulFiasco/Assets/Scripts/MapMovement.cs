using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    PlayerInfo playerInfo;
    [SerializeField] bool tutorial;

    private void Start()
    {
        playerInfo = FindAnyObjectByType<PlayerInfo>();
    }

    private void Update()
    {
        if (!tutorial)
        {
            if (transform.position.x <= -60)
            {
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - playerInfo.speed, transform.position.y, transform.position.z);
    }
}
