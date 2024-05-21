using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerInfo;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("PlayerInfo") ==  null) // als er geen object word gevonden met de tag playerinfo doe dan de code
        {
            Instantiate(playerInfo); // maakt een clone aan van playerinfo
        }
    }
}
