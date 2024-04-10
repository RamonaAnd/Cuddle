using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject infoMenu;

    public void showMainMenu()
    {
        mainMenu.SetActive(true);
        infoMenu.SetActive(false);
    }

    public void showInfoMenu()
    {
        infoMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
}
