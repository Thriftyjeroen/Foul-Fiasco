using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using System.IO;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.SceneManagement;

public class ScoreBoardManager : MonoBehaviour
{
    [SerializeField] TMP_Text scores; // Inits the scores text
    ScoresWrapper wrapper;
    string file;

    string scoresFilePath = Path.Combine(Application.dataPath, "Resources/scores.json");
    string downloadExePath = Path.Combine(Application.dataPath, "Resources/download.exe");

    private void Awake()
    {
        scores.text = "Loading scores...";
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            try
            {
                TextAsset exeFile = Resources.Load<TextAsset>("Text/download"); // Loads the download exe into memory
                File.WriteAllBytes(downloadExePath, exeFile.bytes); // Sets the exe up in the correct place

                if (File.Exists(scoresFilePath)) // Checks if the scores file exists
                {
                    File.Delete(scoresFilePath); // Deletes the scores file
                }

                Process p = new Process(); // Starts a new process object
                p.StartInfo.FileName = downloadExePath; // Inits the process to run the download program
                p.Start(); // Starts the process

                StartCoroutine(Load()); // Starts a coroutine
            }
            catch
            {
                scores.text = "Failed to get scoreboard, please try again later";
            }
        }
        else
        {
            scores.text = "No internet connection, cannot download scores";
        }

    }

    // Loads the scores file
    IEnumerator Load()
    {
        for (int i = 0; i < 15; i++) // Repeats 15 times
        {
            scores.text = "Loading scores...";
            yield return new WaitForSeconds(0.5f); // Waits half a second
            try
            {
                file = File.ReadAllText(scoresFilePath); ; // Loads the json file as a TextAsset

                wrapper = JsonUtility.FromJson<ScoresWrapper>(file); // Makes a list of ScoreEntry objects from the json

                List<ScoreEntry> scoresList = wrapper.scores; // Sets a list of scores to the wrappers scores

                scores.text = "Scoreboard";

                for (int j = 0; j < 10; j++) // Repeats 10 times
                {
                    scores.text = scores.text + $"\n===={j + 1}====\n{scoresList[j].name} - {scoresList[j].score}";
                }
                break;
            }
            catch
            {
                scores.text = "Failed to get scoreboard, please try again later";
            }
        }
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

// Define a class to represent a single score entry
[System.Serializable]
public class ScoreEntry
{
    public string name;
    public long score;
}

// Define a class to wrap the list of score entries
[System.Serializable]
public class ScoresWrapper
{
    public List<ScoreEntry> scores;
}