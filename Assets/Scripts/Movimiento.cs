using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private FuncionDeTrayectoria fdet;

    public float velocidadDeGiro = 0.1f;
    public float tiempo = 0;

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
            tiempo += Time.deltaTime;

            transform.position = fdet.TrayectoriaCircular(tiempo * velocidadDeGiro);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            soundManager.PlaySound("Jump Sound");

            if (!isJumping)
            {
                StartCoroutine(Jump());
            }
        }
    }

    public IEnumerator Jump()
    {
        isJumping = true;
        float t = 0;

        Vector3 startPos = transform.position;
        Vector3 targetPos = fdet.TrayectoriaCircular((tiempo+5f) * velocidadDeGiro);

        while (t <= JumpSpeed)
        {
            t += Time.deltaTime;

            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return new WaitForEndOfFrame();
        }
        tiempo += 5;
        isJumping = false;
    }
}
