using System;
using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;
    [FormerlySerializedAs("_scoreMultiplier")] 
    [SerializeField]
    private float scoreMultiplier = 2f;
    private float _score; // The player's score; this is a combination of the enemies killed - Time.deltaTime * multiplier
    
    [FormerlySerializedAs("playerHP")] [Header("Player options")] [Space] [SerializeField]
    public float playerHp;
    public float overHeal; // The player's over-heal score

    [Header("User Interface")] 
    public TextMeshProUGUI ui_object;

    public Slider healthSlider; // The slider UI object used for the player's HP
    public Slider overHealSlider; // The slider UI object used for the player's over-heal

    private void Awake()
    {
        // If an instance already exists, destroy it and create a new one
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        UpdateScoreUi();
        setPlayerUI();
        StartCoroutine(updatePlayerScore());
    }

    public void setPlayerUI()
    {
        healthSlider.value = playerHp;
        overHealSlider.value = overHeal;
    }

    // Score UI manager
    void UpdateScoreUi()
    {
        ui_object.text = "Score: " + _score.ToString();
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("DeathScreen");
    }

    IEnumerator updatePlayerScore()
    {
        yield return new WaitForSeconds(10);
        _score += scoreMultiplier;
        UpdateScoreUi();
        StartCoroutine(updatePlayerScore());
    }
}
