using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class FinishLevel : MonoBehaviour
{
    public GameObject canvas_Score;
    public string Scene;
    public CharacterMovement[] controllers;
    public Collectible bone;
    //public GameObject trigger;
    public GameObject Wall;
    //private TilemapCollider2D triggerCollider;


    private void Start()
    {
        canvas_Score.SetActive(true);
        foreach (CharacterMovement c in controllers)
        {
            c.gameObject.SetActive(true);
        }
        Wall.SetActive(true);
        //triggerCollider = trigger.GetComponent<TilemapCollider2D>();
    }

    private void Update()
    {
        if (bone.collectibleCount < bone.totalBone)
        {
            Wall.SetActive(true);
        }
        else if (bone.collectibleCount >= bone.totalBone)
        {
            Wall.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (bone.collectibleCount >= bone.totalBone)
            {
                canvas_Score.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                foreach (CharacterMovement c in controllers)
                {
                    c.gameObject.SetActive(false);
                }
                Time.timeScale = 0f;
            }
        }
    }
}
