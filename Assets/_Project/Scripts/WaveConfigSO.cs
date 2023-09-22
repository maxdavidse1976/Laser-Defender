using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> _enemyPrefabs;
    [SerializeField] Transform _pathPrefab;
    [SerializeField] float _moveSpeed = 5;

    // Public Getters
    public Transform GetStartingWaypoint() => _pathPrefab.GetChild(0);
    public int GetEnemyCount() => _enemyPrefabs.Count;
    public GameObject GetEnemyPrefab(int index) => _enemyPrefabs[index];

    public List<Transform> GetWaypoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform child in _pathPrefab)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }
    public float GetMoveSpeed() => _moveSpeed;
}
