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
            int nr = Random.Range(0, enemies.Count);
            int spawnChance = Random.Range(0, 1000);
            if (spawnChance > 500)
            {
                if (!enemies[nr].name.Equals("WarriorEnemy"))
                    Instantiate(enemies[nr], enemyLocations[i].transform.position, Quaternion.identity);
                else
                    Instantiate(enemies[nr], enemyLocations[i].transform.position, Quaternion.EulerRotation(0, 180, 0));
            }
        }
    }
}
