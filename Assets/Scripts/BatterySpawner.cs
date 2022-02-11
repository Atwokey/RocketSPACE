using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySpawner : MonoBehaviour
{
    [SerializeField] private Battery _batteryPrefab;
    [SerializeField] private List<Point> _spawnPoints;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            Instantiate(_batteryPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
