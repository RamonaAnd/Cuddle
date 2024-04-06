using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Zugriff auf UI-Elemente, in diesem Fall den Slider für die HP-Anzeige

public class EnemyStats : MonoBehaviour
{
    // Referenz zum Slider-UI-Element, das als HP-Anzeige dient
    [SerializeField] private Slider hpSlider;
    // Die maximale HP (Health Points) des Gegners, im Editor einstellbar
    [SerializeField] private int hp;
    // Die Anzahl der Münzen, die der Spieler erhält, wenn er diesen Gegner besiegt
    public int coins;
    // Die aktuelle HP des Gegners; Ändert sich im Spielverlauf
    public int currentHp;

    // Wird aufgerufen, wenn das Skript aktiviert wird oder das Spiel beginnt
    private void Start()
    {
        currentHp = hp; // Setzt die aktuelle HP auf den maximalen Wert zu Beginn
    }

    // Update wird einmal pro Frame aufgerufen
    private void Update()
    {
        // Aktualisiert den Wert des HP-Sliders, um die aktuelle HP im Verhältnis zur maximalen HP darzustellen
        // Die Berechnung von (float) currentHp / hp konvertiert die aktuelle HP in einen Gleitkommawert
        // und berechnet das Verhältnis zur maximalen HP, da der Slider-Wert zwischen 0 und 1 liegen muss.
        hpSlider.value = (float) currentHp / hp;
    }
}
