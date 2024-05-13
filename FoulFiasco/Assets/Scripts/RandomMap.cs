using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class RandomMap : MonoBehaviour
{
    [SerializeField] GameObject[] mapArray;

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Map").Length < 3)
        {
            Instantiate(mapArray[Random.Range(0, 2)]);
        }
    }
}
