using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Show_text : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI startText;
    private void Start()
    {
        text.enabled = false;
        StartCoroutine(durationText());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.enabled = false;
        }
    }

    private IEnumerator durationText()
    {
        startText.enabled = true;
        yield return new WaitForSecondsRealtime(2.5f);
        startText.enabled = false;
    }
}
