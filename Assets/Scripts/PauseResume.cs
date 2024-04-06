using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject resumeMenu;
    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        resumeMenu.SetActive(false);
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        resumeMenu.SetActive(true);
        Time.timeScale = 1;
    }
}
