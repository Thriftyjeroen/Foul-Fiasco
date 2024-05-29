using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerInfo;

    void Start()
    {
        //when there is no gameobject with the tag "PlayerInfo"
        if (GameObject.FindGameObjectWithTag("PlayerInfo") ==  null)
        {
            //playerinfo gets instantiated
            Instantiate(playerInfo);
        }
    }
}
