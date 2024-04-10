using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField] private List<Sprite> skins;
    [SerializeField] GameObject mainCharacter;

    private void Start()
    {
        Debug.Log(skins[PlayerPrefs.GetInt("skinNr", 0)]);
        mainCharacter.GetComponent<SpriteRenderer>().sprite = skins[PlayerPrefs.GetInt("skinNr", 0)];

    }
}
