using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;

    [SerializeField]
    private SpawnerMonedas coinSpawner;
    [SerializeField]
    private SpawnerEnemigo enemySpawner;

    [SerializeField]
    private List<Level> levels;
    Level currentLevel;

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void Start()
    {
        currentLevel = levels[0];
        StartLevel();
        soundManager.PlaySound("Game Play Mx");

    }

    private void StartLevel()
    {


        coinSpawner.SpawnCoins(currentLevel.coinsCount);
        enemySpawner.SpawnEnemies(currentLevel.enemiesCount, currentLevel.spawnOffset);

    }
}
