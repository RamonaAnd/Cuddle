using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySkin : MonoBehaviour
{
    public void SetSkin(int skinNr)
    {
        PlayerPrefs.SetInt("skinNr", skinNr);
    }

}
