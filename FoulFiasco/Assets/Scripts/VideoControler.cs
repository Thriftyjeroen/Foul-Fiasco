using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoControler : MonoBehaviour
{//Daniël: I got the code for starting ans pausing the video and using VideoPlayer as a type from this YT video: https://www.youtube.com/watch?v=fnCNBVdUNcM
    [SerializeField] VideoPlayer video;//with VideoPlayer as a type u can connect a video to the variable
    void Start()
    {
        Thread.Sleep(100);
        video.Stop();//the video will be stopped when the scene start
        StartCoroutine(Timer(1f, video.Play));//the StartCouratine method will start a coroutine with means that if it returns a yield it wil run the method again in the next frame unless the couratine will be stopped or completed, there is also a method given as a argument wich will be runned when the coroutine is done. in this case the method will start playing the video
        StartCoroutine(Timer(7.6f, LoadScene));//the 6.6 is exactly the time the game object will be active. 1 seconds from the timer of line 15 and 6.6 secconds witch is how long the video is after that it will run the activate method
    }
    IEnumerator Timer(float time, Action action)// this method will runn until the time has passed that is given in the time parameter, after that it will run the method given in the action parameter. The Action type makes it possible to store a method as a value
    {
        yield return new WaitForSeconds(time);
        action();
    }
    void LoadScene()
    {
        PlayerPrefs.SetString("startingGame", "");
        SceneManager.LoadScene("MainMenu"); 
    }
}
