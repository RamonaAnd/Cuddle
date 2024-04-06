using System.Collections;
using System.Collections.Generic;
using TMPro; // Namespace für TextMeshPro, um fortgeschrittene Textfeatures zu nutzen
using UnityEngine;
using UnityEngine.UI; // Namespace für UI-Komponenten wie Buttons

public class ChangeQuestion : MonoBehaviour
{
    // Referenzen zu UI-Elementen, die im Inspector gesetzt werden. Diese zeigen die aktuelle Frage und die Antwortmöglichkeiten.
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] Button answer1;
    [SerializeField] Button answer2;
    [SerializeField] Button answer3;

    // Diese Methode aktualisiert die Frage und die Antworten im Quiz, basierend auf der ausgewählten Schwierigkeitsstufe.
    public void changeQuestion()
    {
        List<Quiz> quizzes; // Temporäre Liste, die basierend auf der Schwierigkeitsstufe die Fragen hält.

        // Entscheidet, welche Fragenliste basierend auf der gewählten Schwierigkeitsstufe verwendet wird.
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
                quizzes = Singleton.Instance.quizzes1; // Standardmäßig werden die Fragen der ersten Stufe geladen.
                break;
        }

        // Wählt eine zufällige Frage aus der Liste aus.
        Singleton.Instance.randomNumber = Random.Range(0, quizzes.Count);
        int randomNr = Singleton.Instance.randomNumber;

        // Setzt den Text der Frage und der Antwortmöglichkeiten basierend auf der ausgewählten Frage.
        question.text = quizzes[randomNr].getQuestion();
        answer1.GetComponentInChildren<TextMeshProUGUI>().text = quizzes[randomNr].getAnswer1();
        answer2.GetComponentInChildren<TextMeshProUGUI>().text = quizzes[randomNr].getAnswer2();
        answer3.GetComponentInChildren<TextMeshProUGUI>().text = quizzes[randomNr].getAnswer3();

        // Speichert die aktuelle Frage im Singleton, um sie später zu verifizieren.
        Singleton.Instance.quizToVerify = quizzes[randomNr];
    }
}
