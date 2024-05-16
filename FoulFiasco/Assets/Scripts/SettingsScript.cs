using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    bool physicsOn = true;
    [SerializeField] TMP_Text currentSetting;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if physicsOn is true, the text will change to "physics on, on the button itself"
        if(physicsOn == true)
        {
            currentSetting.text = "Physics on";
        }
        //if PhysicsOn is false, the text "Physics off" will show on the button itself
        else if (physicsOn == false)
        {
            currentSetting.text = "Physics off";
        }
    }

    //method to change the bool value when button is pressed
    public void ChangePhysics()
    {
        //timescale 0 when Physics on is true, also PhysicsOn will change to false
        if (physicsOn == true)
        {
            Time.timeScale = 0.0f;
            physicsOn = false;
        }
        //timescale 1 when physics on is false, and the bool physics on will change to true 
        else if (physicsOn == false)
        {
            Time.timeScale = 1.0f;
            physicsOn = true;
        }
    }

    //method to load main menu
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
