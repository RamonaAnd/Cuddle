using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToShop : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject shopMenu;
    // Start is called before the first frame update
    
    public void showMenu()
    {
        mainMenu.SetActive(true);
        shopMenu.SetActive(false);
    }

    public void showShop()
    {
        mainMenu.SetActive(false);
        shopMenu.SetActive(true);
    }
}
