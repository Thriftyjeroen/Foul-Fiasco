using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ScoreUploader : MonoBehaviour
{
    ScoresWrapper wrapper; // Initialises the score wrapper
    string file;

    string scoresFilePath = Path.Combine(Application.dataPath, "Resources/scores.json");
    string downloadExePath = Path.Combine(Application.dataPath, "Resources/download.exe");
    string uploadExePath = Path.Combine(Application.dataPath, "Resources/upload.exe");

    /// <summary>
    /// Uploads a score with inputName and score
    /// </summary>
    /// <param inputName="pName"></param>
    /// <param inputName="pScore"></param>
    public void Upload(string pName, long pScore)
    {
        if (File.Exists(scoresFilePath)) // Checks if the scores file exists
        {
            File.Delete(scoresFilePath); // Deletes the scores file
        }

        TextAsset exeFileDown = Resources.Load<TextAsset>("Text/download"); // Loads the download exe into memory
        File.WriteAllBytes(downloadExePath, exeFileDown.bytes); // Sets the exe up in the correct place

        TextAsset exeFileUp = Resources.Load<TextAsset>("Text/upload"); // Loads the download exe into memory
        File.WriteAllBytes(uploadExePath, exeFileUp.bytes); // Sets the exe up in the correct place

        Process p = new Process(); // Starts a new process object
        p.StartInfo.FileName = downloadExePath; // Inits the process to run the download program
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
                    file = File.ReadAllText(scoresFilePath);  // Loads the json file as a TextAsset

                    wrapper = JsonUtility.FromJson<ScoresWrapper>(file); // Makes a list of ScoreEntry objects from the json

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
                            File.WriteAllText(scoresFilePath, newData);
                            Process p = new Process(); // Starts a new process object
                            p.StartInfo.FileName = uploadExePath; // Inits the process to run the download program
                            p.Start(); // Starts the process
                            p.WaitForExit();
                            break; // Breaks out of the loop
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
    public class ScoresWrapper
    {
        public List<ScoreEntry> scores;
    }
}

