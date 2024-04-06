using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SaveLoad saveLoad;
    public void startGame()
    {
        PlayerPrefs.SetInt("coins", saveLoad.coins);
        SceneManager.LoadScene("MainScene");
    }
 
}
