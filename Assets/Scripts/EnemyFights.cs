using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFights : MonoBehaviour
{
    [SerializeField] private GameObject playerJoystick;
    [SerializeField] private GameObject playerMiddleJoystick;
    [SerializeField] private GameObject difficultyPanel;
    [SerializeField] private Transform spawnMain;
    [SerializeField] private Transform spawnEnemy;
    public Transform originalPosition;
    private void Start()
    {
        originalPosition.position = new Vector2(0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Boss"))
        {
            originalPosition.position = transform.position;
            Singleton.Instance.enemyToFight = collision.gameObject;
            transform.position = spawnMain.position; // change the position of the player to the spawnMain position
            collision.gameObject.transform.position = spawnEnemy.position;
            difficultyPanel.SetActive(true);
            playerJoystick.GetComponent<Image>().enabled = false;
            playerMiddleJoystick.GetComponent<Image>().enabled = false;
        }
    }

    public void endFight()
    {
        difficultyPanel.SetActive(false);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.position = originalPosition.position;
        playerJoystick.GetComponent<Image>().enabled = true;
        playerMiddleJoystick.GetComponent<Image>().enabled = true;
    }
}
