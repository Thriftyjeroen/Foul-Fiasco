using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class RandomMap : MonoBehaviour
{
    [SerializeField] GameObject mapFolder;
    [SerializeField] GameObject map1, map2;
    Transform[] childeren;

    private void Start()
    {
        childeren = mapFolder.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if (childeren.Length == 3)
        {
            Destroy(mapFolder.transform.GetChild(0));
        }
        else
        {
            GameObject map = Instantiate(map1);
            map.AddComponent<MapMovement>();
            map.transform.position = new Vector3(72.5f, -13.8f, 0);
        }
    }
}
