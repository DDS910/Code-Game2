using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseUI;
    public CharacterMovement[] controls;

    private void Start()
    {
        PauseUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0f;
            foreach (CharacterMovement control in controls)
            {
                control.enabled = false;
            }
        }
    }

    public void Continue()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        foreach (CharacterMovement control in controls)
        {
            control.enabled = true;
        }
        
    }

    public void Restart(string scene)
    {
        PauseUI.SetActive(false);
        SceneManager.LoadScene(scene);
        foreach (CharacterMovement control in controls)
        {
            control.enabled = true;
        }
        Time.timeScale = 1f;
    }

    public void Mainmenu(string scene)
    {
        PauseUI.SetActive(false);
        SceneManager.LoadScene(scene);
        foreach (CharacterMovement control in controls)
        {
            control.enabled = true;
        }
        Time.timeScale = 1.0f;
    }


}
