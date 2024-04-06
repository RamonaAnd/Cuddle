using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeTitle : MonoBehaviour
{
    private void Start()
    {
        int won = PlayerPrefs.GetInt("won", 0);
        if (won == 0)
            GetComponent<TextMeshProUGUI>().text = "You will win next time!";
    }
}