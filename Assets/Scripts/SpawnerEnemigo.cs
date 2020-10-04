using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigo : MonoBehaviour
{
    FuncionDeTrayectoria fdet;

    [SerializeField] GameObject enemigoGO;
    [SerializeField] float velocidad = .15f;

    // Start is called before the first frame update
    public void SpawnEnemies(int enemiesCount, float spawnOffset)
    {
        fdet = FindObjectOfType<FuncionDeTrayectoria>();

        for (int i = 0; i < enemiesCount; i++)
        {
            Enemigo e = Instantiate(enemigoGO, fdet.Trajectory(i+1, 0, true), Quaternion.identity).GetComponent<Enemigo>();
            e.positionIndex = i + 2;
        }
    }
}
