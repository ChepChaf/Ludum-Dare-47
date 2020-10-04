using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private FuncionDeTrayectoria fdet;

    public float velocidadDeGiro = 0.1f;

    int positionIndex = 0;

    bool isMoving = false;
    bool isJumping = false;
    public float JumpSpeed = 1;

    private SoundManager soundManager;

    private void Start()
    {
        fdet = FindObjectOfType<FuncionDeTrayectoria>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isJumping)
        {
            if (!isMoving)
            {
                StopAllCoroutines();
                StartCoroutine(Move());
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            soundManager.PlaySound("Jump Sound");

            if (!isJumping)
            {
                StopAllCoroutines();
                isMoving = false;
                StartCoroutine(Jump());
            }
        }
    }

    public IEnumerator Move()
    {
        isMoving = true;
        Vector3 nextPosition = fdet.Trajectory(positionIndex++);

        if (positionIndex > FuncionDeTrayectoria.maxIndex) 
            positionIndex = 0;

        while (transform.position != nextPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, Time.deltaTime * velocidadDeGiro);

            yield return new WaitForEndOfFrame();
        }
        isMoving = false;
    }

    public IEnumerator Jump()
    {
        isJumping = true;
        float t = 0;

        Vector3 startPos = transform.position;

        positionIndex = (positionIndex+5) % FuncionDeTrayectoria.maxIndex;

        Vector3 targetPos = fdet.Trajectory(positionIndex);

        while (t <= JumpSpeed)
        {
            t += Time.deltaTime;

            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return new WaitForEndOfFrame();
        }
        isJumping = false;
    }
}
