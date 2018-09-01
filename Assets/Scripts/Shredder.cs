﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private GameManager gameManager;
    
	void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
	}
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            gameManager.GameOver();
        }

        Destroy(collision.gameObject);
    }
}