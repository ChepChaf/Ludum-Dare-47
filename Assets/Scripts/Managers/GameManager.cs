using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void OnGameOver();
    public static event OnGameOver onGameOverEvent;

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
    [SerializeField]
    private GameObject menuPause;

    private GameObject trajectory;
    FuncionDeTrayectoria fdet;

    public int coinsPicked = 0;

    private void Awake()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        menuPause = Instantiate(menuPause);
    }

    private void OnEnable()
    {
        Enemigo.onPlayerCollisionEvent += TriggerGameOver;
        Moneda.onCoinPickedEvent += PickCoin;
    }

    private void OnDisable()
    {
        Enemigo.onPlayerCollisionEvent -= TriggerGameOver;
        Moneda.onCoinPickedEvent -= PickCoin;
    }

    void PickCoin()
    {
        coinsPicked++;
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        onGameOverEvent?.Invoke();
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
