using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerInfo;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("PlayerInfo") ==  null)
        {
            Instantiate(playerInfo);
        }
    }
}
