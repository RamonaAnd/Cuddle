using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDifficulty : MonoBehaviour
{
    [SerializeField] private GameObject difficultyCanvas;
    [SerializeField] private GameObject answerCanvas;

    public void selectDifficulty(int difficulty)
    {
        difficultyCanvas.SetActive(false);
        answerCanvas.SetActive(true);
        Singleton.Instance.difficulty = difficulty;
        Singleton.Instance.changeQuestionC.changeQuestion();
    }
}