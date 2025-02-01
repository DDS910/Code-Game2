using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public GameObject QuizUI;
    public CharacterMovement[] players;
    public GameObject trigger;
    public TextMeshProUGUI timerText;
    public float timeLimit;
    private float currentTime;
    public GameOver gameOver;

    //public GameObject finishRoad;
    //public TextMeshProUGUI counter;
    //public int totalQuiz;
    //private int completedQuiz = 0;

    private QuizManager quizManager;

    private void Start()
    {
        QuizUI.SetActive(false);
        currentTime = timeLimit;
        //finishRoad.SetActive(false);
        //UpdateQuizCounter();

        quizManager = FindObjectOfType<QuizManager>();
    }

    private void Update()
    {
        if (QuizUI.activeSelf)
        {
            currentTime -= Time.unscaledDeltaTime;
            timerText.text = "Time : " + Mathf.Ceil(currentTime).ToString();
        }
       
        if (currentTime <= 0)
        {
            currentTime = 0;
            gameOver.Lose();
            QuizUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            QuizUI.SetActive(true);
            foreach (CharacterMovement controll in players) 
            {
                controll.enabled = false;
            }
            Time.timeScale = 0f;
            currentTime = timeLimit;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!QuizUI.activeSelf)
            {
                trigger.SetActive(false);
            }
        }
    }

    public void CorrectButton()
    {
        QuizUI.SetActive(false);
        //completedQuiz++;
        quizManager.CompletedQuiz();
        foreach (CharacterMovement controll in players)
        {
            controll.enabled = true;
        }

        /*if (completedQuiz >= totalQuiz)
        {
            finishRoad.SetActive(false);
        }*/

        Time.timeScale = 1f;
    }

    public void FalseButton()
    {
        QuizUI.SetActive(false);
        Time.timeScale = 1f;
        gameOver.Lose();
    }

}
