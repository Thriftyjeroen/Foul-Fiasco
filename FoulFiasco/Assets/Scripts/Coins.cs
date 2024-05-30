using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    // Dragable variable
    [SerializeField] TMP_Text coins;
    void Start()
    {
        // Sets the coin meter to whatever is in the playerpref for it
        coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
