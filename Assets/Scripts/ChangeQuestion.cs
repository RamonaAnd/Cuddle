using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeQuestion : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] Button answer1;
    [SerializeField] Button answer2;
    [SerializeField] Button answer3;

    public void changeQuestion()
    {
        List<Quiz> quizzes;
        switch (Singleton.Instance.difficulty)
        {
            case 1:
                quizzes = Singleton.Instance.quizzes1;
                break;
            case 2:
                quizzes = Singleton.Instance.quizzes2;
                break;
            case 3:
                quizzes = Singleton.Instance.quizzes3;
                break;
            default:
                quizzes = Singleton.Instance.quizzes1;
                break;
        }
        Singleton.Instance.randomNumber = Random.Range(0, quizzes.Count);
        int randomNr = Singleton.Instance.randomNumber;
        question.text = quizzes[randomNr].getQuestion(); //quizez[2].GetQuestion();
        answer1.GetComponentInChildren<TextMeshProUGUI>().text = quizzes[randomNr].getAnswer1();
        answer2.GetComponentInChildren<TextMeshProUGUI>().text = quizzes[randomNr].getAnswer2();
        answer3.GetComponentInChildren<TextMeshProUGUI>().text = quizzes[randomNr].getAnswer3();
        Singleton.Instance.quizToVerify = quizzes[randomNr];
    }
}
