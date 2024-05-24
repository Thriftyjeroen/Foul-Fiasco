using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] TMP_Text coins;
    void Start()
    {
        coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
