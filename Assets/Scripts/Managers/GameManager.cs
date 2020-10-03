using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SpawnerMonedas coinSpawner;
    [SerializeField]
    private SpawnerEnemigo enemySpawner;

    [SerializeField]
    private List<Level> levels;
    Level currentLevel;

    private void Start()
    {
        currentLevel = levels[0];
        StartLevel();
    }

    private void StartLevel()
    {
        coinSpawner.SpawnCoins(currentLevel.coinsCount);
        enemySpawner.SpawnEnemies(currentLevel.enemiesCount, currentLevel.spawnOffset);
    }
}
