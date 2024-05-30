using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteStartingPlayerPref : MonoBehaviour
{
    // Runs as soon as possible
    private void Awake()
    {
        // Deletes a key
        PlayerPrefs.DeleteKey("startingGame");
    }
}
