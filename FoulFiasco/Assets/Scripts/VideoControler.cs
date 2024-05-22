using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoControler : MonoBehaviour
{//Daniël: I got the code for starting ans pausing the video and using VideoPlayer as a type from this YT video: https://www.youtube.com/watch?v=fnCNBVdUNcM
    [SerializeField] VideoPlayer video;//with VideoPlayer as a type u can connect a video to the variable
    [SerializeField] GameObject gO;
    void Start()
    {
        video.Stop();//the video will be stopped when the scene start
        if (PlayerPrefs.GetString("Running") == "false")//if the aplication starts the playerPref running will be false witch means the following code will run
        {
            StartCoroutine(Timer(2, video.Play));//the StartCouratine method will start a coroutine with means that if it returns a yield it wil run the method again in the next frame unless the couratine will be stopped or completed, there is also a method given as a argument wich will be runned when the coroutine is done. in this case the method will start playing the video
            StartCoroutine(Timer(8.6f, Activate));//the 8.6 is exactly the time the game object will be active. 2 seconds from the timer of line 15 and 6.6 secconds witch is how long the video is after that it will run the activate method
        }
        else Activate();//if the running playerprefs has not the value "false" this method will imediatly run

    }
    IEnumerator Timer(float time, Action action)// this method will runn until the time has passed that is given in the time parameter, after that it will run the method given in the action parameter. The Action type makes it possible to store a method as a value
    {
        yield return new WaitForSeconds(time);
        action();
    }
    void Activate()
    {
        PlayerPrefs.SetString("Running", "True");//the playerpref with the running key will get the value overwriten and becouse there is no boolean datatype I wrote it out in a string data type to get the same resulds
        gameObject.SetActive(false);//this gameObject will set false so the user can see only the canvas that will be set active in the next line
        gO.SetActive(true);
    }
}
