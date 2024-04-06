using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Zum Zugriff auf UI-Komponenten wie Image

public class EnemyFights : MonoBehaviour
{
    // Referenzen zu den Joystick-UI-Elementen, die während des Kampfes deaktiviert werden
    [SerializeField] private GameObject playerJoystick;
    [SerializeField] private GameObject playerMiddleJoystick;
    [SerializeField] private GameObject difficultyPanel; // Das Panel, das die Schwierigkeitsauswahl im Kampf anzeigt
    [SerializeField] private Transform spawnMain; // Der Spawn-Punkt des Spielers für den Kampf
    [SerializeField] private Transform spawnEnemy; // Der Spawn-Punkt des Gegners für den Kampf
    public Transform originalPosition; // Die ursprüngliche Position des Spielers vor dem Kampf

    // Wird aufgerufen, wenn das Skript aktiviert wird und initialisiert die ursprüngliche Position des Spielers
    private void Start()
    {
        originalPosition.position = new Vector2(0, 0); // Setzt die Startposition
    }

    // Diese Methode wird aufgerufen, wenn der Spieler mit einem Gegner kollidiert
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Überprüft, ob das kollidierte Objekt ein Gegner ist
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            originalPosition.position = transform.position; // Speichert die aktuelle Position des Spielers
            Singleton.Instance.enemyToFight = collision.gameObject; // Speichert den Gegner für den Kampf
            transform.position = spawnMain.position; // Versetzt den Spieler in die Kampfposition
            collision.gameObject.transform.position = spawnEnemy.position; // Versetzt den Gegner in die Kampfposition
            difficultyPanel.SetActive(true); // Zeigt das Schwierigkeitsauswahl-Panel an
            // Deaktiviert die Joysticks, um die Bewegung während des Kampfes zu verhindern
            playerJoystick.GetComponent<Image>().enabled = false;
            playerMiddleJoystick.GetComponent<Image>().enabled = false;
        }
    }

    // Diese Methode wird aufgerufen, um den Kampf zu beenden und den Spieler in seine ursprüngliche Position zurückzusetzen
    public void endFight()
    {
        difficultyPanel.SetActive(false); // Verbirgt das Schwierigkeitsauswahl-Panel
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation; // Verhindert, dass der Spieler sich dreht
        transform.position = originalPosition.position; // Setzt den Spieler zurück in seine ursprüngliche Position
        // Aktiviert die Joysticks wieder, um die Bewegung nach dem Kampf zu ermöglichen
        playerJoystick.GetComponent<Image>().enabled = true;
        playerMiddleJoystick.GetComponent<Image>().enabled = true;
    }
}
