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
    FuncionDeTrayectoria fdet;
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
        fdet = trajectory.GetComponent<FuncionDeTrayectoria>();
        FuncionDeTrayectoria.maxIndex = fdet.points.Count-1;

        orbit.DrawOrbit();

        SpawnPlayer();

        coinSpawner.SpawnCoins(currentLevel.coinsCount);
        enemySpawner.SpawnEnemies(currentLevel.enemiesCount, currentLevel.spawnOffset);
    }

    private void SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab, fdet.Trajectory(0), Quaternion.identity);
    }
}
