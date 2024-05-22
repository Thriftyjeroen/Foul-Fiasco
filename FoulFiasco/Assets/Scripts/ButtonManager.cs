using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    PlayerInfo playerInfo;
    [SerializeField] GameObject gO;

    public void Start()
    { playerInfo = FindAnyObjectByType<PlayerInfo>(); }//the first script found in the project will with this code be connected with the variable playerInfo
    public void ChangeScene(string scene)//this method will change the scene. It wil in our situation always be called by a butten, bud it ask for a string as a parameter witch will be given in the inspector (THX, alkan for relising this is possible)
    {
        if (!(scene == "Game" && !(PlayerPrefs.GetInt("Coins") > 0)))//as long the scene is not Game and the coins are not higher than 0 the code will not run, every other situation it will run
        {
            gO.SetActive(true);//the gameObject thats connected in the inspector with gO will be activated
            playerInfo.score = 0;//the score variable of PlayerInfo script thats connected with the playerInfo variable will be set to 0
            StartCoroutine(LoadScene(scene));//the StartCouratine method will start a coroutine with means that if it returns a yield it wil run the method again in the next frame unless the couratine will be stopped or completed
        }
    }
    IEnumerator LoadScene(string loadScene, int time = 4)//this method will load a scene with the given scene after the 4 secconds has past
    {
        yield return new WaitForSeconds(time);//this code wil return a yield as long the time in secconds given in WaitForSeconds (that is what i understand from the documentation)
        SceneManager.LoadScene(loadScene);//the LoadScene from SceneManager will load a scene based on its name or number. Witch means u can load a scene with a string or int
    }
    public void LeaveGame()//this method makes sure the application will quit.
    {
        PlayerPrefs.SetString("Running", "false");//if the user desides to quit the game the playerPref Running wil get the falue "false" becouse the aplication will not run after the next line of code
        Application.Quit();//if the game is a build the Aplication will quit. otherwise this line of code will not work
    }
}
