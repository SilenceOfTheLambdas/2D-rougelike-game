using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [FormerlySerializedAs("_scoreMultiplier")]
    [Header("Game Options")] [Space]
    [SerializeField]private float scoreMultiplier = 2f;

    [SerializeField] private int idleScoreTime = 10; // Sets how long to wait for an idle score to be added
    private float _score; // The player's score; this is a combination of the enemies killed - Time.deltaTime * multiplier
    public enum EnemyTypes:int
    {
        Tier1 = 50,
        Tier2 = 80,
        Tier3 = 100,
        Miniboss = 150,
        Boss = 200
    }
    
    [FormerlySerializedAs("playerHP")] [Header("Player options")] [Space] [SerializeField]
    public float playerHp;
    public float overHeal; // The player's over-heal score

    [FormerlySerializedAs("ui_object")] [Header("User Interface")] 
    public TextMeshProUGUI uiObject;

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
        SetPlayerUi();
        StartCoroutine(IdlePlayerScore());
    }

    public void SetPlayerUi()
    {
        healthSlider.value = playerHp;
        overHealSlider.value = overHeal;
    }

    // Score UI manager
    void UpdateScoreUi()
    {
        uiObject.text = "Score: \n" + _score;
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("DeathScreen");
    }

    private IEnumerator IdlePlayerScore()
    {
        yield return new WaitForSeconds(idleScoreTime);
        _score += scoreMultiplier;
        UpdateScoreUi();
        StartCoroutine(IdlePlayerScore());
    }

    public void OnKill(EnemyTypes enemyTypes)
    {
        switch (enemyTypes)
        {
            case EnemyTypes.Tier1:
                _score += (int) EnemyTypes.Tier1;
                UpdateScoreUi();
                break;
            case EnemyTypes.Tier2:
                _score += (int) EnemyTypes.Tier2;
                UpdateScoreUi();
                break;
            case EnemyTypes.Tier3:
                _score += (int) EnemyTypes.Tier3;
                UpdateScoreUi();
                break;
            case EnemyTypes.Miniboss:
                _score += (int) EnemyTypes.Miniboss;
                UpdateScoreUi();
                break;
            case EnemyTypes.Boss:
                _score += (int) EnemyTypes.Boss;
                UpdateScoreUi();
                break;
            default:
                _score += (int) EnemyTypes.Tier1;
                UpdateScoreUi();
                break;
        }
    }
}
