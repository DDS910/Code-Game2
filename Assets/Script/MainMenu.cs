using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string SceneName;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void mainStart()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void mainExit()
    {
        Application.Quit();
    }
}
