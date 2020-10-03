using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMonedas : MonoBehaviour
{
    FuncionDeTrayectoria fdet;

    [SerializeField] GameObject monedaGO;
    [SerializeField] int cantidadDeMonedas = 10;
    [SerializeField] float offsetDeSeparacion = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        fdet = FindObjectOfType<FuncionDeTrayectoria>();

        for (int i = 0; i < cantidadDeMonedas; i++)
        {
            float iter = i / (float)cantidadDeMonedas;
            Instantiate(monedaGO, fdet.TrayectoriaCircular(iter, fdet.Radio+offsetDeSeparacion), Quaternion.identity);
        }
    }

}
