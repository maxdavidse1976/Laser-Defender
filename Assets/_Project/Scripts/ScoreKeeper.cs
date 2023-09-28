using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int _currentScore;

    public int GetCurrentScore() => _currentScore;

    public void AddScore(int score)
    {
        _currentScore += score;
        Mathf.Clamp(_currentScore, 0, int.MaxValue);
    }

    public void ResetScore() => _currentScore = 0;
}
