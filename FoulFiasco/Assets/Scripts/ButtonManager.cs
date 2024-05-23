using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    PlayerInfo playerInfo;
    [SerializeField] GameObject gO;

    public void Start()
    {
        playerInfo = FindAnyObjectByType<PlayerInfo>();
        if (!(PlayerPrefs.HasKey("Coins"))) PlayerPrefs.SetInt("Coins", 3);
    }
    //public scene enumtype, a scene gets selected here at the inspector of the gameObject where this script is assigned to
    public void ChangeScene(string scene)
    {
        if (!(scene == "Game" && !(PlayerPrefs.GetInt("Coins") > 0)))//if the scene is not "game" and the playercoins is not above 0
        {
            gO.SetActive(true);
            //playerscore gets set to 0
            playerInfo.score = 0;

            //if the scene is "game", a coroutine will start tha loads the scene
            if (scene == "Game")
            {
                StartCoroutine(LoadScene(scene));
            }
        }
    }
    IEnumerator LoadScene(string loadScene,int time = 4) 
    {
        //sets a delay for 4 seconds
        yield return new WaitForSeconds(time);
        //loading scene loads the selected scene, with as input a string or interger, but since we use enum, we use the enum that is assigned to the variable enumType and the value of that
        SceneManager.LoadScene(loadScene);
    } 

    //this method will close the game, this method gets assigned to a button
    public void LeaveGame()
    {
        //sets strings for playerprefs 
        PlayerPrefs.SetString("Running", "false");
        //will stop the application
        Application.Quit();
    }
    /*public enum Scene//dit is een enumerator, hier kan je een aantal enums(soort variabele) maken met een waarde als integer. die werkt als een array of list, maar het verschil is dat je die ook kan veranderen op de manier die is uitgequote. ook is het zo dat als je een variabele maakt zoals op regel 7 met de naam van de enum en vervolgens het script verbind met een gameObject dat je dan tussen de enums kan kiezen via de inspector
    {//als je een nieuwe enum maakt zorg dan dat je een comma plaats tussen de enum met de laatste enum geen comma erachter
        MainMenu/* = (getal naar keuze),
        Game,
        Tutorial,
        CoinMaster,
        Scores,
        CutScene,
        Settings,
        Credits
    }*/
}
