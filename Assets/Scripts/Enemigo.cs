using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    FuncionDeTrayectoria fdet;
    public float tiempo = 0;
    [SerializeField] float velocidadDeGiro = 0.2f;

    public int positionIndex = 0;

    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        fdet = FindObjectOfType<FuncionDeTrayectoria>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        
        if (!isMoving)
        {
            StopAllCoroutines();
            StartCoroutine(Move());
        }
    }

    public IEnumerator Move()
    {
        isMoving = true;
        Vector3 nextPosition = fdet.Trajectory(positionIndex++, 0f, true);

        if (positionIndex >= FuncionDeTrayectoria.maxIndex)
            positionIndex = 0;

        while (transform.position != nextPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
        isMoving = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("DEAD");

        if(collision.gameObject.CompareTag("Player"))
        {
            
        }    

    }
}
