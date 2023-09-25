using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> _waveConfigs;
    [SerializeField] float _timeBetweenWaves = 0f;

    WaveConfigSO _currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }
    
    public WaveConfigSO GetCurrentWave() => _currentWave;
    
    IEnumerator SpawnEnemyWaves()
    {
        foreach (WaveConfigSO wave in _waveConfigs)
        {
            _currentWave = wave;

            for (int i = 0; i < _currentWave.GetEnemyCount(); i++)
            {
                Instantiate(_currentWave.GetEnemyPrefab(i),
                    _currentWave.GetStartingWaypoint().position,
                    Quaternion.identity,
                    transform);
                yield return new WaitForSeconds(_currentWave.GetRandomSpawnTime());
            }

            yield return new WaitForSeconds(_timeBetweenWaves);
        }
    }
}
