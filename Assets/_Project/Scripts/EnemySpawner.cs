using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO _currentWave;

    void Start()
    {
        SpawnEnemies();
    }
    
    public WaveConfigSO GetCurrentWave() => _currentWave;
    
    void SpawnEnemies()
    {
        for (int i = 0; i < _currentWave.GetEnemyCount(); i++)
        {
            Instantiate(_currentWave.GetEnemyPrefab(i), 
                _currentWave.GetStartingWaypoint().position, 
                Quaternion.identity, 
                transform);
        }
        
    }
}
