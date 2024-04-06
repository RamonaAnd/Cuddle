using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Die Geschwindigkeit, mit der die Kamera dem Charakter folgt.
    public float followSpeed = 2f;
    
    // Der Transform des Charakters, dem die Kamera folgen soll.
    public Transform mainCharacter;
    
    // Update wird einmal pro Frame aufgerufen
    void Update()
    {
        // Erstelle eine neue Position für die Kamera, die sich auf der x- und y-Position des Hauptcharakters befindet,
        // aber leicht erhöht (um 2 Einheiten in der y-Achse) und hinter dem Charakter (um 10 Einheiten in der z-Achse).
        Vector3 newPos = new Vector3(mainCharacter.position.x, mainCharacter.position.y + 2, -10f);
        
        // Aktualisiere die Position der Kamera, um sich der neuen Position anzunähern.
        // Vector3.Slerp interpoliert spherisch zwischen zwei Vektoren. Das bedeutet, dass die Bewegung weicher ist und 
        // sich natürlicher anfühlt, als wenn man Linear Interpolation (Lerp) verwenden würde.
        // 'transform.position' ist die aktuelle Position der Kamera.
        // 'newPos' ist die Zielposition.
        // 'followSpeed' beeinflusst, wie schnell die Kamera dem Ziel folgt. Je höher der Wert, desto schneller die Bewegung.
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
