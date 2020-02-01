using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    
    [Header("Player options")] [Space] [SerializeField]
    private float playerHP;

    private bool playerDead;

    private void Awake()
    {
        // If an instance already exists, destroy it and create a new one
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void GameOver()
    {
        if (playerDead)
            SceneManager.LoadScene("DeathScreen");
    }
}
