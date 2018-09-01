﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject winPanel;

    public GameObject instructionPanel;

    public bool gameStarted = false;
    
    private bool waitingOnNewGame = false;
    
	// Use this for initialization
	void Start ()
    {
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    private void Update()
    {
        if (waitingOnNewGame)
        {
            if (CrossPlatformInputManager.GetButtonDown("Player1_Grab"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (CrossPlatformInputManager.GetButtonDown("Cancel"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }

    public void Win(GameObject winner)
    {
        winPanel.SetActive(true);
        waitingOnNewGame = true;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        waitingOnNewGame = true;
    }

    public void HideInstructionPanel()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            Animator fadePanel = instructionPanel.GetComponent<Animator>();
            fadePanel.SetTrigger("FadeOut");
        }
    }
}
