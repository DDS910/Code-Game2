using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPlay;
    public Transform spawnPoint;

    private void Start()
    {

        int isCharacterSelected = PlayerPrefs.GetInt("IsCharacterSelected", 0);
        if (isCharacterSelected == 0)
        {
            Debug.LogWarning("Character not selected yet. LoadCharacter will not run.");
            return;
        }

        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Debug.Log("Loading selected character: " + selectedCharacter);

        foreach (GameObject character in characterPlay)
        {
            character.SetActive(false);
        }

        GameObject selectedPrefab = characterPlay[selectedCharacter];
        selectedPrefab.SetActive(true);

        if (spawnPoint != null)
        {
            selectedPrefab.transform.position = spawnPoint.position;
            Debug.Log("Spawning at: " + spawnPoint.position);
        }

        CameraMovement cameraFollow = Camera.main.GetComponent<CameraMovement>();
        cameraFollow.SetTarget(selectedPrefab.transform);
    }
}
