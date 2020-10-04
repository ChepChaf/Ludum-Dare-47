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
    private GameObject playerPrefab;
    [SerializeField]
    private Orbita orbit;

    [SerializeField]
    private List<Level> levels;
    Level currentLevel;

    private SoundManager soundManager;

    private GameObject trajectory;

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
        trajectory = Instantiate(currentLevel.trajectory);
        orbit.DrawOrbit();

        SpawnPlayer();
        
        coinSpawner.SpawnCoins(currentLevel.coinsCount);
        enemySpawner.SpawnEnemies(currentLevel.enemiesCount, currentLevel.spawnOffset);
    }

    private void SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab);
    }
}
