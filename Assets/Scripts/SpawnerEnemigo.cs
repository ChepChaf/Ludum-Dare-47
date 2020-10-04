using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigo : MonoBehaviour
{
    FuncionDeTrayectoria fdet;
    Movimiento mov;
    float tiempo = 0;

    [SerializeField] GameObject enemigoGO;
    [SerializeField] float velocidad = .15f;

    // Start is called before the first frame update
    public void SpawnEnemies(int enemiesCount, float spawnOffset)
    {
        mov = FindObjectOfType<Movimiento>();
        fdet = FindObjectOfType<FuncionDeTrayectoria>();

        for (int i = 0; i < enemiesCount; i++)
        {
            float timeMod = (i * Mathf.PI * 2 * spawnOffset) / enemiesCount;
            Debug.Log("Trayectoria: " + fdet.Trajectory(tiempo));
            Enemigo e = Instantiate(enemigoGO, fdet.Trajectory(tiempo), Quaternion.identity).GetComponent<Enemigo>();
            e.tiempo = mov.tiempo + 2.5f + timeMod;
        }
    }
}
