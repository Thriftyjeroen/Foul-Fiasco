using UnityEngine;

public class RandomMap : MonoBehaviour
{
    [SerializeField] GameObject[] mapArray;
    [SerializeField] GameObject[] ballMapArray;

    int ballMapCount = 0;

    private void Update()
    {
        //if the gameobject with the tag "map" length is lower than 3
        if (GameObject.FindGameObjectsWithTag("Map").Length < 3)
        {
            //if ballmapcount is not 4
            if (ballMapCount != 4)
            {
                //instantiates ballmaparray with a random range between 0 and 1
                Instantiate(mapArray[Random.Range(0, 1)]);
                ballMapCount++;
            }
            
            else
            {
                //instantiates ballmaparray with a random range between 0 and 1
                Instantiate(ballMapArray[Random.Range(0, 1)]);
                //ballmapcount gets reset to 0
                ballMapCount = 0;
            }
        }
    }
}
