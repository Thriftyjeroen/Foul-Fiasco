using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreInputManager : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_InputField name;
    PlayerInfo playerInfo;
    public ScoreUploader scoreUploader;

    // Start is called before the first frame update
    void Start()
    {

        //playerinfo gets assigned to the playerinfo object
        playerInfo = FindAnyObjectByType<PlayerInfo>();

        score.text = $"Score: {playerInfo.score}";
    }

    public void Upload()
    {
        if (name.text.Length > 0)
        {
            scoreUploader.Upload(name.text, playerInfo.score);
            score.text = $"Uploading score....";
        }
        StartCoroutine(Wait());


        IEnumerator Wait()
        {
            yield return new WaitForSeconds(5f); // Waits five seconds
            SceneManager.LoadScene("MainMenu");
        }
    }
}
