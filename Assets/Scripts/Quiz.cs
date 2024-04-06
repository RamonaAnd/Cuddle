using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz
{
    string question;
    string answer1;
    string answer2;
    string answer3;
    int correctAnswer;
    int difficulty;

    public Quiz(string question, string answer1, string answer2, string answer3, int correctAnswer, int difficulty)
    {
        this.question = question;
        this.answer1 = answer1;
        this.answer2 = answer2;
        this.answer3 = answer3;
        this.correctAnswer = correctAnswer;
        this.difficulty = difficulty;
    }

    public string getQuestion() { return question; }
    public string getAnswer1() { return answer1; }
    public string getAnswer2() { return answer2; }
    public string getAnswer3() { return answer3; }
    public int getCorrectAnswer() { return correctAnswer; }
    public int getDifficulty() {  return difficulty; }
}
