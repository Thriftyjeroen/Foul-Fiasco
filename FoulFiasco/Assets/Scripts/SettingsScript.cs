using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    bool timeOn = true;
    [SerializeField] TMP_Text currentSetting;
    [SerializeField] AudioSource clicker;

    // Update is called once per frame
    void Update()
    {
        //if TimeOn is true, the text will change to "Time on, on the button itself"
        if(timeOn == true)
        {
            currentSetting.text = "Time normal";
        }
        //if TimeOn is false, the text "Time off" will show on the button itself
        else if (timeOn == false)
        {
            currentSetting.text = "Time slow";
        }
    }

    //method to change the bool value when button is pressed
    public void ChangeTime()
    {
        clicker.Play();
        //timescale 0.1 when Time on is true, also TimeOn will change to false
        if (timeOn == true)
        {
            Time.timeScale = 0.1f;
            timeOn = false;
        }
        //timescale 1 when Time on is false, and the bool Time on will change to true 
        else if (timeOn == false)
        {
            Time.timeScale = 1.0f;
            timeOn = true;
        }
    }

    //method to load main menu
    public void BackToMainMenu()
    {
        clicker.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
