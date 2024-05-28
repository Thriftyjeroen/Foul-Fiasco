using System.Collections;
using System.Threading;
using UnityEngine;

public class mascot : MonoBehaviour
{
    float scale = 1;
    void Start()
    {
        StartCoroutine(Timer());
    }
    void newScale()
    { 
        transform.localScale = new Vector3(1, scale, 1);
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.15f);
        if (scale == 1) scale = 0.8f;
        else scale = 1;
        newScale();
    }

}
