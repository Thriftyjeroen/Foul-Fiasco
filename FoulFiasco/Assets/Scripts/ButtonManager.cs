using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    PlayerInfo playerInfo;

    public void Start()
    {
        playerInfo = FindAnyObjectByType<PlayerInfo>();
        if (!(PlayerPrefs.HasKey("Coins"))) PlayerPrefs.SetInt("Coins", 3);
    }
    public Scene enumType;//hier word de scene bepaald op basis van de scene die geselecteerd word in de inspector van de gameObject waar dit script aan verbonden is
    public void ChangeScene(string scene)
    {
        if (!(scene == "Game" && !(PlayerPrefs.GetInt("Coins") > 0)))//zolang de PlayerPrefs (wat
        {
            playerInfo.score = 0;
            SceneManager.LoadScene(scene);//de loadscene van scenemanager laat de aangegeven scene met als input een string of een interger, en sinds er een enum gebruiken gebruiken we de enum die verbonden is met de variabele enumType en daar de waarde van.
        }
    }
    public void LeaveGame()//deze method zorgt dat de aplicatie af gesloten kan worden op basis van een knop (wat deze method laat runnen)
    {
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
