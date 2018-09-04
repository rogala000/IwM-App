using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static GameManager instance = null;
    List<Question> questions = new List<Question>();

    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            score = 0;
        }

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this.gameObject);
    }


    public List<Question> Questions
    {
        get
        {
            return questions;
        }

        set
        {
            questions = value;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public void GetQuestions()
    {
        Questions.Clear();
        List<QuestionJSON> JSONquestions = GetURL.instance.questions;

        foreach (var question in JSONquestions)
        {
            string title = question.title;
            string answer1 = question.answer1;
            string answer2 = question.answer2;
            string answer3 = question.answer3;
            string answer4 = question.answer4;
            int correctAnswer = Int32.Parse(question.correct);
            Debug.Log("title: " + title + " answer 1: " + answer1 + " answer 2: " + answer2 + " answer 3: " + answer3 + " answer 4: " + answer4 + " correct answer: " + correctAnswer);


            Question newQuestion = new Question(title, answer1, answer2, answer3, answer4, correctAnswer);
            questions.Add(newQuestion);
        }

    }

}


public class Question
{
    public string _question;
    public string _answer1;
    public string _answer2;
    public string _answer3;
    public string _answer4;
    public int _correctAnswer;


    public Question(string question, string answer1, string answer2, string answer3, string answer4, int correctAnswer)
    {
        _question = question;
        _answer1 = answer1;
        _answer2 = answer2;
        _answer3 = answer3;
        _answer4 = answer4;
        _correctAnswer = correctAnswer;
    }
    
}
