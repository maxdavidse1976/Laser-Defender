using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    ScoreKeeper _scoreKeeper;
    Player _player;
    float _fullHealth;

    VisualElement _currentHealth;
    Label _currentScore;
    Label _currentLevel;
    VisualElement _bossLife;

    public static UIController Instance { get; private set; }


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _player = FindObjectOfType<Player>();
        var root = GetComponent<UIDocument>().rootVisualElement;
        _currentHealth = root.Q<VisualElement>("CurrentHealth");
        _currentScore = root.Q<Label>("CurrentScore");
        _currentLevel = root.Q<Label>("CurrentLevel");
        _bossLife = root.Q<VisualElement>("BossLife");
    }
    
    void Start()
    {
        // Set initial values
        _currentScore.text = _scoreKeeper.GetCurrentScore().ToString();
        // Make sure we hide the boss' healthbar in the beginning.
        _bossLife.style.display = DisplayStyle.None;
        // Set the initial Health bar of the player to 100 percent.
        _currentHealth.style.width = Length.Percent(100);
        _currentHealth.style.width = Length.Percent(80);
        _fullHealth = _player.GetComponent<Health>().GetHealth();

        //_bossLife.style.width = Length.Percent(80);
    }

    public void UpdateCurrentHealth(int currentHealth)
    {
        Debug.Log($"Percentage is now: {Length.Percent(currentHealth / _fullHealth * 100)}");
        _currentHealth.style.width = Length.Percent(currentHealth / _fullHealth * 100);
    }

    public void UpdateCurrentScore(int currentScore) => _currentScore.text = currentScore.ToString();
}
