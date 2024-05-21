using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using System.IO;
using static UnityEngine.EventSystems.EventTrigger;

public class ScoreBoardManager : MonoBehaviour
{
    [SerializeField] TMP_Text scores; // Inits the scores text
    ScoresWrapper wrapper;
    TextAsset file;

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists($"{Application.dataPath}/Resources/Text/scores.json")) // Checks if the scores file exists
        {
            File.Delete($"{Application.dataPath}/Resources/Text/scores.json"); // Deletes the scores file
        }
        UnityEditor.AssetDatabase.Refresh(); // Refreshes the folder

        scores.text = "Loading scores...";

        Process p = new Process(); // Starts a new process object
        p.StartInfo.FileName = $"{Application.dataPath}/Resources/Text/download.exe"; // Inits the process to run the download program
        p.Start(); // Starts the process

        StartCoroutine(Load()); // Starts a coroutine
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
                UnityEditor.AssetDatabase.Refresh();
                file = Resources.Load<TextAsset>("Text/scores"); // Loads the json file as a TextAsset

                wrapper = JsonUtility.FromJson<ScoresWrapper>(file.text); // Makes a list of ScoreEntry objects from the json

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