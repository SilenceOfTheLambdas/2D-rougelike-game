using System;
using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    [SerializeField] private float _scoreMultiplier = 2f;
    public float _score = 0f; // The player's score; this is a combination of the enemies killed - Time.deltaTime * multiplier
    
    [FormerlySerializedAs("playerHP")] [Header("Player options")] [Space] [SerializeField]
    public float playerHp;

    [Header("User Interface")] public TextMeshProUGUI ui_object;

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
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        UpdateScoreUi();
        StartCoroutine(updatePlayerScore());
    }

    // Score UI manager
    void UpdateScoreUi()
    {
        ui_object.text = _score.ToString();
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("DeathScreen");
    }

    IEnumerator updatePlayerScore()
    {
        yield return new WaitForSeconds(10);
        _score += _scoreMultiplier;
        UpdateScoreUi();
        StartCoroutine(updatePlayerScore());
    }
}
