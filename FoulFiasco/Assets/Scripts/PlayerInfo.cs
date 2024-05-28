using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int score = 0;
    public float speed = 0.1f;

    public bool startTime = true;

    float time;

    [SerializeField] TMP_Text scoreText;

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
        if (startTime)
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
        }

        //if there is a gameobject with the tag "score"
        if (scoreText != null)
        {
            //scoreText is set to score variale to string
            scoreText.text = score.ToString();
        }

        // Increse the speed a little bit
        if (speed < 0.3f) speed += 0.000005f;
    }
}
