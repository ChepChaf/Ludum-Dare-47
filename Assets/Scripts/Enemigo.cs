using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    FuncionDeTrayectoria fdet;
    public float tiempo = 0;
    [SerializeField] float velocidadDeGiro = 0.2f;

    

    // Start is called before the first frame update
    void Start()
    {
        fdet = FindObjectOfType<FuncionDeTrayectoria>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, fdet.Trajectory(tiempo * velocidadDeGiro), Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("DEAD");

        if(collision.gameObject.CompareTag("Player"))
        {
            
        }    

    }
}
