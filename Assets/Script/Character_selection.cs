using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character_selection : MonoBehaviour
{
    public GameObject player; 
    public GameObject[] characters;
    public GameObject[] characterPlay;
    public int selectedCharacter = 0;
    public GameObject characterUI;
    public LoadCharacter load;
    public TutorialText tutor;
   
    private void Start()
    {

        foreach (GameObject sprite in characters)
        {
            sprite.SetActive(false);
        }

        foreach (GameObject character in characterPlay)
        {
            character.SetActive(false);
        }

        if (characters.Length > 0)
        {
            characters[0].SetActive(true);
        }
        load.enabled = false;
        //tutor.enabled = false;
    }

    public void nextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void previousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void startGame()
    {
        Debug.Log("Selected character: " + selectedCharacter);
        player.SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        PlayerPrefs.SetInt("IsCharacterSelected", 1); // Indicate selection is complete
        PlayerPrefs.Save();


        characterUI.SetActive(false);

        foreach (GameObject sprite in characters)
        {
            sprite.SetActive(false);
        }

        for (int i = 0; i < characterPlay.Length; i++)
        {
            characterPlay[i].SetActive(i == selectedCharacter); // Activate only the selected character
        }
        load.enabled = true;

        Debug.Log("Activating character: " + characterPlay[selectedCharacter].name);

        //CameraMovement cameraFollow = Camera.main.GetComponent<CameraMovement>();
        //cameraFollow.SetTarget(characterPlay[selectedCharacter].transform);

        //tutor.enabled = true;
        //TutorialText tutorialScript = FindObjectOfType<TutorialText>();
        //tutorialScript.StartTutorial();

        tutor.startTutorial();
    }
}
