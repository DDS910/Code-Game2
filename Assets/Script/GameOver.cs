using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public CharacterMovement[] controls;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    public void Lose()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        foreach (CharacterMovement control in controls)
        {
            control.enabled = false;
        }
    }

    public void MainMenu(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }

    public void PlayAgain(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Lose();
        }
    }
}
