using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneTrigger : MonoBehaviour
{
    private bool isCollected = false;
    //public string scene;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true; 
            RuneManager.instance.AddRune();
            string nextScene = RuneManager.instance.GetNextScene();
            RuneManager.instance.LoadScene(nextScene);
        }
    }
}
