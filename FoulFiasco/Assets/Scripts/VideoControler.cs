using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoControler : MonoBehaviour
{
    [SerializeField] VideoPlayer video;
    [SerializeField] GameObject gO;
    void Start()
    {
        video.Stop();
        if (PlayerPrefs.GetString("Running")=="false")
        {
            StartCoroutine(Timer(2, video.Play));
            StartCoroutine(Timer(8.6f, Activate));
        }
        else Activate();

    }
    IEnumerator Timer( float time, Action action)// Action is de actie die gerunt word nadat de timer af is gelopen dat kan zijn: een method runnen of een regel code runnen
    {
        yield return new WaitForSeconds(time);
        action();
    }
    void Activate()
    {
        PlayerPrefs.SetString("Running", "True");
        gameObject.SetActive(false);
        gO.SetActive(true);
    }
}
