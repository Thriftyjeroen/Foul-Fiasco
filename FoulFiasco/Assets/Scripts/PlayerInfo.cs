using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int score = 0;
    public float speed = 0.1f;

    float time;

    TMP_Text scoreText;

    private void Start()
    {
        //object does not get destroyed when a new scene is loaded
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        //if there is a game object with the "score" tag 
        if (GameObject.FindGameObjectWithTag("Score") != null)
        {
            //scoreText gets assigned to the game object with the "score" tag, at the TMP_text component
            scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();
        }
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;

        //if the time is higher than 0,1
        if (time > 0.1f)
        {
            //1 gets added to score
            score++;
            //time reset to 0
            time = 0;
        }

        //if there is a gameobject with the tag "score"
        if (GameObject.FindGameObjectWithTag("Score")  != null)
        {
            //scoreText is set to score variale to string
            scoreText.text = score.ToString();
        }

        //switch for the movement speed
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
