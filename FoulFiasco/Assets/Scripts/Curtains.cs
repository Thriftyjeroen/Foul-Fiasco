using UnityEngine;
using UnityEngine.UI;

public class Curtains : MonoBehaviour
{// Daniël: i needed this video to relise abaut Time.deltaTime: https://www.youtube.com/watch?v=POq1i8FyRyQ
    //[SerializeField] GameObject gO;
    [SerializeField] Image curtian1, curtain2;//the image that are connected in the inspector will be stored in the 2 varables decleared in this line
    [SerializeField] float time = 0;//this varable will show in the inspector (for testing purpose) how long the code is running within the decleared time. later it is also used to calculate how much of the image the user can't see
    int iTime = 2;//this is the time it should take in secconds to show or remove the image
    bool curtainsClosed = true;
    public void Update()
    {
        if (!PlayerPrefs.HasKey("startingGame"))
        {
            //print("test2");
            if (curtainsClosed)//when the curtains are open (the user can not see the picktures) the following the aplication will run the following code
            {
                if (time < iTime) time += Time.deltaTime;//if the time is smaller than the value of itime the value of time will be increased with the time between the frames
                else SetActive(false);
                ImageFillAmount();// the method ImagefillAmount will here be called
            }
            else //if the curtians are open this code will run witch is almost the same. the only difference is that it does the opisite of the code above with the exeption of the setActive line
            {
                if (time > 0) time -= Time.deltaTime;
                else SetActive(true);
                ImageFillAmount();
            }
        }
        else
        {
            //print("test");
            PlayerPrefs.DeleteKey("startingGame");//this code needs to run only 1 time, so to make it sure that it will after the 1 time in the whole game it will delete the key
            SetActive(false);
            time = iTime;//normaly the time is changed with the Time.deltaTime, bud because the curtens have to close the next time the value will be set so it wil close like it should
        }
    }
    void ImageFillAmount()//this method will change the value of the fillAmount from the 2 pictures
    {
        float persentage = 1 - (time / iTime);//the persentage will be calculated as a decimal.I do that by deviding the value of time with ITime, and becouse iTime is alswas bigger or the same value the answer will be the persentage in as a decimal. and to make sure the aplication does what I make sure that the value of persentage will be 1 - the rusuld, witch is stil a persentage
        curtian1.fillAmount = persentage;//the fillamount of both images will be set to the value of persentage
        curtain2.fillAmount = persentage;
    }
    void SetActive(bool pCurtainsClosed)//this method will change the value of curtainsClosed and deactivate the gameObject
    {
        curtainsClosed = pCurtainsClosed;
        gameObject.SetActive(false);
    }
}
