using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Show_objective : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI startText;
    private void Start()
    {
        text.enabled = false;
        StartCoroutine(durationText());
    }
    private IEnumerator durationText()
    {
        startText.enabled = true;
        yield return new WaitForSecondsRealtime(2.5f);
        startText.enabled = false;
        text.enabled = true;
        yield return new WaitForSecondsRealtime(2.5f);
        text.enabled = false;
    }
}
