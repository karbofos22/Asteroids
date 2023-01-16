using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GameStateManager;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroids;
    [SerializeField] private GameObject[] alienShips;

    private bool isCanSpawn;
    private float spawnDistance = 11;

    private void Start()
    {
        EventManager.OnGameStateChanged.AddListener(OnGameStateChanged);

        InvokeRepeating(nameof(SpawnAsteroids), 2, 5);
        InvokeRepeating(nameof(SpawnAlienShips), 3, 4);
    }
    private void SpawnAsteroids()
    {
        if (isCanSpawn)
        {
            Instantiate(asteroids[Random.Range(0, asteroids.Length)], RandomSpawnPos(), Quaternion.identity);
        }

    }
    private void SpawnAlienShips()
    {
        if (isCanSpawn)
        {
            Instantiate(alienShips[Random.Range(0, asteroids.Length)], RandomSpawnPos(), Quaternion.identity);
        }
    }
    private Vector2 RandomSpawnPos()
    {
        Vector2 spawnDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPoint = spawnDirection * spawnDistance;
        return spawnPoint;
    }
    private void OnGameStateChanged(GameState state)
    {
        isCanSpawn = (state == GameState.GameActive);
    }
}
