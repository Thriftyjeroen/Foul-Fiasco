using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public int score = 0;
    public float speed = 0.1f;

    float time;

    TMP_Text scoreText;

    private void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > 0.1f)
        {
            score++;
            time = 0;
        }

        scoreText.text = score.ToString();

        switch (score)
        {
            case 100:
                speed = 0.12f;
                break;

            case 250:
                speed = 0.14f;
                break;

            case 500:
                speed = 0.16f;
                break;

            case 1000:
                speed = 0.18f;
                break;

            case 1500:
                speed = 0.2f;
                break;

            case 2500:
                speed = 0.22f;
                break;
        }
    }
}
