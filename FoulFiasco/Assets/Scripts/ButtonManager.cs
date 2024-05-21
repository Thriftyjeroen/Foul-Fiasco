using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void Start()
    {
        if (!(PlayerPrefs.HasKey("Coins"))) PlayerPrefs.SetInt("Coins", 3);//if there is no playerPref with the key Coins it wil be crated and given 3 coins
    }
    public Scene enumType;//the scene wil be selected by the user/developer in the inspector and saved in this variable
    public void ChangeScene()
    {
        if (!((int)enumType == 3 && !(PlayerPrefs.GetInt("Coins") > 0)))//simply said, if the interger of the selected enum is not 3 and the coins is not higher than 0 the sene will not be changed
        {
            SceneManager.LoadScene((int)enumType);//the scene will be loaded based of the integer of the enum that is chosen in the inspector
        }
    }
    public void LeaveGame()//this method will quit the application
    {
        Application.Quit();
    }
    public void ChooseScene(string pSceneName)
    {
        if (!(pSceneName == "Tutorial" && !(PlayerPrefs.GetInt("Coins") > 0)))//zolang de PlayerPrefs (wat
        {
            SceneManager.LoadScene(pSceneName);//de loadscene van scenemanager laat de aangegeven scene met als input een string of een interger, en sinds er een enum gebruiken gebruiken we de enum die verbonden is met de variabele enumType en daar de waarde van.
        }
    }

    public enum Scene//dit is een enumerator, hier kan je een aantal enums(soort variabele) maken met een waarde als integer. die werkt als een array of list, maar het verschil is dat je die ook kan veranderen op de manier die is uitgequote. ook is het zo dat als je een variabele maakt zoals op regel 7 met de naam van de enum en vervolgens het script verbind met een gameObject dat je dan tussen de enums kan kiezen via de inspector
    {//als je een nieuwe enum maakt zorg dan dat je een comma plaats tussen de enum met de laatste enum geen comma erachter
        MainMenu/* = (getal naar keuze)*/,
        development,
        Game,
        Tutorial,
        CoinMaster,
        Scores,
        CutScene,
        Settings,
        Credits
    }
}
