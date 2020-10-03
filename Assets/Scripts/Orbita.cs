using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbita : MonoBehaviour
{
    LineRenderer lineRenderer;
    public int resolucion;

    void Start()
    {
        FuncionDeTrayectoria fdet = FindObjectOfType<FuncionDeTrayectoria>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = resolucion+1;

        for (int i = 0; i <= resolucion; i++)
        {
            float iter = i / (float)resolucion;
            lineRenderer.SetPosition(i, fdet.TrayectoriaCircular(iter));
        }
        
    }
}
