using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    [SerializeField] TMP_Text credits; // Inits the credits text
    [SerializeField] Camera cam; // Inits the cam

    // Start is called before the first frame update
    void Start()
    {
        var file = Resources.Load<TextAsset>("Text/credits"); // Loads the credits text file
        string content = file.text; // Loads the content of the text file
        credits.text = content; // Sets the credits to the content
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position -= new Vector3(0, 0.01f, 0); // Moves the camera down with 0.01 units
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
