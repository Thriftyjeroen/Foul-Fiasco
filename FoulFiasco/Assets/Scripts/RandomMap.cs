using UnityEngine;

public class RandomMap : MonoBehaviour
{
    [SerializeField] GameObject[] mapArray;
    [SerializeField] GameObject[] ballMapArray;

    int ballMapCount = 0;

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Map").Length < 3)
        {
            if (ballMapCount != 4)
            {
                Instantiate(mapArray[Random.Range(0, 1)]);
                ballMapCount++;
            }
            else
            {
                Instantiate(ballMapArray[Random.Range(0, 1)]);
                ballMapCount = 0;
            }
        }
    }
}
