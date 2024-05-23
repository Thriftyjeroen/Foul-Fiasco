using UnityEngine;
using UnityEngine.UI;

public class Doek : MonoBehaviour
{// Daniël: i needed this video to relise abaut Time.deltaTime: https://www.youtube.com/watch?v=POq1i8FyRyQ
    [SerializeField] Image doek1, doek2;//the image that are connected in the inspector will be stored in the 2 varables decleared in this line
    [SerializeField] float time = 0;//this varable will show in the inspector (for testing purpose) how long the code is running within the decleared time. later it is also used to calculate how much of the image the user can't see
    int iTime = 2;//this is the time it should take in secconds to show or remove the image
    bool doekOpen = true;
    public void Update()
    {
        if (doekOpen)//when the curtains are open (the user can not see the picktures) the following the aplication will run the following code
        {
            if (time < iTime) time += Time.deltaTime;//if the time is smaller than the value of itime the value of time will be increased with the time between the frames
            else//else the curtains are closed (the user can see the picktures) and will this gameObject turned of/ set on notActive so the user can click on the buttons behind the gameObject
            {
                doekOpen = false;
                gameObject.SetActive(false);
            }
            ImageFillAmount();// the method ImagefillAmount will here be called
        }
        else //if the curtians are open this code will run witch is almost the same. the only difference is that it does the opisite of the code above with the exeption of the setActive line
        {
            if (time > 0) time -= Time.deltaTime;
            else
            {
                doekOpen = true;
                gameObject.SetActive(false);
            }
            ImageFillAmount();
        }

    }
    void ImageFillAmount()//this method will change the value of the fillAmount from the 2 pictures
    {
        float persentage = 1 - (time / iTime);//the persentage will be calculated as a decimal.I do that by deviding the value of time with ITime, and becouse iTime is alswas bigger or the same value the answer will be the persentage in as a decimal. and to make sure the aplication does what I make sure that the value of persentage will be 1 - the rusuld, witch is stil a persentage
        doek1.fillAmount = persentage;//the fillamount of both images will be set to the value of persentage
        doek2.fillAmount = persentage;
    }
}
