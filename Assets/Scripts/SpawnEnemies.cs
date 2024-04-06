using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private List<Transform> enemyLocations;
    [SerializeField] private List<GameObject> enemies;
    private void Start()
    {
        for(int i=0; i<enemyLocations.Count; i++)
        {
           // Wählt zufällig einen Gegner aus der Liste der Gegner aus.
            int nr = Random.Range(0, enemies.Count);
            // Generiert eine Zufallszahl, um zu bestimmen, ob an dieser Position ein Gegner erscheinen soll.
            int spawnChance = Random.Range(0, 1000);
            // Wenn die Zufallszahl größer als 500 ist, wird an dieser Position ein Gegner gespawnt.
            if (spawnChance > 500)
            {
                // Überprüft, ob der ausgewählte Gegner nicht "WarriorEnemy" ist.
                if (!enemies[nr].name.Equals("WarriorEnemy"))
                    // Spawnt den ausgewählten Gegner an der aktuellen Position in der Liste.
                    Instantiate(enemies[nr], enemyLocations[i].transform.position, Quaternion.identity);
                else
                    // Wenn der Gegner "WarriorEnemy" ist, spawnt ihn mit einer Drehung von 180 Grad um die Y-Achse.
                    Instantiate(enemies[nr], enemyLocations[i].transform.position, Quaternion.EulerRotation(0, 180, 0));
            }
        }
    }
}
