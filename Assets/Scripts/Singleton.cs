using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    public ChangeQuestion changeQuestionC;
    public static Singleton Instance { get; private set; }

    public int randomNumber;
    public int lives = 3;
    public int difficulty;
    public int coins = 0;

    public List<Quiz> quizzes1 = new List<Quiz>();
    public List<Quiz> quizzes2 = new List<Quiz>();
    public List<Quiz> quizzes3 = new List<Quiz>();
    public Quiz quizToVerify;

    public GameObject enemyToFight;

    [SerializeField] private TextMeshProUGUI coinsText;

    [SerializeField] private SaveLoad saveLoad;

    void addCategory1()
    {
        //int nr1 = Random.Range(0, 100);
        //int nr2 = Random.Range(0, 100);
        //int response = nr1 + nr2;
        quizzes1.Add(new Quiz("1+1=...", "2", "5", "1", 1, 1));
        quizzes1.Add(new Quiz("1+1=...", "2", "5", "1", 1, 1));
        quizzes1.Add(new Quiz("5+7=...", "5", "12", "6", 2, 1));
        quizzes1.Add(new Quiz("3+3=...", "6", "9", "10", 1, 1));
        quizzes1.Add(new Quiz("10+10=...", "15", "20", "17", 2, 1));
        quizzes1.Add(new Quiz("15-10=...", "5", "10", "1", 1, 1));
    }

    void addCategory2()
    {
        quizzes2.Add(new Quiz("5*5=...", "6", "15", "25", 3, 2)); //0
        quizzes2.Add(new Quiz("8*7=...", "50", "56", "87", 2, 2)); //1
        quizzes2.Add(new Quiz("10/10=...", "1", "10", "2", 1, 2)); //2
        quizzes2.Add(new Quiz("15*10=...", "150", "200", "75", 1, 2)); //3
        quizzes2.Add(new Quiz("17*3=...", "51", "60", "30", 1, 2)); //4
    }

    void addCategory3()
    {
        quizzes3.Add(new Quiz("5+5*3-3=...", "10", "17", "21", 2, 3));
        quizzes3.Add(new Quiz("10*10-15-25+15=...", "75", "100", "50", 1, 3));
        quizzes3.Add(new Quiz("15-5+25+30-5*5+7*7", "85", "90", "89", 3, 3));

    }

    private void Start()
    {
        coins = PlayerPrefs.GetInt("coins", -1);
        addCategory1();
        addCategory2();
        addCategory3();
        changeQuestionC.changeQuestion();
        enemyToFight = null;
        Time.timeScale = 1;
    }

    private void Update()
    {
        checkLives();
        coinsText.text = "Coins: " + coins;
    }


    [SerializeField] SpriteRenderer heart1;
    [SerializeField] SpriteRenderer heart2;
    [SerializeField] SpriteRenderer heart3;
    public void checkLives()
    {
        
        if (lives == 3)
        {
            
            heart1.color = new Color(1, 1, 1, 1);
            heart2.color = new Color(1, 1, 1, 1);
            heart3.color = new Color(1, 1, 1, 1);
        }
        else if (lives == 2)
        {
            heart1.color = new Color(1, 1, 1, 0.4f);
            heart2.color = new Color(1, 1, 1, 1);
            heart3.color = new Color(1, 1, 1, 1);
        }
        else if (lives == 1)
        {

            heart1.color = new Color(1, 1, 1, 0.4f);
            heart2.color = new Color(1, 1, 1, 0.4f);
            heart3.color = new Color(1, 1, 1, 1);
        }
        else
        {
            PlayerPrefs.SetInt("won", 0);
            saveLoad.SaveFile(5);
            SceneManager.LoadScene("EndScene");
        }
        
    }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
