using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ScoreUploader : MonoBehaviour
{
    ScoresWrapper wrapper; // Initialises the score wrapper
    TextAsset file;

    /// <summary>
    /// Uploads a score with name and score
    /// </summary>
    /// <param name="pName"></param>
    /// <param name="pScore"></param>
    public void Upload(string pName, long pScore)
    {
        if (File.Exists($"{Application.dataPath}/Resources/Text/scores.json")) // Checks if the scores file exists
        {
            File.Delete($"{Application.dataPath}/Resources/Text/scores.json"); // Deletes the scores file
        }
        UnityEditor.AssetDatabase.Refresh(); // Refreshes the folder

        Process p = new Process(); // Starts a new process object
        p.StartInfo.FileName = $"{Application.dataPath}/Resources/Text/download.exe"; // Inits the process to run the download program
        p.Start(); // Starts the process

        StartCoroutine(Load(pName, pScore)); // Starts a coroutine

        // Loads the scores file
        IEnumerator Load(string pName, long pScore)
        {
            for (int i = 0; i < 15; i++) // Repeats 15 times
            {
                yield return new WaitForSeconds(0.5f); // Waits half a second
                try
                {
                    UnityEditor.AssetDatabase.Refresh();
                    file = Resources.Load<TextAsset>("Text/scores"); // Loads the json file as a TextAsset

                    wrapper = JsonUtility.FromJson<ScoresWrapper>(file.text); // Makes a list of ScoreEntry objects from the json

                    List<ScoreEntry> scoresList = wrapper.scores; // Sets a list of scores to the wrappers scores

                    for (int j = 0; j < 10; j++) // Repeats 10 times
                    {
                        if (pScore >= scoresList[j].score) // If score uploading is higher than the old score here, do this
                        {
                            ScoreEntry newEntry = new ScoreEntry(); // Makes a new 
                            newEntry.score = pScore;
                            newEntry.name = pName;
                            scoresList.Insert(j, newEntry);
                            scoresList.RemoveAt(10);
                            string newData = JsonUtility.ToJson(wrapper, true);
                            File.WriteAllText($"{Application.dataPath}/Resources/Text/scores.json", newData);
                            Process p = new Process(); // Starts a new process object
                            p.StartInfo.FileName = $"{Application.dataPath}/Resources/Text/upload.exe"; // Inits the process to run the download program
                            p.Start(); // Starts the process
                            p.WaitForExit();
                            break;
                        }
                    }
                    break;
                }
                catch
                {
                    // Do nothing
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
}

