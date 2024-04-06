using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNavigator : MonoBehaviour
{
    [SerializeField] private GameObject shopCanvas;
    [SerializeField] private GameObject gameCanvas;
    
    public void goShop()
    {
        shopCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }

    public void goGame()
    {
        shopCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }
}
