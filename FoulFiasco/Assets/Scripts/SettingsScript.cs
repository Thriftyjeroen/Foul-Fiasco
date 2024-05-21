using UnityEngine;
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
        //als physics on true is word de text physics on getoont op de button
        if(physicsOn == true)
        {
            currentSetting.text = "Physics on";
        }
        //als physics on false is dan word de text physics off getoont op de button
        else if (physicsOn == false)
        {
            currentSetting.text = "Physics off";
        }
    }

    //method om de bool physics on te veranderen via de button
    public void ChangePhysics()
    {
        //als physicsOn op true is word de timescale op 0 gezet en physicsOn op false gezet
        if (physicsOn == true)
        {
            Time.timeScale = 0.0f;
            physicsOn = false;
        }
        //als physics on op false staat word de timescale op 1 gezet en physicsOn op true gezet
        else if (physicsOn == false)
        {
            Time.timeScale = 1.0f;
            physicsOn = true;
        }
    }

    //method om main menu te loaden
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
