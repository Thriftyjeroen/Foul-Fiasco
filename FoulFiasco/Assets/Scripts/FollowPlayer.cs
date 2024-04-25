using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float delay;
    List<Vector3> playerPosList;


    void Awake()
    {
        playerPosList = new List<Vector3>();
    }

    private void FixedUpdate()
    {
        Vector3 playerPos = player.transform.position;

        if (playerPosList.Count == 0)
        {
            playerPosList.Add(playerPos);
            return;
        }
        else if (playerPosList[playerPosList.Count - 1] != playerPos)
        {
            playerPosList.Add(playerPos);
        }

        else if (transform.position.y != playerPos.y)
        {
            playerPosList.Add(playerPos);
        }

        if (playerPosList.Count > delay)
        {
            transform.position = playerPosList[0];
            playerPosList.RemoveAt(0);
        }
    }
}