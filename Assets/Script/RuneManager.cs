using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuneManager : MonoBehaviour
{
    public static RuneManager instance;
    public int runeCount = 0;
    // TextMeshProUGUI runeText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //runeText = GameObject.Find("Rune").GetComponent<TextMeshProUGUI>();
        //UpdateRuneUI();
    }
    public void AddRune()
    {
        runeCount++;
        UpdateRuneUI();
    }

    public void UpdateRuneUIText()
    {
        var runeUI = GameObject.Find("Rune");
        if (runeUI != null)
        {
            //runeText = runeUI.GetComponent<TextMeshProUGUI>();
            UpdateRuneUI();
        }
    }

    public void UpdateRuneUI()
    {
        //runeText.text = "Rune count: " + runeCount;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        SceneManager.sceneLoaded += OnSceneLoaded; // Register callback for scene load
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reassign runeText after a scene is loaded
        UpdateRuneUI();
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unregister callback
    }

    public string GetNextScene()
    {
        if (runeCount >= 2)
        {
            return "FinishGame"; // Name of the final scene
        }
        return "Map_Selection"; // Default to returning to Scene 1
    }
}
