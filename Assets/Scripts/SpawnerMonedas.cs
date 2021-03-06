﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMonedas : MonoBehaviour
{
    FuncionDeTrayectoria fdet;

    [SerializeField] GameObject monedaGO;
    [SerializeField] float offsetDeSeparacion = 1.0f;

    public void SpawnCoins(int coinsCount)
    {
        fdet = FindObjectOfType<FuncionDeTrayectoria>();

        for (int i = 0; i < coinsCount; i++)
        {
            Instantiate(monedaGO, fdet.Trajectory(i), Quaternion.identity);
        }
    }
}
