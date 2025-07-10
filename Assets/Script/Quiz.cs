using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class Quiz : MonoBehaviour
{
    [Header("Quiz Components")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionOS> questions = new List<QuestionOS>();
     QuestionOS currentQuestion;

    [Header("Answer Buttons")]
    [SerializeField] GameObject[] answerButtons;
    bool hasAnsweredEarly =true;
    int correctAnswerIndex;
    [Header("Button Sprites")]
    [SerializeField] Sprite defaultButtonSprite;
    [SerializeField] Sprite correctButtonSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scorekeeper")]
    [SerializeField] TextMeshProUGUI scoreText;
    Scorekeeper scorekeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;

    public bool isCompleted;
    void Awake()
    {
        timer = FindAnyObjectByType<Timer>();
        scorekeeper = FindAnyObjectByType<Scorekeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }
    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
             if (progressBar.value == progressBar.maxValue)
            {
            isCompleted = true;
            
            return;
            }
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
    public void onClickButton(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.cancelTimer();
        scoreText.text = "Score:" + scorekeeper.CalculateScoure() + "%";
       
    }
    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctButtonSprite;
            scorekeeper.IncrementCorrectAnswers();
        }
        else
        {

            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = currentQuestion.GetAnswers(correctAnswerIndex);
            questionText.text = "Wrong! Correct answer is: " + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctButtonSprite;


        }
    }
    
    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            GetRandomQuestion();
            DisplayQuestion();
            SetDefaultButtonSprite();
            SetButtonState(true);
            progressBar.value++;
            scorekeeper.IncrementQuestionSeen();
        }
       
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion); 
        }
    }
    void SetDefaultButtonSprite()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultButtonSprite;
        }
    }
    public void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswers(i);
        }
    }
    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons [i].GetComponent<Button>();
            button.interactable = state;
        }
    }
}
