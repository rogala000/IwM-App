using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour {

    [SerializeField] TextMeshProUGUI counter;
    [SerializeField] TextMeshProUGUI question;

    [SerializeField] TextMeshProUGUI answer1;
    [SerializeField] TextMeshProUGUI answer2;
    [SerializeField] TextMeshProUGUI answer3;
    [SerializeField] TextMeshProUGUI answer4;

    [SerializeField] List<Image> buttonSprites;
    [SerializeField] Sprite correctSprite;
    [SerializeField] Sprite wrongSprite;
    [SerializeField] Sprite defaultSprite;

    [SerializeField] GameObject gameFinish;

    private int questionNumber = 0;
    private int correctAnswer;
    private bool waitingForAnswer = true;

    public int QuestionNumber
    {
        get
        {
            return questionNumber;
        }

        set
        {
            questionNumber = value;
            ShowQuestion(value);
            counter.text = "Pytanie " + (value + 1) + "/" + GameManager.instance.Questions.Count; 
        }
    }
    


    // Use this for initialization
    void Start () {
        QuestionNumber = 0;
        RestoreButtons();
        GameManager.instance.Score = 0;
	}
	

    public void AnswerChosen(int i)
    {

        if (waitingForAnswer)
        {
            waitingForAnswer = false;
            if (i == correctAnswer)
            {
                AudioManager.instance.AudioSource.PlayOneShot(AudioManager.instance.CorrectAnswer);
                GameManager.instance.Score += 1;
                StartCoroutine(CorrectAnswer());
            }
            else
            {
                AudioManager.instance.AudioSource.PlayOneShot(AudioManager.instance.WrongAnswer);
                StartCoroutine(WrongAnswer(i));
            }
        }
    }


    IEnumerator WrongAnswer(int i)
    {
        buttonSprites[i].sprite = wrongSprite;
        yield return new WaitForSeconds(1);
        buttonSprites[correctAnswer].sprite = correctSprite;
        StartCoroutine(StartNextQuestion());
    }

    IEnumerator CorrectAnswer()
    {
        buttonSprites[correctAnswer].sprite = correctSprite;
        yield return new WaitForSeconds(1);
        StartCoroutine(StartNextQuestion());
    }


    IEnumerator StartNextQuestion()
    {
        yield return new WaitForSeconds(2);
        if (QuestionNumber < GameManager.instance.Questions.Count - 1)
        {
            QuestionNumber +=1;
        }
        else
        {
            Destroy(gameObject);
            Instantiate(gameFinish);
        }

        RestoreButtons();
    }


    void RestoreButtons()
    {

        for (int i = 0; i < buttonSprites.Count; i++)
        {
            buttonSprites[i].sprite = defaultSprite;
        }

    }

    void ShowQuestion(int questionNumber)
    {
        Question currentQuestion = GameManager.instance.Questions[questionNumber];
        waitingForAnswer = true;

        question.text = currentQuestion._question;
        answer1.text = currentQuestion._answer1;
        answer2.text = currentQuestion._answer2;
        answer3.text = currentQuestion._answer3;
        answer4.text = currentQuestion._answer4;
        correctAnswer = currentQuestion._correctAnswer;
    }




}
