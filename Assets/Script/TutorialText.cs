using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialText : MonoBehaviour
{
    public GameObject TutorialCanvas;
    public CharacterMovement[] controllers;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public string Scene;

    private void Start()
    {
        TutorialCanvas.SetActive(true);
        text1.enabled = false;
        text2.enabled = false;
        foreach (CharacterMovement controller in controllers)
        {
            controller.enabled = false;
        }
        //StartCoroutine(show());
    }

    public void startTutorial()
    {
        StartCoroutine(show());
    }

    private IEnumerator show()
    {
        yield return new WaitForSecondsRealtime(2f);
        text1.enabled = true;
        yield return new WaitForSecondsRealtime(2f);
        text1.enabled = false;
        text2.enabled = true;
        foreach (CharacterMovement controller in controllers)
        {
            controller.enabled = true;
        }
        yield return new WaitForSecondsRealtime(1.5f);
        TutorialCanvas.SetActive(false);
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(Scene);
    }
}
