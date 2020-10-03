using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigo : MonoBehaviour
{
    FuncionDeTrayectoria fdet;
    Movimiento mov;
    float tiempo = 0;

    [SerializeField] GameObject enemigoGO;
    [SerializeField] int cantidadDeEnemigos = 10;
    [SerializeField] float velocidad = .15f;

    // Start is called before the first frame update
    void Start()
    {
        mov = FindObjectOfType<Movimiento>();
        fdet = FindObjectOfType<FuncionDeTrayectoria>();

        for (int i = 0; i < cantidadDeEnemigos; i++)
        {
            Enemigo e = Instantiate(enemigoGO, fdet.TrayectoriaCircular(tiempo, fdet.Radio), Quaternion.identity).GetComponent<Enemigo>();
            e.tiempo = mov.tiempo + 2.5f;
        }
    }
}
