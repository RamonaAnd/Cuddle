using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseAnswer : MonoBehaviour
{
    public GameObject mainCharacter;
    [SerializeField] private GameObject difficultyCanvas;
    [SerializeField] private GameObject answerCanvas;
    [SerializeField] private SaveLoad saveLoad ;
    public void chooseAnswer(int answer)
    {
        if (Singleton.Instance.quizToVerify.getCorrectAnswer() != answer)
        {
            Singleton.Instance.lives--;
            difficultyCanvas.SetActive(true);
            answerCanvas.SetActive(false);
        }
        else
        {
            int damage=0;
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
            
            if(Singleton.Instance.enemyToFight.GetComponent<EnemyStats>().currentHp <= damage)
            {
                mainCharacter.GetComponent<EnemyFights>().endFight();
                Singleton.Instance.coins += Singleton.Instance.enemyToFight.GetComponent<EnemyStats>().coins;
                Destroy(Singleton.Instance.enemyToFight);
                difficultyCanvas.SetActive(false);
                answerCanvas.SetActive(false);
             
                if (Singleton.Instance.enemyToFight.tag.Equals("Boss"))
                {
                    PlayerPrefs.SetInt("won", 1);
                    saveLoad.SaveFile();
                    SceneManager.LoadScene("EndScene");
                }

            }
            else
            {
                Singleton.Instance.enemyToFight.GetComponent<EnemyStats>().currentHp -= damage;
                difficultyCanvas.SetActive(true);
                answerCanvas.SetActive(false);
            }
            
        }
    }
}
