using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stellt sicher, dass das GameObject, an das dieses Skript angehängt ist, sowohl eine Rigidbody2D-
// als auch eine BoxCollider2D-Komponente hat. Wenn nicht, werden diese automatisch hinzugefügt.
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody; // Referenz auf die Rigidbody2D-Komponente des Spielers 
    [SerializeField] private FixedJoystick joystick; // Referenz auf den Joystick, der für die Bewegungseingabe verwendet wird.
    [SerializeField] private Animator animator; // Referenz auf den Animator, der für die Steuerung der Charakteranimationen verwendet wird.

    [SerializeField] private float moveSpeed; // Die Geschwindigkeit, mit der sich der Spieler bewegt.

    // FixedUpdate wird in regelmäßigen Zeitabständen aufgerufen und eignet sich daher besser für die Physikberechnung.
    private void FixedUpdate()
    {
        // Setzt die Geschwindigkeit des Rigidbodys basierend auf der Joystick-Eingabe und der Bewegungsgeschwindigkeit.
        // Die y-Geschwindigkeit bleibt unverändert, um die Schwerkraftwirkung nicht zu beeinflussen.
       rigidBody.velocity = new Vector3(joystick.Horizontal * moveSpeed, joystick.Vertical * moveSpeed, 0);
    }
}
