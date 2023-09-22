using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform _pathPrefab;
    [SerializeField] float _moveSpeed = 5;

    public Transform GetStartingWaypoint() => _pathPrefab.GetChild(0);

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