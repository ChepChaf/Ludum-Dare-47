﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbita : MonoBehaviour
{
    LineRenderer lineRenderer;
    public int resolucion;

    public void DrawOrbit()
    {
        FuncionDeTrayectoria fdet = FindObjectOfType<FuncionDeTrayectoria>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = resolucion+1;

        for (int i = 0; i <= resolucion; i++)
        {
            lineRenderer.SetPosition(i, fdet.Trajectory(i));
        }
        
    }
}
