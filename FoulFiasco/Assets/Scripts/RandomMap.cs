using UnityEngine;

public class RandomMap : MonoBehaviour
{
    // Draggable variable array
    [SerializeField] GameObject[] mapArray;
    [SerializeField] GameObject[] ballMapArray;

    int ballMapCount = 0;

    // Runs every frame
    private void Update()
    {
        //if the gameobject with the tag "map" length is lower than 3
        if (GameObject.FindGameObjectsWithTag("Map").Length < 3)
        {
            //if ballmapcount is not 4
            if (ballMapCount != 4)
            {
                //instantiates ballmaparray with a random range between maparray length
                Instantiate(mapArray[Random.Range(0, mapArray.Length)]);
                ballMapCount++;
            }
            
            else
            {
                //instantiates ballmaparray with a random range between 0 and ballmaparray length
                Instantiate(ballMapArray[Random.Range(0, ballMapArray.Length)]);
                //ballmapcount gets reset to 0
                ballMapCount = 0;
            }
        }
    }
}
