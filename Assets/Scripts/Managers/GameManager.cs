using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private GameObject player;
    private GameObject trajectory;
    FuncionDeTrayectoria fdet;

    public Text gameOverText;
    public Text instructionText;

    public GameObject gameFinishedPanel;

    public int coinsPicked = 0;

    public bool isGameFinished = false;

    private void Awake()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        menuPause = Instantiate(menuPause);
    }

    private void Update()
    {
        if (isGameOver)
        {
            gameOverText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Reset();
            }
        }

        if (isGameFinished)
        {
            Time.timeScale = 0f;

            instructionText.gameObject.SetActive(false);
            gameFinishedPanel.gameObject.SetActive(true);
        }
    }

    private void Reset()
    {
        gameOverText.gameObject.SetActive(false);
        if (trajectory != null)
        {
            Destroy(trajectory);
        }
        if (player != null)
        {
            Destroy(player);
        }

        foreach(var coin in FindObjectsOfType<Moneda>())
        {
            Destroy(coin.gameObject);
        }
        foreach(var enemy in FindObjectsOfType<Enemigo>())
        {
            Destroy(enemy.gameObject);
        }

        StartLevel();
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

        if (coinsPicked == currentLevel.coinsCount)
        {
            isGameFinished = true;
        }
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
    }

    private void StartLevel()
    {
        soundManager.PlaySound("Game Play Mx");
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
        player = Instantiate(playerPrefab, fdet.Trajectory(0), Quaternion.identity);
    }
}
