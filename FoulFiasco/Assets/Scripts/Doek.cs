using UnityEngine;
using UnityEngine.UI;

public class Doek : MonoBehaviour
{// voor de doeken de time.delta time had ik de volgende video nodig om er achter te komen: https://www.youtube.com/watch?v=POq1i8FyRyQ
    [SerializeField] Image doek1;
    [SerializeField] Image doek2;
    [SerializeField] float time = 0;
    int iTime = 4;
    public bool doekOpen = false;
    public void Update()
    {
        if (doekOpen)
        {
            if (time < iTime) time += Time.deltaTime;
            else
            {
                doekOpen = false;
                gameObject.SetActive(false);
            }
            if (doek1.fillAmount != 0) ImageFillAmount();
        }
        else
        {
            if (time > 0) time -= Time.deltaTime;
            else
            {
                doekOpen = true;
                gameObject.SetActive(false);
            }
            if (doek1.fillAmount != 1) ImageFillAmount();
        }

    }
    void ImageFillAmount()
    {
        float persentage = 1 - (time / iTime);
        doek1.fillAmount = persentage;
        doek2.fillAmount = persentage;
    }
}
