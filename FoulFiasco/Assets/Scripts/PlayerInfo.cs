using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    MapMovement mapMovement;
    FollowPlayer followPlayer;
    public int score = 0;
    float time;
    bool speedDelay = true;

    private void Awake()
    {
        mapMovement = FindAnyObjectByType<MapMovement>();
        followPlayer = FindAnyObjectByType<FollowPlayer>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 0.05f)
        {
            score++;
            time = 0;
        }

        if (score % 100 == 0)
        {
            if (speedDelay)
            {
                mapMovement.speed = mapMovement.speed * 1.2f;
                followPlayer.delay = followPlayer.delay / 1.2f;
                speedDelay = false;
                StartCoroutine(BoolDelay());
            }
        }
    }

    IEnumerator BoolDelay()
    {
        yield return new WaitForSeconds(0.5f);
        speedDelay = true;
    }
}
