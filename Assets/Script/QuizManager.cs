using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI counter;
    public GameObject finishRoad;
    public GameObject invisibleWall;
    public int totalQuiz;
    private int completedQuiz = 0;

    private void Start()
    {
        UpdateQuizCounter();
        finishRoad.SetActive(false);
        invisibleWall.SetActive(true);
    }

    public void CompletedQuiz()
    {
        completedQuiz++;
        UpdateQuizCounter();

        if (completedQuiz >= totalQuiz)
        {
            finishRoad?.SetActive(true);
            invisibleWall.SetActive(false);
        }
    }

    private void UpdateQuizCounter()
    {
        counter.text = "Total Quiz: " + completedQuiz + "/" + totalQuiz; // Update counter text
    }
}
