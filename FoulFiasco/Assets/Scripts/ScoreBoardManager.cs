using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using System.IO;
using static UnityEngine.EventSystems.EventTrigger;
using Unity.VisualScripting;

public class ScoreBoardManager : MonoBehaviour
{
    [SerializeField] TMP_Text scores; // Inits the scores text
    ScoresWrapper wrapper;
    TextAsset file;
    List<ScoreEntry> scoresList;
    PlayerInfo playerInfo;
    Process p = new Process(); // Starts a new process object

    // Start is called before the first frame update
    void Start()
    {
        playerInfo = FindAnyObjectByType<PlayerInfo>();

        if (File.Exists($"{Application.dataPath}/Resources/Text/scores.json")) // Checks if the scores file exists
        {
            File.Delete($"{Application.dataPath}/Resources/Text/scores.json"); // Deletes the scores file
        }

        p.StartInfo.FileName = $"{Application.dataPath}/Resources/Text/download.exe"; // Inits the process to run the download program
        p.Start(); // Starts the process

        scores.text = "Loading scores...";

        StartCoroutine(Load()); // Starts a coroutine
    }

    void Update()
    {
        if (Resources.Load<TextAsset>("Text/scores") == null)
        {
            UnityEditor.AssetDatabase.Refresh(); // Refreshes the folder
        }
    }

    // Loads the scores file
    IEnumerator Load()
    {
        Upload();

        for (int i = 0; i < 15; i++) // Repeats 15 times
        {
            scores.text = "Loading scores...";
            yield return new WaitForSeconds(0.5f); // Waits half a second
            try
            {
                UnityEditor.AssetDatabase.Refresh();

                scores.text = "Scoreboard";

                file = Resources.Load<TextAsset>("Text/scores"); // Loads the json file as a TextAsset

                wrapper = JsonUtility.FromJson<ScoresWrapper>(file.text); // Makes a list of ScoreEntry objects from the json

                scoresList = wrapper.scores; // Sets a list of scores to the wrappers scores

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


    void Upload()
    {
        file = Resources.Load<TextAsset>("Text/scores"); // Loads the json file as a TextAsset

        wrapper = JsonUtility.FromJson<ScoresWrapper>(file.text); // Makes a list of ScoreEntry objects from the json

        scoresList = wrapper.scores; // Sets a list of scores to the wrappers scores

        for (int i = 0; i < 10; i++)
        {
            if (playerInfo.score > scoresList[i].score)
            {
                scoresList[i].score = playerInfo.score;

                p.StartInfo.FileName = $"{Application.dataPath}/Resources/Text/upload.exe"; // Inits the process to run the download program
                break;
            }
        }

        var str = JsonUtility.ToJson(scoresList, true);
        JsonUtility.FromJsonOverwrite($"{Application.dataPath}/Resources/Text/scores", str);
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