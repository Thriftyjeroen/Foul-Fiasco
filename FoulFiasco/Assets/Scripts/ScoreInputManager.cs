using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class ScoreInputManager : MonoBehaviour
{
    // Draggable variable
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_InputField inputName;
    [SerializeField] Button button;
    [SerializeField] AudioSource clicker;
    PlayerInfo playerInfo;
    public ScoreUploader scoreUploader;

    // Start is called before the first frame update
    void Start()
    {
        //playerinfo gets assigned to the playerinfo object
        playerInfo = FindAnyObjectByType<PlayerInfo>();

        score.text = $"Score: {playerInfo.score}";
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Return) && button.enabled == true)
        {
            button.enabled = false;
            Upload();
        }
    }

    public void Upload()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            button.enabled = false;
            if (inputName.text.Length > 0)
            {
                try
                {
                    score.text = $"Uploading score....";
                    scoreUploader.Upload(inputName.text, playerInfo.score);
                }
                catch
                {
                    score.text = "Antivirus blocked uploading :(";
                }
            }
        }
        else
        {
            score.text = $"No network connection, cannot upload score";
        }
        StartCoroutine(Wait());



        IEnumerator Wait()
        {
            yield return new WaitForSeconds(5f); // Waits five seconds
            SceneManager.LoadScene("MainMenu");
        }
    }
}
