using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Type : MonoBehaviour
{
    public TextMeshProUGUI[] dialogueTexts;
    public float typingspeed;

    private int currentLine = 0;
    public Button finish;

    private void Start()
    {
        if (dialogueTexts.Length > 0)
        {
            dialogueTexts[0].gameObject.SetActive(true);
            StartCoroutine(TypeText(dialogueTexts[currentLine]));
        }
    }

    private IEnumerator TypeText(TextMeshProUGUI text)
    {
        string fullText = text.text;
        text.text = ""; // Clear text to start typing

        foreach (char letter in fullText)
        {
            text.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }

        yield return new WaitForSeconds(1.5f);
        newLine();
    }

    private void newLine()
    {
        if (currentLine < dialogueTexts.Length - 1)
        {
            dialogueTexts[currentLine].gameObject.SetActive(false);
            currentLine++;
            dialogueTexts[currentLine].gameObject.SetActive(true);
            StartCoroutine(TypeText(dialogueTexts[currentLine]));
        }
        else
        {
            finish.gameObject.SetActive(true);
        }
    }

    public void finishGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
