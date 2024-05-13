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
    public enum Scene//in the enumarator u can make a group of values that has a name (keyword) for every keyword u make it will get automaticly a value that works like the index of a list of array. bud the diverence is that u can change the value that is shown by the first keyword where it is quoted out. u can also select the keyword and value with the code on line 11 where in the inspector only the keywords will be shown
    {//if u make a enum u have to write a , at the end exept the last one
        MainMenu/* = (number of choise)*/,
        CoinMaster,
        Credits,
        Game,
        Scores,
        Settings,
        CutScene
    }
}
