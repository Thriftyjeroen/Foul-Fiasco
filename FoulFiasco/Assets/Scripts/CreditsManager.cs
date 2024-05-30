using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    [SerializeField] TMP_Text credits; // Inits the credits text
    [SerializeField] Camera cam; // Inits the cam
    float speed = 0.01f; // Inits the speed 

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
        if (Input.GetKeyDown(KeyCode.Space)) // If space is held, do this
        {
            speed = 0.10f;
        }
        if (Input.GetKeyUp(KeyCode.Space)) // If not...
        {
            speed = 0.01f;
        }
        cam.transform.position -= new Vector3(0, speed, 0); // Moves the camera down with 0.01 units
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
