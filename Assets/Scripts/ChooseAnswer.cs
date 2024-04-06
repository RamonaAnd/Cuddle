using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Wird benötigt für Szenenwechsel

public class ChooseAnswer : MonoBehaviour
{
    public GameObject mainCharacter; // Referenz zum Hauptcharakter
    [SerializeField] private GameObject difficultyCanvas; // UI-Element, das die Schwierigkeitsauswahl anzeigt
    [SerializeField] private GameObject answerCanvas; // UI-Element, das die Antworten anzeigt
    [SerializeField] private SaveLoad saveLoad; // Komponente für das Speichern/Laden des Spielfortschritts

    // Wird aufgerufen, wenn der Spieler eine Antwort wählt
    public void chooseAnswer(int answer)
    {
        // Überprüft, ob die gewählte Antwort falsch ist
        if (Singleton.Instance.quizToVerify.getCorrectAnswer() != answer)
        {
            Singleton.Instance.lives--; // Reduziert die Leben des Spielers
            difficultyCanvas.SetActive(true); // Zeigt das Schwierigkeitsauswahl-UI an
            answerCanvas.SetActive(false); // Verbirgt das Antwort-UI
        }
        else
        {
            int damage = 0; // Initialisiert den Schadenswert
            // Legt den Schadenswert basierend auf der Schwierigkeitsstufe fest
            switch (Singleton.Instance.difficulty)
            {
                case 1:
                    damage = 10;
                    break;
                case 2:
                    damage = 15;
                    break;
                case 3:
                    damage = 20;
                    break;
            }
            
            // Überprüft, ob der Gegner nach dem Schaden besiegt wird
            if (Singleton.Instance.enemyToFight.GetComponent<EnemyStats>().currentHp <= damage)
            {
                mainCharacter.GetComponent<EnemyFights>().endFight(); // Beendet den Kampf
                Singleton.Instance.coins += Singleton.Instance.enemyToFight.GetComponent<EnemyStats>().coins; // Fügt Münzen hinzu
                Destroy(Singleton.Instance.enemyToFight); // Zerstört den besiegten Gegner
                
                // Überprüft, ob der besiegte Gegner ein Boss war
                if (Singleton.Instance.enemyToFight.tag.Equals("Boss"))
                {
                    PlayerPrefs.SetInt("won", 1); // Setzt den Siegstatus
                    saveLoad.SaveFile(); // Speichert das Spiel
                    SceneManager.LoadScene("EndScene"); // Lädt die Endszene
                }
            }
            else
            {
                // Fügt dem Gegner Schaden zu, wenn er nicht besiegt wird
                Singleton.Instance.enemyToFight.GetComponent<EnemyStats>().currentHp -= damage;
                difficultyCanvas.SetActive(true); // Zeigt das Schwierigkeitsauswahl-UI an
                answerCanvas.SetActive(false); // Verbirgt das Antwort-UI
            }
        }
    }
}
